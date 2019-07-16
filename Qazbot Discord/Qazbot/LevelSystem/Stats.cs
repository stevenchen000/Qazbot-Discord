using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.LevelSystem
{
    class Stats
    {
        public int level { get; set; }
        public int currentExp { get; set; }
        public int expForNextLevel { get; set; }

        public int currentHealth { get; set; }
        public int maxHealth { get; set; }
        public int strength { get; set; }
        public int magic { get; set; }
        public int defense { get; set; }
        public int magicDefense { get; set; }
        public int agility { get; set; }
    }
}
