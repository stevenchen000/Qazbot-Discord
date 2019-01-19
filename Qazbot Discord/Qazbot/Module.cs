using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Qazbot
{
    public abstract class Module
    {
        protected string filename { get; set; }

        public abstract void SaveData();
        public abstract void LoadData();
    }
}
