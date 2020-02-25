using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GothicDubbingChecker.Classes
{
    class Stats
    {
        public AIOutputList List { get; }
        public NpcsDictionary Dictionary { get; }
        public GothicPaths Paths;

        public Stats(AIOutputList list, NpcsDictionary dict, GothicPaths paths)
        {
            List = list;
            Dictionary = dict;
            Paths = paths;
        }

        public void PrintMissing()
        {
            Console.WriteLine("PrintMissing");
            StreamWriter streamWriter = new StreamWriter(Paths.OutputMissing,false,Encoding.Default);
            List.CheckMissingWavs(streamWriter);
            streamWriter.Close();
        }

        public void PrintUnnecessary()
        {
            Console.WriteLine("PrintUnnecessary");
            StreamWriter streamWriter = new StreamWriter(Paths.OutputUnnecessary, false, Encoding.Default);
            List.CheckUnnecessaryWavs(streamWriter);
            streamWriter.Close();
        }

        public void PrintInfo(int flags)
        {
            Console.WriteLine("PrintInfo");


            StreamWriter streamWriter = new StreamWriter(Paths.OutputInfo, false, Encoding.Default);

            int total = 0;
            int done = 0;

            foreach (var item in Dictionary.Dict)
            {
                Npc npc = item.Value;
                total += npc.AIOutputCounter;
                done += npc.Done();
                npc.Print(streamWriter, flags);
            }

            streamWriter.WriteLine();
            streamWriter.WriteLine(" --- === Stats: === --- ");

            double heroProcents =
                (((double)Dictionary.Dict[0].Done())
                / ((double)Dictionary.Dict[0].AIOutputCounter) * 100);

            streamWriter.WriteLine("HERO:  " + Math.Round(heroProcents,2) + "%");

            double selfsProcents =
                (((double)(done - Dictionary.Dict[0].Done()))
                / ((double)(total - Dictionary.Dict[0].AIOutputCounter)) * 100);

            streamWriter.WriteLine("SELFS: " + Math.Round(selfsProcents, 2) + "%");

            double totalProcents =
                (((double)done)
                / ((double)total) * 100);

            streamWriter.WriteLine("TOTAL: " + Math.Round(totalProcents, 2) + "%");


            streamWriter.Close();

        }

        public void PrintAll(int flags)
        {
            PrintInfo(flags);
            PrintMissing();
            PrintUnnecessary();
        }


    }
}
