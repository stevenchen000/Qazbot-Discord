using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using Qazbot.AnimationSystem;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.Threading;

public class Animation
{
    //width of emotes in spaces
    public static float emoteWidth = 8.25f;
    public static float emoteWidthMini = 5.875f;

    //maximum number of emotes before message shrinks
    public static int maxEmotes = 27;

    //maximum number of characters
    public static int maxCharacters = 2000;

    //max width and height of message (in units of emotes)
    public static int width = 120;
    public static int height = 10;

    public List<Keyframe> keyframes { get; set; } = new List<Keyframe>();
    public int loops { get; set; } = 1;

    private DiscordMessage messageWindow;

	public Animation()
	{
        
	}

    public Animation(int loops) {
        this.loops = loops;
    }

    public string StartAnimation() {
        return keyframes[0].RenderFrame();
    }

    public async Task PlayAnimation(DiscordMessage message) {
        messageWindow = message;

        for (int i = 1; i < keyframes.Count * loops; i++) {
            Thread.Sleep((int)(keyframes[(i-1)%keyframes.Count].time * 1000));
            await message.ModifyAsync(keyframes[i%keyframes.Count].RenderFrame());
        }
    }

    public void AddKeyframe(Keyframe frame, int index = -1) {
        if (index >= 0)
        {
            keyframes.Insert(index, frame);
        }
        else {
            keyframes.Add(frame);
        }
    }
}
