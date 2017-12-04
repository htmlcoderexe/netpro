using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource.Messages
{
    public class ResourceStatus : NetMessaging.Message
    {
        public Resource Resource;
        
        public override byte[] Pack()
        {
            byte[] result;
            byte[] name= System.Text.UTF8Encoding.UTF8.GetBytes(Resource.FriendlyName);
            int length = 16 + 1 + 1 + 1 + 4+4+1+name.Length;
            int i = 0;
            result = new byte[length];
            Array.Copy(Resource.ID.ToByteArray(), 0, result, i, 16);
            i += 16;
            result[i] = (byte)Resource.Type;
            i++;
            result[i] = Resource.SubType;
            i++;
            result[i] = (byte)Resource.State;
            i++;
            Array.Copy(BitConverter.GetBytes(Resource.Capacity), 0, result, i, 4);
            i += 4;
            Array.Copy(BitConverter.GetBytes(Resource.MaxCapacity), 0, result, i, 4);
            i += 4;
            result[i] = (byte)name.Length;
            i++;
            Array.Copy(name, 0, result, i, name.Length);
            return result;   
        }
    }
}
