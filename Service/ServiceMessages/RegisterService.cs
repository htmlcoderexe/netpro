using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMessaging;

namespace Service.ServiceMessages
{
    public class RegisterService : NetMessaging.Message
    {
        public Guid ServiceID;
        public short LocalPort;
        public override byte[] Pack()
        {
            byte[] result = new byte[16 + 2];
            Array.Copy(ServiceID.ToByteArray(), 0, result, 0, 16);
            Array.Copy(BitConverter.GetBytes(LocalPort), 0, result, 16, 2);
            return result;
        }
        public RegisterService() : base()
        {

        }
        public RegisterService(NetMessaging.Message Message)
        {
            this.Header = Message.Header;
            this.ServiceID = new Guid(Message.Payload.SubArray(0, 16));
            this.LocalPort = BitConverter.ToInt16(Message.Payload, 16);
        }
    }
}
