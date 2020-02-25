using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothicDubbingChecker.Classes
{
    class GothicPatterns
    {
        public static string OutputOther = @"AI_Output\s*\(\s*(other|hero)\s*,\s*self\s*,\s*""(.+)""\s*\)\s*;\s*//(.*)";
        public static string OutputSelf = @"AI_Output\s*\(\s*self\s*,\s*(other|hero)\s*,\s*""(.+)""\s*\)\s*;\s*//(.*)";
        public static string TrialogStart = @"\s*TRIA_Start();\s*";
        public static string TrialogFinish = @"\s*TRIA_Finish();\s*";
        public static string DiaFileName = @"DIA_NASZ_([0-9]+)_(.+).d";

    }
}
