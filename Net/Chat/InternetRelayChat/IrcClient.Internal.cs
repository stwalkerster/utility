using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

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

    }
}
