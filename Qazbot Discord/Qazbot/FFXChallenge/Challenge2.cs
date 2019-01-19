using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.FFXChallenge
{
    class Challenge2
    {
        public string challengeName { get; set; }
        public List<Challenge2> challenges = new List<Challenge2>();
        public string challengeAcronym { get; set; }
        public bool overrideAcronym = false;


        


        public Challenge2(string challengeName, string challengeAcronym = null, bool acronymOverride = false)
        {
            this.challengeName = challengeName;
            if (challengeAcronym == null)
            {
                this.challengeAcronym = GetAcronym(challengeName);
            }
            else {
                this.challengeAcronym = challengeAcronym;
            }

            this.overrideAcronym = acronymOverride;
        }

        public void AddChallenge(string challengeName, string challengeAcronym = null, bool acronymOverride = false) {
            challenges.Add(new Challenge2(challengeName, challengeAcronym, acronymOverride));
        }

        public string GetAcronym(string challenge) {
            string result = "";

            foreach (string word in challenge.Split(' ')) {
                result += word.Substring(0, 1).ToUpper();
            }

            return result;
        }

    }
}

