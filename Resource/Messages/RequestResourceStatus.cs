using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Messages
{
    public class RequestResourceStatus : NetMessaging.Message
    {
        public Guid ResourceID;
        public override byte[] Pack()
        {
            byte[] result = ResourceID.ToByteArray();
           // Array.Copy(, 0, result, 0, 16);
            return result;
        }
        public RequestResourceStatus(Guid ResourceID, bool ExtendedInfo)
        {
             this.ResourceID = ResourceID;
            this.Header.Type = (byte)NetMessaging.Message.MessageType.Service;
            this.Header.Subtype = (byte)Service.Messages.ResourceRequestStatus;
        }
    }
}
