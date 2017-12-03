using NetMessaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Service
    {
        public Messenger Messenger;

        public Service()
        {
            this.Messenger = new Messenger();
        }

        public void Start()
        {
            this.Messenger.Start();
        }

        public void Stop()
        {
            this.Messenger.Stop();
        }

        public void RegisterService()
        {

        }
    }
}
