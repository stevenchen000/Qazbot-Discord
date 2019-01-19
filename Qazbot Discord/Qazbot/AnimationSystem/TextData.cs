using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qazbot.AnimationSystem
{
    class TextData
    {
        public static Dictionary<char, float> textData = new Dictionary<char, float>();

        public static void init() {
            textData['a'] = 30 / 11f;
            textData['b'] = 25 / 10f;
        }
    }
}
