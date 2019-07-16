using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qazbot.CommandSystem;

namespace Qazbot
{
    public class BotManager
    {
        public DiscordClient client { get; set; }
        public CommandManager commands { get; set; }
        

        public BotManager() {

        }

    }
}
