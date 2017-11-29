using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMessaging
{

    public struct MessageHeader
    {
        public byte Type;
        public byte Subtype;
        public Guid Destination;
        public Guid Source;
        public int Length;
        public long TimeStamp;
        public const int Size= 46;
        public byte[] GetBytes()
        {
            byte[] result;
           int i = 0;
            result = new byte[Size];
            result[i] = Type;
            i++;
            result[i] = Subtype;
            i++;
            Array.Copy(Destination.ToByteArray(), 0, result, i, 16);
            i += 16;
            Array.Copy(Source.ToByteArray(), 0, result, i, 16);
            i += 16;
            Array.Copy(BitConverter.GetBytes(Length), 0, result, i, 4);
            i += 4;
            Array.Copy(BitConverter.GetBytes(TimeStamp), 0, result, i, 8);
           // i += 8;

            return result;
        }
    }
}
