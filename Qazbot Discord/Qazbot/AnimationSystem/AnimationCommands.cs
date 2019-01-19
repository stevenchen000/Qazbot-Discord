using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Qazbot.AnimationSystem
{
    public class AnimationCommands
    {
        [Command("testcomm")]
        public async Task CreateAnimationCommand(CommandContext context)
        {

            await context.Message.RespondAsync("test");
        }

        public async Task AddKeyframe(CommandContext context) {

        }

        public async Task DeleteAnimationCommand(CommandContext context) {

        }
        
    }
}
