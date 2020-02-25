using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothicDubbingChecker.Classes
{
    class GothicPaths
    {
        public string DubPath { get; }
        public string ScriptsPath { get; }
        public string OutputMissing { get; }
        public string OutputUnnecessary { get; }
        public string OutputDialoges { get; }
        public string OutputHero { get; }
        public string OutputInfo { get; }
        public string OutputAlphabet { get; }


        public GothicPaths()
        {
            var baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            var filePath = baseDir + @"\Paths.txt";

            StreamReader streamReader = new StreamReader(filePath);

            DubPath = streamReader.ReadLine();
            ScriptsPath = streamReader.ReadLine();
            OutputMissing = baseDir + @"\Missing.txt";
            OutputUnnecessary = baseDir + @"\Unnecessary.txt";
            OutputDialoges = baseDir + @"\Dialoges.txt";
            OutputHero = baseDir + @"\Hero.txt";
            OutputInfo = baseDir + @"\Info.txt";
            OutputAlphabet = baseDir + @"\Alphabet.txt";

        }

        public void PrintPaths()
        {
            Console.WriteLine("--- === GOTHIC PATHS === ---");
            Console.WriteLine(" * DubPath:           " + DubPath);
            Console.WriteLine(" * ScriptsPath:       " + ScriptsPath);
            Console.WriteLine(" * OutputMissing:     " + OutputMissing);
            Console.WriteLine(" * OutputUnnecessary: " + OutputUnnecessary);
            Console.WriteLine(" * OutputDialoges:    " + OutputDialoges);
            Console.WriteLine(" * OutputHero:        " + OutputHero);
            Console.WriteLine(" * OutputInfo:        " + OutputInfo);
        }


    }
}
