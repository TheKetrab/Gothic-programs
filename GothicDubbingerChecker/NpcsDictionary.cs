using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GothicDubbingChecker.Classes
{
    class NpcsDictionary
    {
        public Dictionary<int,Npc> Dict; // <id,npc>

        public NpcsDictionary(GothicPaths paths)
        {
            Dict = new Dictionary<int, Npc>
            {
                { 0, new Npc(0, "Will") }
            };
        }

        public Npc this[int key]
        {
            get
            {
                return Dict[key];
            }
            set
            {
                Dict[key] = value;
            }
        }


    }
}
