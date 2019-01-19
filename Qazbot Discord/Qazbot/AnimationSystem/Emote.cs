using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.AnimationSystem{
    public class Emote : AnimationText
    {
        public DiscordEmoji emoji;

        public Emote(string emojiName) {
            X = 0;
            Y = 0;

            SetEmojiInfo(emojiName);
        }

        public Emote(float x, int y, string emojiName) {
            X = x;
            Y = y;

            SetEmojiInfo(emojiName);
        }

        public Emote(DiscordEmoji emoji)
        {
            X = 0;
            Y = 0;
            this.emoji = emoji;
        }

        public Emote(float x, int y, DiscordEmoji emoji)
        {
            X = x;
            Y = y;
            this.emoji = emoji;
        }

        public void SetEmojiInfo(string emojiName) {
            emoji = DiscordEmoji.FromName(QazbotMain.discord, $":{emojiName.Trim(':')}:");

            if (emoji.Id != 0)
            {
                Text = $"<:{emoji.Name}:{emoji.Id}>";
            }
            else {
                Text = emoji.Name;
            }
        }
    }
}