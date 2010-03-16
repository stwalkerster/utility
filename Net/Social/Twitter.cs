using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Utility.Net.Social
{
    class Twitter
    {
        public Twitter( string username, string password)
        {
            _username = username;
            _password = password;
        }

        string _username, _password;

        public string twitterUsername
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
        public string twitterPassword
        {
            private get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /// <summary>
        /// Updates the authenticating user's status.  Requires the status parameter specified below.  Request must be a POST.  A status update with text identical to the authenticating user's current status will be ignored to prevent duplicates.
        /// </summary>
        /// <param name="status">The text of your status update. URL encode as necessary. Statuses over 140 characters will cause a 403 error to be returned from the API.</param>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses%C2%A0update"/>
        public HttpStatusCode statuses_update(string status)
        { // POST
            string url = "http://api.twitter.com/1/statuses/update.xml" ;
            
            status = (status.Length > 140 ? status.Substring( 0, 140 ) : status);
            string postData = "status=" + status;

            HttpWebResponse wrsp = postResponse(url, postData);

            return wrsp.StatusCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses%C2%A0show"/>
        private void statuses_show( int id )
        { // GET
            //http://api.twitter.com/1/statuses/show/id.format
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses%C2%A0destroy"/>
        private void statuses_destroy( int id )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses-retweet"/>
        private void statuses_retweet( )
        {
        }

        private HttpWebResponse postResponse( string url, string parameters )
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create( url );
            wr.Credentials = new NetworkCredential( twitterUsername, twitterPassword );
            wr.Method = "POST";
            wr.UserAgent = "Utility/0.1 (TwitterClient +http://svn.helpmebot.org.uk:3690/svn/utility)";

            
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.ContentLength = parameters.Length;
            System.Net.ServicePointManager.Expect100Continue = false;
            using( Stream writeStream = wr.GetRequestStream( ) )
            {
                UTF8Encoding encoding = new UTF8Encoding( );
                byte[ ] bytes = encoding.GetBytes( parameters );
                writeStream.Write( bytes, 0, bytes.Length );
            }

            HttpWebResponse wrsp = (HttpWebResponse)wr.GetResponse( );

            return wrsp;
        }
    }
}
