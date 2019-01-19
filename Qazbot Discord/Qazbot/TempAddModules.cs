using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qazbot.ShadesOfMagick;

namespace Qazbot
{
    class TempAddModules
    {
        public TempAddModules() {

        }

        public void AddModules() {
            ModuleHandler.AddModule("shades of black", new SpellHandler(""));
            ModuleHandler.AddModule("tints of white", new SpellHandler(""));
            ModuleHandler.AddModule("hues of green", new SpellHandler(""));
            ModuleHandler.AddModule("runes of arcane", new SpellHandler(""));
            ModuleHandler.AddModule("annuls of time", new SpellHandler(""));

            SpellHandler sob = (SpellHandler)ModuleHandler.modules["shades of black"];
            SpellHandler tow = (SpellHandler)ModuleHandler.modules["tints of white"];
            SpellHandler hog = (SpellHandler)ModuleHandler.modules["hues of green"];
            SpellHandler roa = (SpellHandler)ModuleHandler.modules["runes of arcane"];
            SpellHandler aot = (SpellHandler)ModuleHandler.modules["annuls of time"];

            #region sob spells
            sob.AddSpell(new DamageSpell("Fire", 25, FF12Element.Fire));
            sob.AddSpell(new DamageSpell("Thunder", 25, FF12Element.Lightning));
            sob.AddSpell(new DamageSpell("Blizzard", 25, FF12Element.Ice));
            sob.AddSpell(new DamageSpell("Water", 37, FF12Element.Water));
            sob.AddSpell(new DamageSpell("Aero", 52, FF12Element.Wind));
            sob.AddSpell(new DamageSpell("Fira", 70, FF12Element.Fire));
            sob.AddSpell(new DamageSpell("Thundara", 70, FF12Element.Lightning));
            sob.AddSpell(new DamageSpell("Blizzara", 70, FF12Element.Ice));
            sob.AddSpell(new DamageSpell("Bio", 88, FF12Element.None));
            sob.AddSpell(new DamageSpell("Aeroga", 103, FF12Element.Wind));
            sob.AddSpell(new DamageSpell("Firaga", 124, FF12Element.Fire));
            sob.AddSpell(new DamageSpell("Thundaga", 124, FF12Element.Lightning));
            sob.AddSpell(new DamageSpell("Blizzaga", 124, FF12Element.Ice));
            sob.AddSpell(new DamageSpell("Shock", 133, FF12Element.None));
            sob.AddSpell(new DamageSpell("Scourge", 142, FF12Element.None));
            sob.AddSpell(new DamageSpell("Flare", 163, FF12Element.None));
            sob.AddSpell(new DamageSpell("Ardor", 175, FF12Element.Fire));
            sob.AddSpell(new DamageSpell("Scathe", 190, FF12Element.None));
            #endregion
            #region tow spells
            tow.AddSpell(new HealingSpell("Cure", 20));
            tow.AddSpell(new HealingSpell("Cura", 45));
            tow.AddSpell(new HealingSpell("Curaga", 85));
            tow.AddSpell(new HealingSpell("Curaja", 145));
            tow.AddSpell(new EffectSpell("Renew", -1, "was fully healed!"));
            tow.AddSpell(new EffectSpell("Raise", -1, "came back to life!"));
            tow.AddSpell(new EffectSpell("Arise", -1, "was revived at full health!"));
            tow.AddSpell(new EffectSpell("Esuna", -1, "had all their debuffs removed!"));
            tow.AddSpell(new EffectSpell("Esunaga", -1, "had all their debuffs removed!"));
            tow.AddSpell(new EffectSpell("Blindna", -1, "no longer needs glasses!"));
            tow.AddSpell(new EffectSpell("Vox", -1, "can talk!"));
            tow.AddSpell(new EffectSpell("Poisona", -1, "is no longer poisoned!"));
            tow.AddSpell(new EffectSpell("Stona", -1, "is no longer stoned!"));
            tow.AddSpell(new EffectSpell("Cleanse", -1, "was cured of all their STDs!"));
            tow.AddSpell(new EffectSpell("Dispel", -1, "lost all their buffs!"));
            tow.AddSpell(new EffectSpell("Dispelga", -1, "lost all their buffs!"));
            tow.AddSpell(new EffectSpell("Regen", -1, "is now recovering HP over time!"));
            tow.AddSpell(new DamageSpell("Holy", 157, FF12Element.Holy));
            #endregion
            #region hog spells
            hog.AddSpell(new EffectSpell("Protect", -1, "has protection! <:roostaLewd:316562446397603842>"));
            hog.AddSpell(new EffectSpell("Protectga", -1, "has protection! <:roostaLewd:316562446397603842>"));
            hog.AddSpell(new EffectSpell("Shell", -1, "is hiding in their shell 🐚"));
            hog.AddSpell(new EffectSpell("Shellga", -1, "is hiding in their shell 🐚"));
            hog.AddSpell(new EffectSpell("Bravery", -1, "is no longer afraid of the dark!"));
            hog.AddSpell(new EffectSpell("Faith", -1, "got on their knees and started praying!"));
            hog.AddSpell(new EffectSpell("Blind", -1, "can't see!"));
            hog.AddSpell(new EffectSpell("Blindga", -1, "needs glasses!"));
            hog.AddSpell(new EffectSpell("Silence", 10, "has duct tape covering their mouth!"));
            hog.AddSpell(new EffectSpell("Silencega", 5, "has stopped talking! Thank god!"));
            hog.AddSpell(new EffectSpell("Sleep", 15, "fell asleep!"));
            hog.AddSpell(new EffectSpell("Sleepga", 5, "fell asleep!"));
            hog.AddSpell(new EffectSpell("Poison", 10, "is poisoned!"));
            hog.AddSpell(new EffectSpell("Toxify", 5, "is poisoned!"));
            hog.AddSpell(new EffectSpell("Oil", 30, "is all oily <:roostaLewd:316562446397603842>"));
            #endregion
            #region roa spells
            roa.AddSpell(new DamageSpell("Dark", 46, FF12Element.Dark));
            roa.AddSpell(new DamageSpell("Darkra", 91, FF12Element.Dark));
            roa.AddSpell(new DamageSpell("Darkga", 130, FF12Element.Dark));
            roa.AddSpell(new EffectSpell("Gravity", 20, "was forced to their knees!"));
            roa.AddSpell(new EffectSpell("Graviga", 0, "just put on 300 pounds...that fatty."));
            roa.AddSpell(new EffectSpell("Reverse", 20, "turned the other way!"));
            roa.AddSpell(new EffectSpell("Berserk", 10, "is on a drunken rampage!"));
            roa.AddSpell(new EffectSpell("Confuse", 0, "is confused about their sexual orientation!"));
            roa.AddSpell(new EffectSpell("Decoy", 10, "is attracting all monsters with their duck!"));
            roa.AddSpell(new EffectSpell("Death", 0, "died!"));
            roa.AddSpell(new EffectSpell("Vanish", -1, "disappeared just like your ex-boyfriend when he found out you were pregnant!"));
            roa.AddSpell(new EffectSpell("Vanishga", -1, "disappeared in a puff of smoke!"));
            roa.AddSpell(new EffectSpell("Bubble", -1, "had their HP doubled!"));
            roa.AddSpell(new EffectSpell("Drain", -1, "had their blood sucked!"));
            roa.AddSpell(new EffectSpell("Syphon", -1, "lost some MP!"));
            #endregion
            #region aot spells
            aot.AddSpell(new EffectSpell("Haste", -1, "is moving very fast!"));
            aot.AddSpell(new EffectSpell("Hastega", -1, "is moving very fast!"));
            aot.AddSpell(new EffectSpell("Slow", 10, "is moving very slowly!"));
            aot.AddSpell(new EffectSpell("Slowga", 5, "is moving slower than an American after Thanksgiving!"));
            aot.AddSpell(new EffectSpell("Immobilize", 0, "broke their legs and can't move!"));
            aot.AddSpell(new EffectSpell("Disable", 0, "can now use the disabled parking!"));
            aot.AddSpell(new EffectSpell("Stop", 0, "is frozen in time!"));
            aot.AddSpell(new EffectSpell("Reflect", -1, "is now reflecting all spells!"));
            aot.AddSpell(new EffectSpell("Reflectga", -1, "turned into a mirror!"));
            aot.AddSpell(new EffectSpell("Float", -1, "is floating in the air!"));
            aot.AddSpell(new EffectSpell("Break", 0, "is getting stoned!"));
            aot.AddSpell(new EffectSpell("Countdown", 5, "is about to die!"));
            aot.AddSpell(new EffectSpell("Balance", 20, "tripped!"));
            aot.AddSpell(new EffectSpell("Bleed", 30, "is on their period!"));
            aot.AddSpell(new EffectSpell("Warp", -1, "just entered...the Twilight Zone!"));
            #endregion
        }
    }
}
