using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace GothicDecibelsModulator
{

    public class Program
    {

        static string inputDir = @"C:\Users\ketra\Desktop\test\input";
        static string outputDir = @"C:\Users\ketra\Desktop\test\output";
        static string patternMaxVolume = @"max_volume: ([-+]?[0-9]*\.?[0-9]*) dB";

        static double processingTime = 0;
        static double remainingTime = 0;
        static int xTime = 0;
        static int yTime = 0;


        private static readonly object ConsoleWriterLock = new object();

        public static void Main()
        {
            

            var files = Directory.GetFiles(inputDir);
            int state = 0;

            Console.CursorVisible = false;

            Console.WriteLine();
            Console.WriteLine(" ----- ===== ##### ===== ----- ");
            Console.Write(" ---- ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Conversion started.");
            Console.ResetColor();
            Console.Write(" ---- \n\r");
            Console.WriteLine(" ----- ===== ##### ===== ----- ");

            Console.Write("Processing: ");
            var xPercent = Console.CursorLeft;
            var yPercent = Console.CursorTop;

            Console.WriteLine();
            Console.Write("Remaining time: ");
            xTime = Console.CursorLeft;
            yTime = Console.CursorTop;

            // TIMER
            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += (s, e) => {

                lock(ConsoleWriterLock)
                {
                    WriteTimeRemained();
                    processingTime++;
                }
            };

            timer.Start();

            for (int i=0; i<files.Length; i++)
            {

                // ----- PERCENT LOG -----
                int s = (int) Math.Floor((double)i * 100.0 / (double)files.Length);
                if ( s > state )
                {
                    lock(ConsoleWriterLock)
                    {
                        state = s;
                        Console.SetCursorPosition(xPercent, yPercent);
                        Console.Write($"{s}%");
                    }

                    if (i != 0)
                        remainingTime = Math.Floor(((double)(files.Length - i) / (double)i) * processingTime);
                }


                var finfo = new FileInfo(files[i]);

                if (!finfo.Extension.Equals(".WAV",StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Error - zły format pliku wejściowego: {0}",finfo.Name);
                    continue;
                }

                string volumeDetect = RunVolumeDetect(finfo);
                var maxVolume = GetMaxVolume(volumeDetect);
                RunVolumeIncrease(finfo,maxVolume);

            }

            Console.WriteLine();

            timer.Stop();

            Console.Write("Done. Processing time: ");
            TimeSpan time = TimeSpan.FromSeconds(processingTime);
            Console.Write(time.ToString(@"hh\:mm\:ss"));
            Console.WriteLine();

            Console.CursorVisible = true;

            Console.ReadKey();
        }


        public static void WriteTimeRemained()
        {
            Console.SetCursorPosition(xTime, yTime);
            TimeSpan time = TimeSpan.FromSeconds(remainingTime);
            Console.Write(time.ToString(@"hh\:mm\:ss"));
            remainingTime--;
        }





        public static double GetMaxVolume(string ffmpegOutput)
        {
            Regex regex = new Regex(patternMaxVolume);
            if (regex.IsMatch(ffmpegOutput))
            {
                Match m = regex.Match(ffmpegOutput);
                double res = double.Parse(m.Groups[1].Value, CultureInfo.InvariantCulture);
                return res;
            }

            return 0;
        }

        public static string RunVolumeDetect(FileInfo finfo)
        {
            string output = "";
            string arguments = $"-i {finfo.FullName} -filter:a volumedetect -f null /dev/null";

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "ffmpeg.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardError = true;
                
                process.ErrorDataReceived 
                    += new DataReceivedEventHandler((sender, e) =>
                {
                    output += e.Data;
                });

                process.Start();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }

            return output;
        }

        public static void RunVolumeIncrease(FileInfo finfo, double maxVolume)
        {
            string newFile = $"{outputDir}/{finfo.Name}";
            string dbModifier = (-maxVolume).ToString("0.0", CultureInfo.InvariantCulture);
            
            string arguments = $"-i {finfo.FullName} "
                + $"-filter:a \"volume={dbModifier}dB\" " // increase volume
                + "-ar 44100 " // .......................... sampling
                + "-ac 1 -map_metadata -1 " // ............. destroy metadata
                + "-f wav -acodec adpcm_ima_wav " // ....... codec
                + "-b:a 177k " // .......................... bitrate audio
                 + newFile;

            using (Process process = new Process())
            {
                process.StartInfo.FileName = "ffmpeg.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Arguments = arguments;
                process.StartInfo.CreateNoWindow = true;

                /*
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(process.StartInfo.Arguments);
                Console.ForegroundColor = ConsoleColor.Gray;
                */

                process.Start();
                process.WaitForExit();
            }

        }

    }
}
