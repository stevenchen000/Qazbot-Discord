using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.ShadesOfMagick
{
    public abstract class Spell
    {
        public string spellName { get; set; }
        public bool canBeReflected { get; set; }
        public bool canBeReversed { get; set; }
        public FF12Element spellElement { get; set; }

        public abstract string Execute();
    }
}
