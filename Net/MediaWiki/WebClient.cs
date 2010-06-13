using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Utility.Net.MediaWiki
{
  public  class WebClient
    {
        public WebClient(string baseUrl)
        {
            cookieJar = new CookieContainer();
            apiBase=baseUrl;
        }


        string apiBase;
        public CookieContainer cookieJar;

        public Stream sendHttpPost(WebHeaderCollection headers, NameValueCollection postValues, string queryString)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            HttpWebRequest hrq = WebRequest.Create(apiBase + "?format=xml&maxlag=5&" + queryString) as HttpWebRequest;

            hrq.Method = "POST";
            hrq.CookieContainer = cookieJar;
            hrq.Headers = headers;
            hrq.UserAgent = "Utility/0.1 (WebClient +http://svn.helpmebot.org.uk:3690/svn/utility)";
            hrq.ContentType = "application/x-www-form-urlencoded";

            StringBuilder data = new StringBuilder("format=xml");
            foreach (string item in postValues)
            {
                data.Append("&" + item + "=" + HttpUtility.UrlEncode(postValues[item]));
            }

            byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
            hrq.ContentLength = byteData.Length;

            using (Stream postStream = hrq.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
                postStream.Flush();
            }

            HttpWebResponse hrs = hrq.GetResponse() as HttpWebResponse;
            cookieJar.Add(hrs.Cookies);
            if (hrs.Headers["X-Database-Lag"] != null)
                throw new MediaWikiException("Slave is too lagged.");

            Stream rs = hrs.GetResponseStream();

            return rs;

        }

        public Stream sendHttpGet(WebHeaderCollection headers, string queryString)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            HttpWebRequest hrq = WebRequest.Create(apiBase + "?format=xml&maxlag=5&" + queryString) as HttpWebRequest;

            hrq.Method = "GET";
            hrq.CookieContainer = cookieJar;
            hrq.Headers = headers;
            hrq.UserAgent = "Utility/0.1 (WebClient +http://svn.helpmebot.org.uk:3690/svn/utility)";

            HttpWebResponse hrs = hrq.GetResponse() as HttpWebResponse;
            cookieJar.Add(hrs.Cookies);
            if (hrs.Headers["X-Database-Lag"] != null)
                throw new MediaWikiException("Slave is too lagged.");

            Stream rs = hrs.GetResponseStream();

            return rs;
        }

    }
}
