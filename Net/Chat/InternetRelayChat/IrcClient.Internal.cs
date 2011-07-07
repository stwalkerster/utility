using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Utility.Net.Chat.InternetRelayChat.EventHandlers;

namespace Utility.Net.Chat.InternetRelayChat
{
    partial class IrcClient
    {
        private TcpClient _tcpClient;

        private string _serverHostname;
        private int _serverPort;
        private string _nickname;
        private string _username;
        private string _realname;
        private string _password;

        private NetworkStream _stream;

        private StreamReader sr;

        private Thread readerThread;

        private Queue<string> _messageQueue = new Queue<string>(),
                              _urgentMessageQueue = new Queue<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="IOException" />
        private void readerThreadMethod()
        {
            while (_tcpClient.Connected)
            { // do read
                try
                {
                    string message = sr.ReadLine();

                    EventHandler<DataAvailableEventArgs> temp = dataAvailableEvent;
                    if (temp != null)
                    {
                        temp(this, new DataAvailableEventArgs(message));
                    };
                }
                catch(IOException)
                {
                    //TODO: handle gracefully.
                    throw;
                }
            }
        }

        /// <summary>
        /// internal message queueing method
        /// </summary>
        /// <param name="message">message to send</param>
        /// <param name="urgent">skip the default queue?</param>
        private void send(string message, bool urgent = false)
        {
            (urgent ? _urgentMessageQueue : _messageQueue).Enqueue(message);
        }

        private string getMessageToSend()
        {
            return _urgentMessageQueue.Count != 0
                       ? _urgentMessageQueue.Dequeue()
                       : _messageQueue.Dequeue();
        }
    }
}
