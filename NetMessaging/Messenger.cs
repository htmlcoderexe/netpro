using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace NetMessaging
{
    public class Messenger
    {
        public IPAddress BoundIP;
        public Guid ID;
        public Dictionary<Guid, IPAddress> NetworkMap;
        public Dictionary<Guid, short> LocalMap;
        public Queue<Message> Inbox;
        public Queue<Message> Outbox;

        private System.Threading.Thread InboxThread;
        private System.Threading.Thread OutboxThread;

        public Messenger()
        {
            InboxThread = new System.Threading.Thread(ProcessInbox);
            OutboxThread = new System.Threading.Thread(ProcessOutbox);
            LocalMap = new Dictionary<Guid, short>();
            NetworkMap = new Dictionary<Guid, IPAddress>();
            Inbox = new Queue<Message>();
            Outbox = new Queue<Message>();
        }

        public void Start()
        {
            InboxThread.Start();
            OutboxThread.Start();
        }

        public void Stop()
        {
            InboxThread.Abort();
            OutboxThread.Abort();
        }

        public void Send(Message Message)
        {
            //message to self
            if(Message.Header.Destination==this.ID)
            {
                this.Inbox.Enqueue(Message);
                return;
            }
            //message to a service on this host
            if(LocalMap.ContainsKey(Message.Header.Destination))
            {
                Transmit(Message, LocalMap[Message.Header.Destination], IPAddress.Loopback);
                return;
            }
            //message to a service on a known host
            if(NetworkMap.ContainsKey(Message.Header.Destination))
            {
                Transmit(Message, OperationConstants.DispatcherPort, NetworkMap[Message.Header.Destination]);
                return;
            }
            //defer to discovery
            Outbox.Enqueue(Message);
        }

        private void ProcessInbox()
        {

        }
        private void ProcessOutbox()
        {

        }

        public void Transmit(Message Message, short Port, IPAddress IP)
        {

        }
    }
}
