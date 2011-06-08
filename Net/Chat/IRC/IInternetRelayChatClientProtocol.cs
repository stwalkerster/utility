using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Net.Chat.InternetRelayChat
{
    /// <summary>
    /// This interface exposes the necessary methods to communicate with an IRC server.
    /// 
    /// It does not form the interface to a proper client, but rather wraps around the
    /// protocol allowing a protocol wrapper to be efficiently written.
    /// </summary>
    interface IInternetRelayChatClientProtocol
    {
        /// <summary>
        /// The PASS command is used to set a ’connection password’.  The
        /// optional password can and MUST be set before any attempt to register
        /// the connection is made.  Currently this requires that user send a
        /// PASS command before sending the NICK/USER combination.
        /// Numeric Replies:
        ///         ERR_NEEDMOREPARAMS              ERR_ALREADYREGISTRED
        /// </summary>
        /// <param name="password"></param>
        void pass(string password);

        /// <summary>
        /// NICK command is used to give user a nickname or change the existing one.
        ///    Numeric Replies:
        ///   ERR_NONICKNAMEGIVEN             ERR_ERRONEUSNICKNAME
        ///   ERR_NICKNAMEINUSE               ERR_NICKCOLLISION
        ///   ERR_UNAVAILRESOURCE             ERR_RESTRICTED
        /// </summary>
        /// <param name="nickname"></param>
        void nick(string nickname);

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
        void user(string user, byte mode, object unused, string realname);

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
        void oper(string name, string password);

        // mode

        void service(string nickname, object reserved1, string distribution, object type, object reserved2, string info);

        void quit(string quitMessage);

        void squit(string server, string comment);

        /// <summary>
        /// parts all channels
        /// </summary>
        void join();
        /// <summary>
        /// joins the list of channels
        /// </summary>
        /// <param name="channels"></param>
        void join(params string[] channels);
        /// <summary>
        /// joins the list of channels (as keys), with the specified channel key (as values)
        /// </summary>
        /// <param name="channels"></param>
        void join(params KeyValuePair<string, string>[] channels);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="channels"></param>
        /// <remarks>PART channel,channel,channel message</remarks>
        void part(string message, params string[] channels);

        // mode

        void topic(string channel);
        void topic(string channel, string topic);

        void names();
        void names(params string[] channels);
        //TODO: check if this will actually work... I have a feeling it won't.
        void names(string target, params string[] channels);

        void list();
        void list(params string[] channels);
        //TODO: check if this will actually work... I have a feeling it won't.
        void list(string target, params string[] channels);

        void invite(string nickname, string channel);


    }
}
