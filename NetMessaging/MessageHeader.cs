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
        public Guid Source;
        public Guid Destination;
        public int Length;
        public long TimeStamp;
    }
    public byte[] GetBytes()
    {
        byte[] result;
        
        return result;
    }
}
