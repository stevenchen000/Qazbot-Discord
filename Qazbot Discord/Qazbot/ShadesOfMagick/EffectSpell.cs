using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.ShadesOfMagick
{
    class EffectSpell : Spell
    {
        public int baseAccuracy { get; set; }
        public string effect { get; set; }

        public EffectSpell(string spellName, int baseAccuracy, string effect) {
            this.spellName = spellName;
            this.baseAccuracy = baseAccuracy;
            this.effect = effect;
        }

        public override string Execute()
        {
            string result = "";

            return result;
        }
    }
}
