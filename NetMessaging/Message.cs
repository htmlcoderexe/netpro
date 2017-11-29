using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMessaging
{
    public class Message
    {
        public enum MessageType
        {
            Service,
            Info,
            Link
        }
        public MessageHeader Header;
        public byte[] Payload;
        public virtual void Unpack()
        {

        }
        public virtual void Pack()
        {

        }
        public byte[] GetBytes()
        {

        }
    }
}
