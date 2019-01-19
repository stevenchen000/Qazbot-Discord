using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Qazbot;
using Qazbot.ShadesOfMagick;
using DSharpPlus.Entities;
using System.Threading;
using DSharpPlus.CommandsNext.Converters;
using Qazbot.AnimationSystem;
using Qazbot.FFXChallenge;
using Newtonsoft.Json;
using System.IO;
using Qazbot.TenYears;

public class MyCommands
{
    [Command("test")]
    [Description("Just a test command, don't mind me")]
    public async Task TestCommand(CommandContext context)
    {
        DiscordMessage message = await context.RespondAsync("test");
        Thread.Sleep(0);

        DiscordEmojiConverter converter = new DiscordEmojiConverter();
        DiscordEmoji emoji = DiscordEmoji.FromName(QazbotMain.discord, ":DOOD:");

        await message.ModifyAsync($"nvm, untest <:{emoji.Name}:{emoji.Id}>");
    }

    [Command("shadesofblack")]
    [Description("Cast a random Black Magick at the target")]
    [Aliases("sob")]
    public async Task SobCommand(CommandContext context) {
        if (context.Channel.Name == "bot-commands")
        {
            SpellHandler sob = (SpellHandler)ModuleHandler.modules["shades of black"];

            string user = context.Member.Nickname == null ? context.Member.Username : context.Member.Nickname;
            int cutoff = context.Message.Content.IndexOf(' ') + 1;

            string target = cutoff == 0 ? user : context.Message.Content.Substring(cutoff);

            await context.RespondAsync(sob.CastSpell(user, target));
        }
    }

    [Command("tintsofwhite")]
    [Description("Cast a random White Magick at the target")]
    [Aliases("tow")]
    public async Task TowCommand(CommandContext context)
    {
        if (context.Channel.Name == "bot-commands")
        {
            SpellHandler tow = (SpellHandler)ModuleHandler.modules["tints of white"];

            string user = context.Member.Nickname == null ? context.Member.Username : context.Member.Nickname;
            int cutoff = context.Message.Content.IndexOf(' ') + 1;

            string target = cutoff == 0 ? user : context.Message.Content.Substring(cutoff);

            await context.RespondAsync(tow.CastSpell(user, target));
        }
    }

    [Command("huesofgreen")]
    [Description("Cast a random Green Magick at the target")]
    [Aliases("hog")]
    public async Task HogCommand(CommandContext context)
    {
        if (context.Channel.Name == "bot-commands")
        {
            SpellHandler hog = (SpellHandler)ModuleHandler.modules["hues of green"];

            string user = context.Member.Nickname == null ? context.Member.Username : context.Member.Nickname;
            int cutoff = context.Message.Content.IndexOf(' ') + 1;

            string target = cutoff == 0 ? user : context.Message.Content.Substring(cutoff);

            await context.RespondAsync(hog.CastSpell(user, target));
        }
    }

    [Command("runesofarcane")]
    [Description("Cast a random Black Magick at the target")]
    [Aliases("roa")]
    public async Task RoaCommand(CommandContext context)
    {
        if (context.Channel.Name == "bot-commands")
        {
            SpellHandler sob = (SpellHandler)ModuleHandler.modules["runes of arcane"];

            string user = context.Member.Nickname == null ? context.Member.Username : context.Member.Nickname;
            int cutoff = context.Message.Content.IndexOf(' ') + 1;

            string target = cutoff == 0 ? user : context.Message.Content.Substring(cutoff);

            await context.RespondAsync(sob.CastSpell(user, target));
        }
    }

    [Command("annulsoftime")]
    [Description("Cast a random Black Magick at the target")]
    [Aliases("aot")]
    public async Task AotCommand(CommandContext context)
    {
        if (context.Channel.Name == "bot-commands")
        {
            SpellHandler sob = (SpellHandler)ModuleHandler.modules["annuls of time"];

            string user = context.Member.Nickname == null ? context.Member.Username : context.Member.Nickname;
            int cutoff = context.Message.Content.IndexOf(' ') + 1;

            string target = cutoff == 0 ? user : context.Message.Content.Substring(cutoff);

            await context.RespondAsync(sob.CastSpell(user, target));
        }
    }

    [Command("spin")]
    [Description("Make DOOD spin")]
    public async Task SpinCommand(CommandContext context) {
        Animation anim = new Animation(5);
        Keyframe frame1 = new Keyframe(1.5f);
        Keyframe frame2 = new Keyframe(1.5f);

        frame1.AddElement(new Emote(":DOOD:"));
        frame2.AddElement(new Emote(":DOOD2"));

        anim.AddKeyframe(frame1);
        anim.AddKeyframe(frame2);

        DiscordMessage message = await context.Message.RespondAsync(anim.StartAnimation());
        await anim.PlayAnimation(message);
    }

    [Command("dodgebullets")]
    [Description("Make DOOD dodge bullets")]
    [Aliases("bullets")]
    public async Task BulletsCommand(CommandContext context) {
        Animation anim = new Animation(3);
        Keyframe frame1 = new Keyframe(1.5f);
        Keyframe frame2 = new Keyframe(1.5f);
        Keyframe frame3 = new Keyframe(1.5f);
        Keyframe frame4 = new Keyframe(1.5f);
        Keyframe frame5 = new Keyframe(1.5f);

        frame1.AddElement(new Emote(0, 1, ":DOOD:"));
        frame1.AddElement(new Emote(38.25f, 1, ":gun:"));
        frame1.AddElement(new Emote(0, 3, ":Kuuhaku"));

        frame2.AddElement(new Emote(0, 0, ":DOOD:"));
        frame2.AddElement(new Emote(30, 1, ":boom:"));
        frame2.AddElement(new Emote(38.25f, 1, ":gun:"));
        frame2.AddElement(new Emote(0, 3, ":Kuuhaku"));

        frame3.AddElement(new Emote(0, 2, ":DOOD:"));
        frame3.AddElement(new Emote(30, 0, ":boom:"));
        frame3.AddElement(new Emote(38.25f, 0, ":gun:"));
        frame3.AddElement(new Emote(0, 3, ":Kuuhaku"));

        frame4.AddElement(new Emote(0, 0, ":DOOD:"));
        frame4.AddElement(new Emote(30, 2, ":boom:"));
        frame4.AddElement(new Emote(38.25f, 2, ":gun:"));
        frame4.AddElement(new Emote(0, 3, ":Kuuhaku"));

        frame5.AddElement(new Emote(0, 2, ":DOOD:"));
        frame5.AddElement(new Emote(30, 0, ":boom:"));
        frame5.AddElement(new Emote(38.25f, 0, ":gun:"));
        frame5.AddElement(new Emote(0, 3, ":Kuuhaku"));

        anim.AddKeyframe(frame1);
        anim.AddKeyframe(frame2);
        anim.AddKeyframe(frame3);
        anim.AddKeyframe(frame4);

        DiscordMessage message = await context.Message.RespondAsync(anim.StartAnimation());

        await anim.PlayAnimation(message);
    }

    [Command("feed")]
    [Description("Feed Pepe")]
    public async Task FeedCommand(CommandContext context) {
        if (context.Channel.Name != "bot-commands") {
            Console.WriteLine("Wrong Channel");
            return;
        }
        Console.WriteLine("Feeding");
        string message = context.Message.Content;
        Console.WriteLine("Got message");
        int offset = message.IndexOf(' ') + 1;
        message = message.Substring(offset);
        Console.WriteLine($"Got substring: {message}");

        //Emote emoji = new Emote(message);
        //DiscordEmoji emoji = DiscordEmoji.
        Console.WriteLine(DiscordEmoji.FromUnicode(QazbotMain.discord, message).Id);
        Console.WriteLine(DiscordEmoji.FromUnicode(QazbotMain.discord, message).Name);
        Animation anim = new Animation();
        Keyframe frame1 = new Keyframe(1.5f);
        Keyframe frame2 = new Keyframe(1.5f);
        Keyframe frame3 = new Keyframe(1.5f);
        Keyframe frame4 = new Keyframe(1.5f);
        Keyframe frame5 = new Keyframe(1.5f);
    }

    [Command("ffxchallenge")]
    [Description("Get a random FFX Challenge")]
    public async Task ChallengeCommand(CommandContext context) {
        /*ChallengeManager cm = new ChallengeManager();
        DiscordMember member = context.Member;

        string username = member.Nickname == null ? member.Username : member.Nickname;

        await context.Message.RespondAsync(cm.CreateChallenge(username));*/
        ChallengeManager2 cm = new ChallengeManager2();
        DiscordMember member = context.Member;

        string username = member.Nickname == null ? member.Username : member.Nickname;

        await context.RespondAsync(cm.CreateChallenge(username));
    }

    [Command("magemasher")]
    [Description("Steal a Mage Masher")]
    public async Task MageMasherCommand(CommandContext context) {
        int attempts = 0;
        bool masher = false;

        while (!masher) {
            attempts++;

            int rand = ModuleHandler.rand.Next() % 16;

            if (rand == 0) {
                masher = true;
            }
        }

        string result = "";
        DiscordMember member = context.Member;
        string username = member.Nickname == null ? member.Username : member.Nickname;

        if (attempts == 1)
        {
            result = $"{username} stole from the Masked Man and got the Mage Masher first try! {new Emote(":PagChomp:").Text}";
        }
        else {
            result = $"{username} stole from the Masked Man and got the Mage Masher in {attempts} tries.";
        }

        await context.RespondAsync(result);
    }



    [Command("tenyears")]
    public async Task TenYearsAgoCommand(CommandContext context) {
        DiscordMember member = context.Member;
        string username = member.Nickname == null ? member.Username : member.Nickname;
        string action = context.Message.Content;
        action = action.Substring(10);

        string response = TenYears.TenYearsAgo(username, action);

        await context.RespondAsync(response);
    }
}

