using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.AnimationSystem
{
    public class Keyframe
    {
        public List<AnimationText> elements = new List<AnimationText>();
        public float time { get; set; }

        public Keyframe(float time) {
            this.time = time;
        }

        public string RenderFrame() {
            string result = "";
            
            //current positions
            float currX = 0;
            int currY = 0;

            //used to make sure floating point positions are handled properly
            int currXDisplay = 0;

            //check the size of emotes
            float emoteSize = CheckIfEmotesAreLarge() ? Animation.emoteWidth : Animation.emoteWidthMini;

            //if the first element isn't at (0,0), add an emoji so that the frame still works
            if (elements[0].X != 0 || elements[0].Y != 0) {
                result += new Emote(":Kuuhaku:").Text;
                currX += emoteSize;
                currXDisplay += (int)emoteSize;
            }
            
            //loop through each element adding onto the text
            foreach (AnimationText element in elements) {
                if (element.GetType() == typeof(Emote))
                {
                    //calculate the change in X and Y positions
                    int deltaY = element.Y - currY;
                    float deltaX = 0;

                    if (deltaY == 0)
                    {
                        deltaX = element.X - currX;
                    }
                    else {
                        deltaX = element.X;
                        currX = 0;
                        currXDisplay = 0;
                    }

                    //make sure there are no negatives (will happen if things overlap)
                    if (deltaX < 0) {
                        deltaX = 0;
                    }

                    //adds a new line for every new Y
                    for (int i = 0; i < deltaY; i++) {
                        result += "\n";
                    }

                    //shifts over one space per X
                    int deltaXDisplay = (int)(currX + deltaX - currXDisplay);
                    for (int i = 0; i < deltaXDisplay; i++) {
                        result += " ";
                    }

                    //add emote
                    result += element.Text;

                    //update current coordinates
                    currY += deltaY;
                    currX += deltaX + emoteSize;
                    currXDisplay += deltaXDisplay + (int)emoteSize;
                }
                else {

                }
            }

            return result;
        }

        public void AddElement(AnimationText element) {
            if (element.textSize + element.X <= Animation.width) {
                for (int i = 0; i < elements.Count; i++) {
                    if (elements[i].Y > element.Y){
                        elements.Insert(i, element);
                        return;
                    }
                    else if (elements[i].Y == element.Y){
                        if (elements[i].X > element.X)
                        {
                            elements.Insert(i, element);
                            return;
                        }
                    }
                }
                elements.Add(element);
            }
        }

        public void RemoveElement(int index) {
            elements.RemoveAt(index);
        }

        private bool CheckIfEmotesAreLarge() {
            bool result = true;
            
            if (elements.Count > Animation.maxEmotes)
            {
                //emotes are small if too many emotes
                result = false;
            }
            else {
                //emotes are small if there's any text at all
                foreach (AnimationText element in elements) {
                    if (element.GetType() != typeof(Emote)) {
                        if (element.Text.Trim(' ') != "")
                        {
                            result = false;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
