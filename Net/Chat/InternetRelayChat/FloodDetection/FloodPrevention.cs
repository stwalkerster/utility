namespace Utility.Net.Chat.InternetRelayChat.FloodDetection
{
    public abstract class FloodPrevention
    {
        /// <summary>
        /// synchronous method to force the IRC client to wait if required
        /// </summary>
        public abstract void wait(string message);
    }
}