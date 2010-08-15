using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace Utility.Net.Social
{
   public class Twitter : Utility.Net.Authentication.OAuthBase
    {
        public Twitter( )
        {
            _accessToken = null;
            _ua = "Utility/0.1 (TwitterClient +http://svn.helpmebot.org.uk:3690/svn/utility)";
        }

        string  _ua, _accessToken;
        public string userAgent
        {
            get
            {
                return _ua;
            }
            set
            {
                _ua = value;
            }
        }

        /// <summary>
        /// Updates the authenticating user's status.  Requires the status parameter specified below.  Request must be a POST.  A status update with text identical to the authenticating user's current status will be ignored to prevent duplicates.
        /// </summary>
        /// <param name="status">The text of your status update. URL encode as necessary. Statuses over 140 characters will cause a 403 error to be returned from the API.</param>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses%C2%A0update"/>
        public HttpStatusCode statuses_update(string status)
        { // POST
            if( _accessToken == null )
                throw new System.Security.Authentication.AuthenticationException( );

            string url = "http://api.twitter.com/1/statuses/update.xml" ;
            
            status = (status.Length > 140 ? status.Substring( 0, 140 ) : status);
            string postData = "status=" + status;

            HttpWebResponse wrsp = postResponse(url, postData, null);

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

            if( _accessToken == null )
                throw new System.Security.Authentication.AuthenticationException( );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses%C2%A0destroy"/>
        private void statuses_destroy( int id )
        {
            if( _accessToken == null )
                throw new System.Security.Authentication.AuthenticationException( );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <see cref="http://apiwiki.twitter.com/Twitter-REST-API-Method:-statuses-retweet"/>
        private void statuses_retweet( )
        {
            if( _accessToken == null )
                throw new System.Security.Authentication.AuthenticationException( );
        }

        private HttpWebResponse postResponse( string url, string parameters, WebHeaderCollection headers)
        {
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create( url );

            wr.Headers = headers;

            wr.Method = "POST";
            wr.UserAgent = this.userAgent;

            
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

        public void authenticate( )
        {

        }

    }
}
