using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading;
using Utility.Net.Chat.InternetRelayChat.EventHandlers;
using Utility.Net.Chat.InternetRelayChat.FloodDetection;

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
        private StreamWriter sw;

        private Thread readerThread, writerThread;

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
        /// <exception cref="SecurityException"/>
        private void send(string message, bool urgent = false)
        {
            (urgent ? _urgentMessageQueue : _messageQueue).Enqueue(message);

            if (writerThread.ThreadState == ThreadState.WaitSleepJoin)
            {
                // throws SecurityException
                writerThread.Interrupt();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException" />
        private string getMessageToSend()
        {
            try
            {
                if (_urgentMessageQueue.Count != 0)
                    return _urgentMessageQueue.Dequeue();

                if (_messageQueue.Count != 0)
                    return _messageQueue.Dequeue();

            }
            catch (InvalidOperationException)
            {
                //TODO: handle gracefully.
                throw;
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ObjectDisposedException" />
        /// <exception cref="IOException" />
        /// <exception cref="System.Text.EncoderFallbackException" />
        private void writerThreadMethod()
        {
            FloodPrevention fp = (FloodPrevention)Activator.CreateInstance(this.floodprotection);

            while(_tcpClient.Connected)
            {
                string messageToSend = getMessageToSend();

                if(messageToSend == string.Empty)
                {
                    // block until we have something to do.
                    Thread.Sleep(0);
                    continue;
                }

                try
                {
                    fp.wait(messageToSend);

                    sw.WriteLine(messageToSend);
                    sw.Flush();
                }
                catch(ObjectDisposedException)
                {
                    throw;
                }
                catch(IOException)
                {
                    throw;
                }
                catch(System.Text.EncoderFallbackException)
                {
                    throw;
                }
            }
        }
    }
}
