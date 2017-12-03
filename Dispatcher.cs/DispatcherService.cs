using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatcher
{
    public class DispatcherService : Service.Service
    { 
        public DispatcherService() : base()
        {
            this.Messenger.BoundPort = NetMessaging.OperationConstants.DispatcherPort;
        }

        public void RegisterHost()
        {

        }
    }
}
