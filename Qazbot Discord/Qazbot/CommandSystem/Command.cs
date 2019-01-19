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

        public void Call() {
            behaviour.Execute();
        }


    }
}
