using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Utility.Net.Chat.InternetRelayChat.FloodDetection
{
    class SimpleTimerFloodPrevention : FloodPrevention
    {
        #region Overrides of FloodPrevention

        /// <summary>
        /// synchronous method to force the IRC client to wait if required
        /// </summary>
        public override void wait(string message)
        {
            Thread.Sleep(500);
        }

        #endregion
    }
}
