using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.ShadesOfMagick
{
    class DamageSpell : Spell
    {
        public int spellpower { get; set; }
        public FF12Element element { get; set; }

        public DamageSpell(string spellName, int spellpower, FF12Element element) {
            this.spellName = spellName;
            this.spellpower = spellpower;
            this.element = element;
        }

        public override string Execute()
        {
            string result = "";

            return result;
        }
    }
}
