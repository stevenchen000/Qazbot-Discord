using Qazbot.LevelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.UserSystem
{
    [System.Serializable]
    class User
    {
        //basic user info
        public ulong id { get; set; }
        public string username { get; set; }
        public string discriminator { get; set; }
        public ulong colorRole { get; set; }

        //points and point calculations
        public double points { get; set; }
        public ulong totalWatchTime { get; set; }
        public double lastMessageTime { get; set; }

        public Stats stats { get; set; }
    }
}
