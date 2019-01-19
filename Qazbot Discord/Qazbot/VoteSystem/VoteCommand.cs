using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Qazbot.AnimationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.VoteSystem
{
    class VoteCommand
    {

        
        VoteHandler voter = new VoteHandler();
        DiscordMessage pollMessage;
        List<DiscordEmoji> optionEmojis = new List<DiscordEmoji>();

        [Command("startvote")]
        [Description("Starts the vote")]
        public async Task StartVoteCommand(CommandContext command) {

            if (voter.OpenVotes())
            {
                List<DiscordEmoji> emojisList = command.Guild.Emojis.ToList<DiscordEmoji>();
                optionEmojis = new List<DiscordEmoji>();
                string message = "Voting has started!\n";
                message += $"\n{voter.pollTitle}";

                for(int i = optionEmojis.Count; i < voter.options.Count; i++) {
                    int rand = Qazbot.ModuleHandler.rand.Next() % emojisList.Count;
                    DiscordEmoji newEmoji = emojisList[rand];
                    message += $"\n{new Emote(newEmoji.Name).Text}: {voter.options[i]}";
                    optionEmojis.Add(newEmoji);
                    emojisList.RemoveAt(rand);
                }

                pollMessage = await command.RespondAsync(message);
            }
        }

        

        [Command("addoption")]
        [Description("Adds and option to the vote")]
        public async Task AddOptionCommand(CommandContext command) {
            string option = ModuleHandler.GetCommandArgs(command.Message.Content);
            voter.AddOption(option);
        }

        [Command("addemoji")]
        public async Task AddEmojiCommand(CommandContext context) {
            string emoji = ModuleHandler.GetCommandArgs(context.Message.Content);
            optionEmojis.Add(DiscordEmoji.FromName(context.Client, emoji));
        }


        [Command("polltitle")]
        public async Task PollTitleCommand(CommandContext command) {
            string title = ModuleHandler.GetCommandArgs(command.Message.Content);
            voter.pollTitle = title;
        }


        [Command("endvote")]
        public async Task EndVoteCommand(CommandContext command) {
            await TallyVotes();
            voter.StopVote();
            string result = voter.AnnounceWinner();
            voter = new VoteHandler();

            await command.RespondAsync(result);
        }



        private async Task TallyVotes()
        {
            for(int i = 0; i < optionEmojis.Count; i++) {
                IReadOnlyList<DiscordUser> voters = await pollMessage.GetReactionsAsync(optionEmojis[i]);
                foreach (DiscordUser vote in voters) {
                    voter.Vote(vote.Id.ToString() + i.ToString(), i);
                }
            }

            return;
        }
    }
}
