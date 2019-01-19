using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.ShadesOfMagick
{
    class HealingSpell : Spell
    {
        public int spellpower { get; set; }

        public HealingSpell(string spellName, int spellpower) {
            this.spellName = spellName;
            this.spellpower = spellpower;
        }
    }
}
