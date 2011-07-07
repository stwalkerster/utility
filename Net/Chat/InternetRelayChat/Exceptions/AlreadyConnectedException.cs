using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Net.Chat.InternetRelayChat.Exceptions
{
    class AlreadyConnectedException : System.Exception
    {
        public override string Message { get { return "The client is already connected to the network"; } }
    }
}
