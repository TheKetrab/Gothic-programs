using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothicDubbingChecker.Classes
{
    class NpcFlags
    {
        public static int PrintMissing = 1 << 0;
        public static int DelComplete = 1 << 1;
        /*public int e3 = 1 << 2;
        public int e4 = 1 << 3;
        public int e5 = 1 << 4;
        public int e6 = 1 << 5;*/
    }

    class Npc
    {

        public int Id;
        public string Name;
        public List<AIOutput> Missing;
        public int AIOutputCounter;

        public Npc(int id, string name)
        {
            Id = id;
            Name = name;
            Missing = new List<AIOutput>();
            AIOutputCounter = 0;
        }


        private string BuildNpcInfo()
        {
            string space1 = new string(' ', 15 - Name.Length);
            string state = (AIOutputCounter - Missing.Count) + "/" + AIOutputCounter;
            string space2 = new string(' ',10-state.Length);

            return Name + space1 + state + space2 + "LEFT: " + Missing.Count;
        }


        public void Print(StreamWriter streamWriter, int mode)
        {
            double percent = ((double)(AIOutputCounter - Missing.Count) / (double)AIOutputCounter) * 100;

            // 1 bit - jesli ktos kompletny, to wykresl
            if ((mode & NpcFlags.DelComplete) > 0 && (percent >= 80))
            {
                if (Missing.Count == 0)
                {
                    streamWriter.WriteLine("----- ----- ----- ----- -----");
                }
                else
                {
                    streamWriter.WriteLine("***** ***** ALMOST ***** *****");
                }

                return;
            }

            
    
            streamWriter.WriteLine(BuildNpcInfo());

            // 0 bit - pokaz liste brakuajcych kwestii
            if ((mode & NpcFlags.PrintMissing) > 0)
                foreach (var aio in Missing)
                    aio.Print(streamWriter);
                    
        }


        // zwraca ile kwestii jest nagranych
        public int Done()
        {
            return AIOutputCounter - Missing.Count;
        }
    }
}
