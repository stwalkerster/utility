using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Net.Chat.InternetRelayChat.EventHandlers
{
    public class DataAvailableEventArgs : IrcEventArgs
    {
        /// <summary>
        /// The data that is available
        /// </summary>
        public string data { get; set; }

        /// <summary>
        /// Creates a new instance with the specified data that is available.
        /// </summary>
        /// <param name="data"></param>
        public DataAvailableEventArgs(string data)
        {
            this.data = data;
        }
    }
}
