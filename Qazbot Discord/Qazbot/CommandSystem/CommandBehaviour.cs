using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.CommandSystem
{
    public abstract class CommandBehaviour
    {
        //Should take some sort of context from the user
        public virtual async Task Execute(string message, MessageCreateEventArgs args) { }

    }
}
