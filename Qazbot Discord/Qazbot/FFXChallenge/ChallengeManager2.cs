using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Qazbot.FFXChallenge
{
    class ChallengeManager2
    {
        public List<Challenge2> challenges { get; set; } = new List<Challenge2>();

        public ChallengeManager2() {
            InitChallenges();
            //LoadChallenges();
        }



        public string CreateChallenge(string username) {
            string result = "";

            List<KeyValuePair<Challenge2, bool>> challengeList = PickRandomChallenges(challenges);
            string fullAcronym = CreateAcronym(challengeList);
            string fullChallenge = CreateChallengeName(challengeList);

            result = $"{username} smashed their head against their keyboard and got the {fullAcronym} Challenge. \nThe {fullChallenge} Challenge.";

            return result;
        }



        public string CreateAcronym(List<KeyValuePair<Challenge2, bool>> challengeList) {
            string result = "";

            foreach (KeyValuePair<Challenge2, bool> pair in challengeList) {
                string temp = pair.Key.challengeAcronym;

                if (pair.Key.overrideAcronym)
                {
                    temp = pair.Key.challengeAcronym;
                }
                else
                {
                    temp = pair.Value ? $"N{temp}" : $"{temp}A";
                }

                result += temp;
            }

            return result;
        }



        public string CreateChallengeName(List<KeyValuePair<Challenge2, bool>> challengeList)
        {
            string result = "";

            for(int i = 0; i < challengeList.Count; i++)
            {
                string temp = challengeList[i].Key.challengeName;

                if (challengeList[i].Key.overrideAcronym)
                {
                    temp = challengeList[i].Key.challengeName;
                }
                else
                {
                    temp = challengeList[i].Value ? $"No {temp}" : $"{temp} Allowed";
                }

                if (i != challengeList.Count - 1)
                {
                    result += $"{temp}, ";
                }
                else {
                    result += temp;
                }
            }
            
            return result;
        }



        public List<KeyValuePair<Challenge2, bool>> PickRandomChallenges(List<Challenge2> challengeList, bool restrict = true, int chance = 3000)
        {
            List<KeyValuePair<Challenge2, bool>> randChallenges = new List<KeyValuePair<Challenge2, bool>>();

            if (challenges.Count > 0)
            {
                foreach (Challenge2 challenge in challengeList) {
                    int randChance = ModuleHandler.rand.Next() % 10000;

                    if (randChance < 3000)
                    {
                        randChance = 0;
                    }
                    else {
                        int count = challenge.challenges.Count;

                        if (count == 0)
                        {
                            randChance = 0;
                        }
                        else {
                            randChance = 5000 / count;
                        }
                    }

                    if (ModuleHandler.rand.Next() % 10000 < chance)
                    {
                        KeyValuePair<Challenge2, bool> pair = new KeyValuePair<Challenge2, bool>(challenge, restrict);
                        randChallenges.Add(pair);
                        randChallenges = randChallenges.Concat(PickRandomChallenges(challenge.challenges, !restrict, randChance)).ToList();
                    }
                    else {
                        randChallenges = randChallenges.Concat(PickRandomChallenges(challenge.challenges, restrict, randChance)).ToList();
                    }
                }
            }

            return randChallenges;
        }



        public void LoadChallenges() {
            string filename = "Data/FFX Challenges.json";
            string contents = File.ReadAllText(filename);
            challenges = JsonConvert.DeserializeObject<List<Challenge2>>(filename);
        }

        public void SaveChallenges() {
            string filename = "Data/FFX Challenges.json";
            File.WriteAllText(filename, JsonConvert.SerializeObject(challenges, Formatting.Indented));
        }

        public void InitChallenges()
        {
            Challenge2 challenge0 = new Challenge2("Sphere Grid");
            challenge0.AddChallenge("Power Spheres");
            challenge0.AddChallenge("Mana Spheres");
            challenge0.AddChallenge("Speed Spheres");
            challenge0.AddChallenge("Ability Spheres");
            challenge0.AddChallenge("Fortune Spheres");
            challenge0.AddChallenge("Key Spheres");
            challenge0.challenges[5].AddChallenge("Level 1 Key Spheres", "LOKS");
            challenge0.challenges[5].AddChallenge("Level 2 Key Spheres", "LTKS");
            challenge0.challenges[5].AddChallenge("Level 3 Key Spheres", "LTKS");
            challenge0.challenges[5].AddChallenge("Level 4 Key Spheres", "LFKS");
            challenge0.AddChallenge("Purple Spheres");
            challenge0.AddChallenge("Yellow Spheres");
            challenge0.AddChallenge("Light Blue Spheres");
            challenge0.AddChallenge("Clear Spheres");
            Challenge2 challenge1 = new Challenge2("Summons");
            challenge1.AddChallenge("Optional Summons");
            challenge1.challenges[0].AddChallenge("Magus Sisters");
            challenge1.challenges[0].AddChallenge("Yojimbo");
            challenge1.challenges[0].AddChallenge("Anima");
            challenge1.AddChallenge("Storyline Summons");
            challenge1.challenges[1].AddChallenge("Valefor");
            challenge1.challenges[1].AddChallenge("Ifrit");
            challenge1.challenges[1].AddChallenge("Ixion");
            challenge1.challenges[1].AddChallenge("Shiva");
            challenge1.challenges[1].AddChallenge("Bahamut");
            Challenge2 challenge2 = new Challenge2("Customize");
            Challenge2 challenge3 = new Challenge2("Overdrives");
            challenge3.AddChallenge("Sword Play");
            challenge3.AddChallenge("Grand Summon");
            challenge3.AddChallenge("Fury");
            challenge3.AddChallenge("Bushido");
            challenge3.AddChallenge("Ronso Rage");
            challenge3.AddChallenge("Slots");
            challenge3.AddChallenge("Mix");
            Challenge2 challenge4 = new Challenge2("Escape");
            Challenge2 challenge5 = new Challenge2("No Encounters");
            Challenge2 challenge6 = new Challenge2("Blitzball");
            Challenge2 challenge7 = new Challenge2("Black Magic");
            challenge7.AddChallenge("Fire Spells");
            challenge7.challenges[0].AddChallenge("Fire");
            challenge7.challenges[0].AddChallenge("Fira");
            challenge7.challenges[0].AddChallenge("Firaga");
            challenge7.AddChallenge("Ice Spells");
            challenge7.challenges[1].AddChallenge("Blizzard");
            challenge7.challenges[1].AddChallenge("Blizzara");
            challenge7.challenges[1].AddChallenge("Blizzaga");
            challenge7.AddChallenge("Thunder Spells");
            challenge7.challenges[2].AddChallenge("Thunder");
            challenge7.challenges[2].AddChallenge("Thundara");
            challenge7.challenges[2].AddChallenge("Thundaga");
            challenge7.AddChallenge("Water Spells");
            challenge7.challenges[3].AddChallenge("Water");
            challenge7.challenges[3].AddChallenge("Watera");
            challenge7.challenges[3].AddChallenge("Waterga");
            challenge7.AddChallenge("Bio");
            challenge7.AddChallenge("Demi");
            challenge7.AddChallenge("Death");
            challenge7.AddChallenge("Drain");
            challenge7.AddChallenge("Osmose");
            challenge7.AddChallenge("Flare");
            challenge7.AddChallenge("Ultima");
            Challenge2 challenge8 = new Challenge2("White Magic");
            challenge8.AddChallenge("Healing Spells");
            challenge8.challenges[0].AddChallenge("Cure");
            challenge8.challenges[0].AddChallenge("Cura");
            challenge8.challenges[0].AddChallenge("Curaga");
            challenge8.challenges[0].AddChallenge("Regen");
            challenge8.AddChallenge("Buff Spells");
            challenge8.challenges[1].AddChallenge("Nul Spells");
            challenge8.challenges[1].challenges[0].AddChallenge("NulBlaze", "NB");
            challenge8.challenges[1].challenges[0].AddChallenge("NulShock", "NS");
            challenge8.challenges[1].challenges[0].AddChallenge("NulTide", "NT");
            challenge8.challenges[1].challenges[0].AddChallenge("NulFrost", "NF");
            challenge8.challenges[1].AddChallenge("Haste");
            challenge8.challenges[1].AddChallenge("Hastega");
            challenge8.challenges[1].AddChallenge("Shell");
            challenge8.challenges[1].AddChallenge("Protect");
            challenge8.challenges[1].AddChallenge("Reflect");
            challenge8.AddChallenge("Revival Spells");
            challenge8.challenges[2].AddChallenge("Life");
            challenge8.challenges[2].AddChallenge("Full-Life", "FL");
            challenge8.challenges[2].AddChallenge("Auto-Life", "AL");
            challenge8.AddChallenge("Scan");
            challenge8.AddChallenge("Esuna");
            challenge8.AddChallenge("Dispel");
            challenge8.AddChallenge("Holy");
            Challenge2 challenge9 = new Challenge2("Skills");
            challenge9.AddChallenge("Attack Skills");
            challenge9.challenges[0].AddChallenge("Dark Attack");
            challenge9.challenges[0].AddChallenge("Silence Attack");
            challenge9.challenges[0].AddChallenge("Sleep Attack");
            challenge9.challenges[0].AddChallenge("Delay Attack");
            challenge9.challenges[0].AddChallenge("Zombie Attack");
            challenge9.AddChallenge("Buster Skills");
            challenge9.challenges[1].AddChallenge("Dark Buster");
            challenge9.challenges[1].AddChallenge("Silence Buster");
            challenge9.challenges[1].AddChallenge("Sleep Buster");
            challenge9.challenges[1].AddChallenge("Delay Buster");
            challenge9.AddChallenge("Break Skills");
            challenge9.challenges[2].AddChallenge("Power Break");
            challenge9.challenges[2].AddChallenge("Magic Break");
            challenge9.challenges[2].AddChallenge("Armor Break");
            challenge9.challenges[2].AddChallenge("Mental Break");
            challenge9.challenges[2].AddChallenge("Full Break");
            challenge9.AddChallenge("Triple Foul");
            challenge9.AddChallenge("Mug");
            challenge9.AddChallenge("Quick Hit");
            Challenge2 challenge10 = new Challenge2("Specials");
            challenge10.AddChallenge("Flee");
            challenge10.AddChallenge("Steal");
            challenge10.AddChallenge("Use");
            challenge10.AddChallenge("Pray");
            challenge10.AddChallenge("Cheer");
            challenge10.AddChallenge("Aim");
            challenge10.AddChallenge("Focus");
            challenge10.AddChallenge("Reflex");
            challenge10.AddChallenge("Luck");
            challenge10.AddChallenge("Jinx");
            challenge10.AddChallenge("Lancet");
            challenge10.AddChallenge("Guard");
            challenge10.AddChallenge("Sentinel");
            challenge10.AddChallenge("Spare Change");
            challenge10.AddChallenge("Threaten");
            challenge10.AddChallenge("Provoke");
            challenge10.AddChallenge("Entrust");
            challenge10.AddChallenge("Copycat");
            challenge10.AddChallenge("Doublecast");
            challenge10.AddChallenge("Bribe");
            Challenge2 challenge11 = new Challenge2("Items");
            challenge11.AddChallenge("Healing Items");
            challenge11.AddChallenge("MP Restoring Items");
            challenge11.AddChallenge("Revival Items");
            challenge11.AddChallenge("Status Removing Items");
            Challenge2 challenge12 = new Challenge2("Default Weapons", "DW", true);
            Challenge2 challenge13 = new Challenge2("Default Armor", "DA", true);
            Challenge2 challenge14 = new Challenge2("Defend");
            Challenge2 challenge15 = new Challenge2("Attack Command");

            challenges.Add(challenge0);
            challenges.Add(challenge1);
            challenges.Add(challenge2);
            challenges.Add(challenge3);
            challenges.Add(challenge4);
            challenges.Add(challenge5);
            challenges.Add(challenge6);
            challenges.Add(challenge7);
            challenges.Add(challenge8);
            challenges.Add(challenge9);
            challenges.Add(challenge10);
            challenges.Add(challenge11);
            challenges.Add(challenge12);
            challenges.Add(challenge13);
            challenges.Add(challenge14);
        }

    }
}
