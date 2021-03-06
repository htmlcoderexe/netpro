﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Collections.Concurrent;

namespace NetMessaging
{
    /// <summary>
    /// The Messenger allows communication between hosts and services.
    /// </summary>
    public class Messenger
    {
        public IPAddress BoundIP;
        public short BoundPort;
        public Guid ID;
        private Dictionary<Guid, IPAddress> NetworkMap;
        private Dictionary<Guid, short> LocalMap;
        private ConcurrentQueue<Message> Inbox;
        private ConcurrentQueue<Message> Outbox;
        public Action<Message> ProcessMessage;

        private System.Threading.Thread InboxThread;
        private System.Threading.Thread OutboxThread;

        /// <summary>
        /// Initializes a new Messenger instance.
        /// </summary>
        public Messenger()
        {
            InboxThread = new System.Threading.Thread(ProcessInbox);
            OutboxThread = new System.Threading.Thread(ProcessOutbox);
            LocalMap = new Dictionary<Guid, short>();
            NetworkMap = new Dictionary<Guid, IPAddress>();
            Inbox  = new ConcurrentQueue<Message>();
            Outbox = new ConcurrentQueue<Message>();
        }
        /// <summary>
        /// Begin listening for incoming communications
        /// </summary>
        public void Start()
        {
            InboxThread.Start();
            OutboxThread.Start();
        }
        /// <summary>
        /// Stop listening and cleanup threads.
        /// </summary>
        public void Stop()
        {
            InboxThread.Abort();
            OutboxThread.Abort();
        }
        public short GainPort()
        {
            short result;
            System.Net.Sockets.TcpClient c = new System.Net.Sockets.TcpClient();
            c.Connect(IPAddress.Loopback, OperationConstants.DispatcherPort);
            result = (short)(c.Client.LocalEndPoint as IPEndPoint).Port;
            c.Close();
            return result;
        }
        /// <summary>
        /// Send a message
        /// </summary>
        /// <param name="Message">A message to send</param>
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

        public void Broadcast(Message Message)
        {

        }

        private void ProcessInbox()
        {
            while(true)
            {
                Message CurrentMessage;
                while (Inbox.TryDequeue(out CurrentMessage))
                {
                    if (CurrentMessage.Header.Type == (byte)Message.MessageType.Control)
                        ProcessControlMessage(CurrentMessage);
                    else
                        ProcessMessage?.Invoke(CurrentMessage);
                }
                System.Threading.Thread.Sleep(10);
            }
        }
        private void ProcessOutbox()
        {

        }

        private void ProcessControlMessage(Message Message)
        {

        }
        

        private void Transmit(Message Message, short Port, IPAddress IP)
        {

        }

        
    }
}
