using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Utility.Net.Chat.InternetRelayChat.Exceptions;

namespace Utility.Net.Chat.InternetRelayChat
{
    ///<summary>
    /// IRC Client
    ///</summary>
    public partial class IrcClient : IInternetRelayChatClientProtocol
    {

        public event EventHandler<EventHandlers.DataAvailableEventArgs> dataAvailableEvent;


        /// <summary>
        /// Creates a new IRC client
        /// </summary>
        /// <param name="serverHostname">the IRC server to connect to</param>
        /// <param name="serverPort">the port the IRC server is listening to</param>
        /// <param name="nickname">the nickname to use on the IRC network</param>
        /// <param name="username">the username to use on the IRC network</param>
        /// <param name="realname">the user's real name</param>
        /// <param name="password">the password to connect to the server</param>
        public IrcClient(string serverHostname, int serverPort, string nickname,
            string username, string realname, string password = "")
        {
            _password = password;
            _realname = realname;
            _username = username;
            _nickname = nickname;
            _serverPort = serverPort;
            _serverHostname = serverHostname;
            _tcpClient = new TcpClient();
        }

        /// <summary>
        /// Connects to the IRC Network
        /// </summary>
        /// <exception cref="System.Net.Sockets.SocketException" />
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="ArgumentOutOfRangeException" />
        /// <exception cref="ObjectDisposedException" />
        public void clientConnect()
        {
            if(_tcpClient.Connected)
            {
                throw new AlreadyConnectedException();
            }

            _tcpClient.Connect(_serverHostname, _serverPort);

            if (!_tcpClient.Connected) throw new SocketException();

            _stream = _tcpClient.GetStream();
 
            sr = new StreamReader(_stream);

            readerThread = new Thread(readerThreadMethod);
        }

        /// <summary>
        /// Gets a value indicating whether the underlying socket is connected.
        /// </summary>
        public bool Connected { get { return _tcpClient.Connected; } }
    }
}
