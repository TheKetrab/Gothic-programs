using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace GothicDubbingChecker.Classes
{
    class Parser
    {
        public AIOutputList List { get; }
        public NpcsDictionary Dictionary { get; }
        public GothicPaths Paths;

        public List<string> WavNames;


        public void InitiateWavNames()
        {
            WavNames = new List<string>();
            string[] files = Directory.GetFiles(Paths.DubPath);

            foreach (string file in files)
                WavNames.Add(new FileInfo(file).Name);

        }

        public static string MakeDiaString(string instance, string dialoge)
        {
            string whiteSpace = new String(' ', 75 - instance.Length);
            return (instance + whiteSpace + dialoge);
        }


        public bool Exists(string fileName)
        {
            foreach (string name in WavNames)
                if (name.ToUpper().Equals(fileName.ToUpper()))
                    return true;

            return false;
        }






        private void Parse()
        {
            StreamWriter streamWriterDialoges = new StreamWriter(Paths.OutputDialoges,false,Encoding.Default);
            StreamWriter streamWriterHero = new StreamWriter(Paths.OutputHero,false,Encoding.Default);
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

            // inicjowanie tablicy npc
            foreach (var file in Directory.GetFiles(Paths.ScriptsPath, "*.d", SearchOption.AllDirectories))
            {
                Console.WriteLine(">Parse file: " + new FileInfo(file).Name);

                PrintHeader(streamWriterDialoges, new FileInfo(file).Name);
                PrintHeader(streamWriterHero, new FileInfo(file).Name);

                StreamReader streamReader = new StreamReader(file, Encoding.Default);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (Regex.IsMatch(line, GothicPatterns.OutputOther, options))
                    {
                        Match match = Regex.Match(line, GothicPatterns.OutputOther, options);

                        string Instance = match.Groups[2].Value;
                        Npc hero = Dictionary[0];
                        hero.AIOutputCounter++;

                        if (!Exists(Instance + ".WAV"))
                            hero.Missing.Add(new AIOutput(Instance, "other,self", match.Groups[3].Value));

                        streamWriterHero.WriteLine(MakeDiaString(match.Groups[2].Value, match.Groups[3].Value));
                        List.List.Add(Instance.ToUpper(),new AIOutput(Instance,"other,self", match.Groups[3].Value));
                    }

                    else if (Regex.IsMatch(line, GothicPatterns.OutputSelf, options))
                    {
                        Match match = Regex.Match(line, GothicPatterns.OutputSelf, options);

                        string Instance = match.Groups[2].Value;
                        string filename = new FileInfo(file).Name;

                        if (Regex.IsMatch(filename, GothicPatterns.DiaFileName, options))
                        {
                            Match matchFileName = Regex.Match(filename, GothicPatterns.DiaFileName, options);

                            int id = Int32.Parse(matchFileName.Groups[1].Value);
                            string name = matchFileName.Groups[2].Value;

                            if (Dictionary.Dict.ContainsKey(id))
                            {
                                Npc npc = Dictionary[id];
                                npc.AIOutputCounter++;
                            }
                            else // not exist
                            {
                                Npc npc = new Npc(id, name);
                                npc.AIOutputCounter++;
                                Dictionary.Dict.Add(id, npc);
                            }

                            // -----
                            if (!Exists(Instance + ".WAV"))
                                Dictionary[id].Missing.Add(new AIOutput(Instance, "self,other", match.Groups[3].Value));
                        }
                        else
                        {
                            Console.WriteLine("Dziwna nazwa pliku: " + filename);


                            if (Dictionary.Dict.ContainsKey(1000))
                            {
                                Npc npc = Dictionary[1000];
                                npc.AIOutputCounter++;
                            }
                            else // not exist
                            {
                                Npc npc = new Npc(1000, "UNKNOWN");
                                npc.AIOutputCounter++;
                                Dictionary.Dict.Add(1000, npc);
                            }

                            Dictionary[1000].Missing.Add(new AIOutput(Instance, "self,other", Instance));

                            if (!Exists(Instance + ".WAV"))
                                Dictionary[1000].Missing.Add(new AIOutput(Instance, "self,other", match.Groups[3].Value));

                        }

                        // stream writer write line
                        streamWriterDialoges.WriteLine(MakeDiaString(match.Groups[2].Value, match.Groups[3].Value));
                        List.List.Add(Instance.ToUpper(),new AIOutput(Instance,"self,other,", match.Groups[3].Value));
                    }

                    // TODO wylapywanie tego nie dziala, zly pattern
                    else if (Regex.IsMatch(line, GothicPatterns.TrialogStart, options))
                    {
                        streamWriterDialoges.WriteLine("----- ----- ----- ----- -----");
                        streamWriterDialoges.WriteLine(" !!! UWAGA -> Trialog !!!");
                    }

                    else if (Regex.IsMatch(line, GothicPatterns.TrialogFinish, options))
                    {
                        streamWriterDialoges.WriteLine(" -----> Koniec trialogu!");
                        streamWriterDialoges.WriteLine("----- ----- ----- ----- -----");
                    }



                }
            }

        }

        private void PrintHeader(StreamWriter streamWriter, string str)
        {
            streamWriter.WriteLine("***** ***** ***** ***** *****");
            streamWriter.WriteLine(" --- " + str + " --- ");
            streamWriter.WriteLine("***** ***** ***** ***** *****");
        }

        public Parser(GothicPaths paths) {

            List = new AIOutputList(paths);
            Dictionary = new NpcsDictionary(paths);
            Paths = paths;
            InitiateWavNames();

            Parse();
        }





    }
}
