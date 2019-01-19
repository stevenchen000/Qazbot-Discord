using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Qazbot.AnimationSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qazbot.FF9Nobles
{
    class NoblesCommand
    {
        public static int rounds = 10;
        public static Dictionary<string, Keyframe> inputs;
        public static double roundLength = 1.5;
        public static double bonusTime = 1;

        private bool playing = false;

        public string currentUser { get; set; }
        private string currentAction { get; set; }

        public NoblesCommand() {
            
        }

        [Command("nobles")]
        [Description("Try to impress the nobles")]
        public async Task StartGame(CommandContext context) {
            if (context.Channel.Name == "impress-nobles" && !playing)
            {
                Init();
                playing = true;

                currentUser = context.Member.Username;
                DiscordMember member = context.Member;
                string username = member.Nickname == null ? currentUser : member.Nickname;

                await context.RespondAsync($"{username} has started performing I Want To Be Your Canary in front of 100 nobles! How many nobles can they impress?");
                Thread.Sleep(1000);
                DiscordMessage message = await context.RespondAsync("The play will begin in 3...");
                Thread.Sleep(1000);
                await message.ModifyAsync("The play will begin in 2...");
                Thread.Sleep(1000);
                await message.ModifyAsync("The play will begin in 1...");
                Thread.Sleep(1000);
                await message.ModifyAsync("Begin!");

                await PlayGame(context);
                playing = false;
            }
        }

        public async Task PlayGame(CommandContext context) {
            int currentRound = 0;
            DateTime roundStart = DateTime.Now;
            int score = 0;
            string input = GetRandomInput();

            DiscordMessage message = await context.RespondAsync(inputs[input].RenderFrame());

            QazbotMain.discord.MessageCreated += GetFirstInput;

            while (currentRound < rounds) {
                if (currentAction != null || (DateTime.Now - roundStart).TotalSeconds > roundLength) {
                    if (currentAction == input)
                    {
                        score += 5;

                        if ((DateTime.Now - roundStart).TotalSeconds < bonusTime)
                        {
                            score += 5;
                        }
                    }
                    currentRound++;

                    
                    
                    await message.ModifyAsync(inputs[""].RenderFrame());
                    Thread.Sleep(1000);

                    roundStart = DateTime.Now;
                    currentAction = null;

                    if (currentRound < rounds)
                    {
                        input = GetRandomInput();

                        await message.ModifyAsync(inputs[input].RenderFrame());
                    }
                    else {
                        await message.DeleteAsync();
                    }
                }

                
            }

            QazbotMain.discord.MessageCreated -= GetFirstInput;
            
            DiscordMember member = context.Member;
            string username = member.Nickname == null ? currentUser : member.Nickname;

            string result = $"{username} impressed {score} nobles! ";

            if (score < 50)
            {
                result += "Wow, who taught you how to act? 😏";
            }
            else if (score < 70)
            {
                result += "Not bad...Not great, but not bad at least <:DOOD: 339574892083019779 > ";
            }
            else if (score < 100)
            {
                result += "Wow, you're pretty good at this <:MikuStare:319275787222253588>";
            }
            else {
                result += "P E R F E C T S C O R E ! <:PagChomp:322477440641531904>";
            }

            await context.RespondAsync(result);
        }

        public async Task GetFirstInput(MessageCreateEventArgs args) {
            if (args.Channel.Name == "impress-nobles") {
                if (args.Message.Author.Username == currentUser) {
                    currentAction = args.Message.Content.Substring(0, 1).ToLower();
                }

                if (args.Message.Author.Username != QazbotMain.discord.CurrentUser.Username)
                {
                    await args.Message.DeleteAsync();
                }
            }
        }

        public string GetRandomInput() {
            string inputs = "wasd";
            int rand = ModuleHandler.rand.Next() % 4;
            return inputs.Substring(rand, 1);
        }

        private void Init()
        {
            inputs = new Dictionary<string, Keyframe>();
            inputs["w"] = new Keyframe(0);
            inputs["w"].AddElement(new Emote(8.25f, 0, ":regional_indicator_w:"));
            inputs["w"].AddElement(new Emote(0, 3, ":Kuuhaku:"));
            inputs["a"] = new Keyframe(0);
            inputs["a"].AddElement(new Emote(0f, 1, ":regional_indicator_a:"));
            inputs["a"].AddElement(new Emote(0, 3, ":Kuuhaku:"));
            inputs["s"] = new Keyframe(0);
            inputs["s"].AddElement(new Emote(8.25f, 2, ":regional_indicator_s:"));
            inputs["s"].AddElement(new Emote(0, 3, ":Kuuhaku:"));
            inputs["d"] = new Keyframe(0);
            inputs["d"].AddElement(new Emote(17f, 1, ":regional_indicator_d:"));
            inputs["d"].AddElement(new Emote(0, 3, ":Kuuhaku:"));
            inputs[""] = new Keyframe(0);
            inputs[""].AddElement(new Emote(0, 0, ":Kuuhaku:"));
            inputs[""].AddElement(new Emote(0, 3, ":Kuuhaku:"));

        }

    }
}
