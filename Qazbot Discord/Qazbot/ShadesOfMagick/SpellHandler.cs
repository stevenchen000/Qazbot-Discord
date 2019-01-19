using Qazbot.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.ShadesOfMagick
{
    class SpellHandler : Module
    {
        public List<Spell> spellsList { get; set; } = new List<Spell>();


        public SpellHandler(string filename) {
            this.filename = filename;
        }

        public void AddSpell(Spell spell) {
            spellsList.Add(spell);
        }

        public void RemoveSpell(int index) {
            spellsList.RemoveAt(index);
        }

        public Spell GetRandomSpell() {
            int randNum = ModuleHandler.rand.Next();

            return spellsList[randNum % spellsList.Count];
        }

        public string CastSpell(string caster, string target) {
            Spell spell = GetRandomSpell();
            bool reflect = false, oil = false, faith = false, reverse = false;
            int level = 30;
            int magickPower = 50;
            int magickResist = 0;

            string result = $"{caster} casted {spell.spellName} on {target}!\n";

            //Check if target has reflect
            if (caster != target && RandomChance(20)) {
                reflect = true;
                result += $"{target} has reflect.\n";
            }

            //Check if caster has faith
            if (spell.GetType() != typeof(EffectSpell) && RandomChance(10))
            {
                faith = true;
                result += $"{caster} has faith.\n";
            }

            //Check if target has oil
            if (spell.GetType() == typeof(DamageSpell)) {
                if (((DamageSpell)spell).element == FF12Element.Fire && RandomChance(30)) {
                    result += reflect ? $"{caster} is all oily.\n" : $"{target} is all oily.\n";
                    oil = true;
                }
            }

            if (spell.GetType() != typeof(EffectSpell)) {
                if (RandomChance(5)) {
                    result += reflect ? $"{caster} has reverse.\n" : $"{target} has reverse.\n";
                    reverse = true;
                }
            }

            int damage = 0;


            if (spell.GetType() == typeof(DamageSpell))
            {
                DamageSpell dspell = (DamageSpell)spell;
                double randMultiplier = (ModuleHandler.rand.Next() % 125) / 1000.0;

                damage = (int)((dspell.spellpower * (1 + randMultiplier) - magickResist) *
                            (2 + magickPower * (level + magickPower) / 256));

                damage = damage < 0 ? 0 : damage;

                if (oil)
                {
                    damage *= 3;
                }
                if (faith)
                {
                    damage = (int)(damage * 1.3);
                }

                string newTarget = reflect ? caster : target;

                result += reverse ? $"{caster} healed {newTarget} for {damage} health!"
                                    : $"{caster} did {damage} damage to {newTarget}!";
            }
            else if (spell.GetType() == typeof(HealingSpell))
            {
                HealingSpell hspell = (HealingSpell)spell;
                double randMultiplier = (ModuleHandler.rand.Next() % 125) / 1000.0;

                damage = (int)((hspell.spellpower * (1 + randMultiplier)) *
                            (2 + magickPower * (level + magickPower) / 256));

                damage = damage < 0 ? 0 : damage;


                if (faith)
                {
                    damage = (int)(damage * 1.5);
                }

                string newTarget = reflect ? caster : target;

                result += !reverse ? $"{caster} healed {newTarget} for {damage} health!"
                                    : $"{caster} did {damage} damage to {newTarget}!";
            }
            else if (spell.GetType() == typeof(EffectSpell)) {
                EffectSpell bspell = (EffectSpell)spell;

                int accuracy = bspell.baseAccuracy < 0 ? 100 : bspell.baseAccuracy + magickPower - magickResist;

                string newTarget = reflect ? caster : target;

                if (RandomChance(accuracy)) {
                    result += $"{newTarget} {bspell.effect}";
                }
                else{
                    result += $"{caster} missed!";
                }
            }

            return result;
        }

        /// <summary>
        /// Returns true if random value from 0-99 is less than chance
        /// </summary>
        /// <param name="chance"></param>
        /// <returns></returns>
        private bool RandomChance(int chance) {
            return ModuleHandler.rand.Next() % 100 < chance;
        }

        public override void LoadData()
        {
            try
            {
                spellsList = DataManager<List<Spell>>.LoadData(filename);
            }
            catch {

            }
        }

        public override void SaveData()
        {
            DataManager<List<Spell>>.SaveData(spellsList, filename);
        }
    }
}
