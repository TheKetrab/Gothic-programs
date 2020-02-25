using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace GothicDubbingChecker.Classes
{
    class ExcelMaker
    {
        private string Path;

        private _Application XL;
        private _Workbook WB;
        private _Worksheet WS;
        private Range Rng;

        private Stats Stats;


        // otwiera plik
        public ExcelMaker(string path, Stats s)
        {
            Path = path;
            
            XL = new Application();
            XL.Visible = true;

            //Get a new workbook.
            WB = XL.Workbooks.Open(path);
            WS = WB.ActiveSheet;

            Stats = s;
        }

        public void GenerateXL()
        {
            
        }

        public void PrintStats()
        {
            var dict = Stats.Dictionary.Dict;
            int size = dict.Count;

            int i = 1;
            foreach(var item in dict)
            {
                Npc npc = item.Value;
                WS.Cells[i, 1] = npc.Id;
                WS.Cells[i, 2] = npc.Name;

                string done = npc.Done() + " / " + npc.AIOutputCounter;
                double procent = ((double)(npc.Done()) / (double)(npc.AIOutputCounter)) * 100.0;

                WS.Cells[i, 3] = done;
                WS.Cells[i, 4] = procent;
                i++;
            }

        }






    }
}
