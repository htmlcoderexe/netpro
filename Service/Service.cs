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
        public Guid ID;
        public short LocalPort;
        private bool isRegistered;
        public Service()
        {
            this.ID = GetGuid();
            this.Messenger = new Messenger
            {
                ID = this.ID
            };
        }

        public void Start()
        {
            this.Messenger.Start();
            RegisterService();
        }

        public void Stop()
        {
            this.Messenger.Stop();
        }

        public void RegisterService()
        {
            if (isRegistered)
                return;
            ServiceMessages.RegisterService RegisterMessage = new ServiceMessages.RegisterService();
            MessageHeader h = new MessageHeader()
            {
                Type = (byte)Message.MessageType.Service,
                Subtype = Messages.RegisterService,
                Destination = Guid.Empty,
                Source = this.ID
                
            };
            RegisterMessage.Header = h;
            RegisterMessage.LocalPort = Messenger.GainPort();
            this.LocalPort = RegisterMessage.LocalPort;
            RegisterMessage.ServiceID = this.ID;
            Messenger.Send(RegisterMessage);
        }

        private Guid GetGuid(bool ForceRefresh=false)
        {
            //TODO: persistent GUID
            return Guid.NewGuid();
        }
    }
}
