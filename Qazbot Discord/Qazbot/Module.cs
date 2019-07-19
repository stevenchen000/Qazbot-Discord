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

        
        public virtual void OnReceiveMessage() { }
        public virtual void OnMessageEdited() { }
        public virtual void OnChannelCreated() { }
        public virtual void OnChannelDeleted() { }
        public virtual void OnChannelPinsUpdated() { }
        public virtual void OnChannelUpdated() { }


        public abstract void SaveData();
        public abstract void LoadData();
    }
}
