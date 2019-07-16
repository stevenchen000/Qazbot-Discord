using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.CommandSystem
{
    public class Command
    {

        public string commandName { get; set; }
        public List<string> aliases { get; set; }
        public CommandBehaviour behaviour { get; set; }

        /*
         Should take in:
            user
            channel
            list of args
             */


        public async Task Execute(string message, MessageCreateEventArgs args) {
            await behaviour.Execute(message, args);
        }


    }
}
