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
        public abstract void Execute();

    }
}
