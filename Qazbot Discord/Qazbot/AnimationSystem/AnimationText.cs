using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.AnimationSystem
{
    public class AnimationText
    {
        public string Text { get; set; }
        public float X { get; set; }
        public int Y { get; set; }

        public float textSize { get; protected set; }

        public AnimationText() { 
            X = 0;
            Y = 0;
            Text = "";
            textSize = 0;
        }

        public AnimationText(float x, int y, string text) {
            X = x;
            Y = y;
            Text = text;
            textSize = GetTextSize(text);
        }

        public float GetTextSize(string text) {
            float textSize = text.Length/2; //random estimate, units of emotes

            //calculate text size based

            return textSize;
        }
    }
}
