using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Net.Chat.InternetRelayChat
{
    partial class IrcClient
    {
        #region Implementation of IInternetRelayChatClientProtocol

        /// <summary>
        /// The PASS command is used to set a ’connection password’.  The
        /// optional password can and MUST be set before any attempt to register
        /// the connection is made.  Currently this requires that user send a
        /// PASS command before sending the NICK/USER combination.
        /// Numeric Replies:
        ///         ERR_NEEDMOREPARAMS              ERR_ALREADYREGISTRED
        /// </summary>
        /// <param name="password"></param>
        public void pass(string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NICK command is used to give user a nickname or change the existing one.
        ///    Numeric Replies:
        ///   ERR_NONICKNAMEGIVEN             ERR_ERRONEUSNICKNAME
        ///   ERR_NICKNAMEINUSE               ERR_NICKCOLLISION
        ///   ERR_UNAVAILRESOURCE             ERR_RESTRICTED
        /// </summary>
        /// <param name="nickname"></param>
        public void nick(string nickname)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   The USER command is used at the beginning of connection to specify
        ///   the username, hostname and realname of a new user.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="mode">
        ///   The mode parameter should be a numeric, and can be used to
        ///   automatically set user modes when registering with the server.  This
        ///   parameter is a bitmask, with only 2 bits having any signification: if
        ///   the bit 2 is set, the user mode ’w’ will be set and if the bit 3 is
        ///   set, the user mode ’i’ will be set.  (See Section 3.1.5 "User
        ///   Modes").
        /// </param>
        /// <param name="unused">unused.</param>
        /// <param name="realname">
        ///   The realname may contain space characters.
        /// </param>
        ///   Numeric Replies:
        ///           ERR_NEEDMOREPARAMS              ERR_ALREADYREGISTRED
        public void user(string user, byte mode, object unused, string realname)
        {
            throw new NotImplementedException();
        }

        public void quit(string quitMessage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// parts all channels
        /// </summary>
        public void join()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// joins the list of channels
        /// </summary>
        /// <param name="channels"></param>
        public void join(params string[] channels)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// joins the list of channels (as keys), with the specified channel key (as values)
        /// </summary>
        /// <param name="channels"></param>
        public void join(params KeyValuePair<string, string>[] channels)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="channels"></param>
        /// <remarks>PART channel,channel,channel message</remarks>
        public void part(string message, params string[] channels)
        {
            throw new NotImplementedException();
        }

        public void topic(string channel)
        {
            throw new NotImplementedException();
        }

        public void topic(string channel, string topic)
        {
            throw new NotImplementedException();
        }

        public void names()
        {
            throw new NotImplementedException();
        }

        public void names(params string[] channels)
        {
            throw new NotImplementedException();
        }

        public void names(string target, params string[] channels)
        {
            throw new NotImplementedException();
        }

        public void list()
        {
            throw new NotImplementedException();
        }

        public void list(params string[] channels)
        {
            throw new NotImplementedException();
        }

        public void list(string target, params string[] channels)
        {
            throw new NotImplementedException();
        }

        public void invite(string nickname, string channel)
        {
            throw new NotImplementedException();
        }

        public void kick(string channel, string comment, params string[] users)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="channelusers">key as channel, value as user</param>
        public void kick(string comment, params KeyValuePair<string, string>[] channelusers)
        {
            throw new NotImplementedException();
        }

        public void privmsg(string target, string text)
        {
            throw new NotImplementedException();
        }

        public void notice(string target, string text)
        {
            throw new NotImplementedException();
        }

        public void motd()
        {
            throw new NotImplementedException();
        }

        public void motd(string targetserver)
        {
            throw new NotImplementedException();
        }

        public void lusers()
        {
            throw new NotImplementedException();
        }

        public void lusers(string mask)
        {
            throw new NotImplementedException();
        }

        public void lusers(string mask, string target)
        {
            throw new NotImplementedException();
        }

        public void version()
        {
            throw new NotImplementedException();
        }

        public void version(string target)
        {
            throw new NotImplementedException();
        }

        public void stats()
        {
            throw new NotImplementedException();
        }

        public void stats(string query)
        {
            throw new NotImplementedException();
        }

        public void stats(string query, string target)
        {
            throw new NotImplementedException();
        }

        public void links()
        {
            throw new NotImplementedException();
        }

        public void links(string servermask)
        {
            throw new NotImplementedException();
        }

        public void links(string remoteserver, string servermask)
        {
            throw new NotImplementedException();
        }

        public void time()
        {
            throw new NotImplementedException();
        }

        public void time(string target)
        {
            throw new NotImplementedException();
        }

        public void admin()
        {
            throw new NotImplementedException();
        }

        public void admin(string target)
        {
            throw new NotImplementedException();
        }

        public void info()
        {
            throw new NotImplementedException();
        }

        public void info(string target)
        {
            throw new NotImplementedException();
        }

        public void who()
        {
            throw new NotImplementedException();
        }

        public void who(string mask, bool opsonly)
        {
            throw new NotImplementedException();
        }

        public void whois(string targetserver, params string[] mask)
        {
            throw new NotImplementedException();
        }

        public void whowas(params string[] nicknames)
        {
            throw new NotImplementedException();
        }

        public void whowas(int count, params string[] nicknames)
        {
            throw new NotImplementedException();
        }

        public void whowas(string targetserver, int count, params string[] nicknames)
        {
            throw new NotImplementedException();
        }

        public void ping(string server1)
        {
            throw new NotImplementedException();
        }

        public void ping(string server1, string server2)
        {
            throw new NotImplementedException();
        }

        public void pong(string server1)
        {
            throw new NotImplementedException();
        }

        public void pong(string server1, string server2)
        {
            throw new NotImplementedException();
        }

        public void away(string message)
        {
            throw new NotImplementedException();
        }

        public void away()
        {
            throw new NotImplementedException();
        }

        public void summon(string user)
        {
            throw new NotImplementedException();
        }

        public void summon(string user, string target)
        {
            throw new NotImplementedException();
        }

        public void summon(string user, string target, string channel)
        {
            throw new NotImplementedException();
        }

        public void users()
        {
            throw new NotImplementedException();
        }

        public void users(string target)
        {
            throw new NotImplementedException();
        }

        public void ison(params string[] nickname)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
