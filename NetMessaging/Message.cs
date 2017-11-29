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
            byte[] header = Header.GetBytes();
            int fulllength = MessageHeader.Size + Payload.Length;
            byte[] result = new byte[fulllength];
            Array.Copy(header, 0, result, 0, MessageHeader.Size);
            Array.Copy(Payload, 0, result, MessageHeader.Size, Payload.Length);
            return result;
        }
    }
}
