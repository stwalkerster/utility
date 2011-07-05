using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Net.Chat.InternetRelayChat
{
    partial class IrcClient
    {
        #region Implementation of IInternetRelayChatClientProtocol

        /// <summary>
        ///   A normal user uses the OPER command to obtain operator privileges.
        ///   The combination of name and password are REQUIRED to gain
        ///   Operator privileges.  Upon success, the user will receive a MODE
        ///   message (see section 3.1.5) indicating the new user modes.
        ///   Numeric Replies:
        ///           ERR_NEEDMOREPARAMS              RPL_YOUREOPER
        ///           ERR_NOOPERHOST                  ERR_PASSWDMISMATCH
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        public void oper(string name, string password)
        {
            throw new NotImplementedException();
        }

        public void service(string nickname, object reserved1, string distribution, object type, object reserved2, string info)
        {
            throw new NotImplementedException();
        }

        public void squit(string server, string comment)
        {
            throw new NotImplementedException();
        }

        public void connect(string targetserver, int port)
        {
            throw new NotImplementedException();
        }

        public void connect(string targetserver, int port, int remoteserver)
        {
            throw new NotImplementedException();
        }

        public void trace()
        {
            throw new NotImplementedException();
        }

        public void trace(string target)
        {
            throw new NotImplementedException();
        }

        public void servlist()
        {
            throw new NotImplementedException();
        }

        public void servlist(string mask)
        {
            throw new NotImplementedException();
        }

        public void servlist(string mask, string type)
        {
            throw new NotImplementedException();
        }

        public void squery(string servicename, string text)
        {
            throw new NotImplementedException();
        }

        public void kill(string nickname, string comment)
        {
            throw new NotImplementedException();
        }

        public void error(string message)
        {
            throw new NotImplementedException();
        }

        public void rehash()
        {
            throw new NotImplementedException();
        }

        public void die()
        {
            throw new NotImplementedException();
        }

        public void restart()
        {
            throw new NotImplementedException();
        }

        public void wallops(string message)
        {
            throw new NotImplementedException();
        }

        public void userhost(params string[] nickname)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
