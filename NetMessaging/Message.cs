using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMessaging
{
    public abstract class Message
    {
        public enum MessageType
        {
            Control,
            Service,
            Info,
            Link
        }
        public MessageHeader Header;
        public byte[] Payload;
        public virtual void Unpack()
        {

        }
        public abstract byte[] Pack();
        public byte[] GetBytes()
        {
            Header.Length = Payload.Length;
            Header.TimeStamp = DateTime.UtcNow.ToFileTimeUtc();
            byte[] header = Header.GetBytes();
            int fulllength = MessageHeader.Size + Payload.Length;
            byte[] result = new byte[fulllength];
            Array.Copy(header, 0, result, 0, MessageHeader.Size);
            this.Payload=this.Pack();
            Array.Copy(Payload, 0, result, MessageHeader.Size, Payload.Length);
            return result;
        }
    }
}
