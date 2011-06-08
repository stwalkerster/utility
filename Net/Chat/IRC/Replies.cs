﻿using System;

namespace Utility.Net.Chat.InternetRelayChat
{
    /// <summary>
    ///The following is a list of numeric replies which are generated in
    ///response to the commands given above.  Each numeric is given with its
    ///number, name and reply string.
    /// 
    /// Information taken from http://tools.ietf.org/pdf/rfc2812.pdf
    /// </summary>
    enum Replies
    {
        // Numerics in the range from 001 to 099 are used for client-server
        // connections only and should never travel between servers.

        // - The server sends Replies 001 to 004 to a user upon
        //   successful registration.
        RPL_WELCOME = 001,
        RPL_YOURHOST = 002,
        RPL_CREATED = 003,
        RPL_MYINFO = 004,

        /// <summary>
        /// - Sent by the server to a user to suggest an alternative
        ///   server.  This is often used when the connection is
        ///   refused because the server is already full
        /// </summary>
        RPL_BOUNCE = 005,

        // Replies generated in the response to commands are found in the 
        // range from 200 to 399.

        RPL_USERHOST = 302,

        /// <summary>
        /// Reply format used by ISON to list replies to the query list
        /// </summary>
        RPL_ISON = 303,

        RPL_AWAY = 301,
        RPL_UNAWAY = 305,
        RPL_NOWAWAY = 306,

        RPL_WHOISUSER = 311,
        RPL_WHOISSERVER=312,
        RPL_WHOISOPERATOR=313,
        RPL_WHOISIDLE = 317,
        RPL_ENDOFWHOIS = 318,
        RPL_WHOISCHANNELS = 319,

        RPL_WHOWASUSER  =314,
        RPL_ENDOFWHOWAS = 369,

        [Obsolete]
        RPL_LISTSTART = 321,
        RPL_LIST = 322,
        RPL_LISTEND = 323,

        RPL_UNIQOPIS = 325,
        RPL_CHANNELMODEIS = 324,

        RPL_NOTOPIC=331,
        RPL_TOPIC = 332,

        RPL_INVITING = 341,
        RPL_SUMMONING = 342,

        RPL_INVITELIST=346,
        RPL_ENDOFINVITELIST=347,

        RPL_EXCEPTLIST = 348,
        RPL_ENDOFEXCEPTLIST = 349,

        RPL_VERSION = 351,

        RPL_WHOREPLY = 352,
        RPL_ENDOFWHO = 315,

        RPL_NAMREPLY=353,
        RPL_ENDOFNAMES=366,

        RPL_LINKS = 364,
        RPL_ENDOFLINKS = 365,

        RPL_BANLIST = 367,
        RPL_ENDOFBANLIST=368,

        RPL_INFO = 371,
        RPL_ENDOFINFO = 374,

        RPL_MOTDSTART = 375,
        RPL_MOTD = 372,
        RPL_ENDOFMOTD = 376,

        RPL_YOUREOPER = 381,
        RPL_REHASHING = 382,
        RPL_YOURESERVICE = 383,

        RPL_TIME = 391,

        RPL_USERSSTART = 392,
        RPL_USERS = 393,
        RPL_ENDOFUSERS = 394,
        RPL_NOUSERS = 395,

        RPL_TRACELINK = 200,
        RPL_TRACECONNECTING = 201,
        RPL_TRACEHANDSHAKE = 202,
        RPL_TRACEUNKNOWN = 203,
        RPL_TRACEOPERATOR = 204,
        RPL_TRACEUSER = 205,
        RPL_TRACESERVER = 206,
        RPL_TRACESERVICE = 207,
        RPL_TRACENEWTYPE = 208,
        RPL_TRACECLASS = 209,
        [Obsolete]
        RPL_TRACERECONNECT = 210,
        RPL_TRACELOG = 261,
        RPL_TRACEEND=262,

        RPL_STATSLINKINFO = 211,
        RPL_STATSCOMMANDS = 212,
        RPL_ENDOFSTATS = 219,
        RPL_STATSUPTIME = 242,
        RPL_STATSOLINE = 243,

        RPL_UMODEIS = 221,
        
        RPL_SERVLIST = 234,
        RPL_SERVLISTEND = 235,

        RPL_LUSERCLIENT = 251,
        RPL_LUSEROP = 252,
        RPL_LUSERUNKNOWN = 253,
        RPL_LUSERCHANNELS = 254,
        RPL_LUSERME = 255,

        RPL_ADMINME = 256,
        RPL_ADMINLOC1=257,
        RPL_ADMINLOC2 = 258,
        RPL_ADMINEMAIL = 259,

        RPL_TRYAGAIN = 263,

        // Error replies are found in the range from 400 to 599.

        
    }
}