using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource
{
    public class Resource
    {
        public Guid ID;
        public string FriendlyName;
        public enum ResourceState
        {
            Unknown,
            Offline,
            Shared,
            Available,
            Used
        }
        public ResourceState State;
        public enum ResourceType
        {
            MessageDisplay,
            AudioOut,
            AudioIn,
            VideoOut,
            VideoIn,
            DataWrite,
            DataRead,
            Logger
        }
        public ResourceType Type;
        public byte SubType;
        public int Capacity;
        public int MaxCapacity;
    }
}
