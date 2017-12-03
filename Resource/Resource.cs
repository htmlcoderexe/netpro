using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resource
{
    public class Resource
    {
        public enum ResourceState
        {
            Unknown,
            Unavailable,
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
    }
}
