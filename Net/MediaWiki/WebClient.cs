using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace Utility.Net.MediaWiki
{
    public class WebClient
    {
        public WebClient(string baseUrl)
        {
            cookieJar = new CookieContainer();
            _apiBase = baseUrl;
        }


        readonly string _apiBase;
        public CookieContainer cookieJar;
        private string maxlag = "15";
        private string userAgent = "Utility/0.1 (WebClient +http://svn.helpmebot.org.uk:3690/svn/utility)";

        public Stream sendHttpPost(WebHeaderCollection headers, NameValueCollection postValues, string queryString)
        {
            ServicePointManager.Expect100Continue = false;

            HttpWebRequest hrq = WebRequest.Create(_apiBase + "?format=xml&maxlag=" + maxlag + "&" + queryString) as HttpWebRequest;

            if (hrq == null)
                return null;

            hrq.Method = "POST";
            hrq.CookieContainer = cookieJar;
            hrq.Headers = headers;
            hrq.UserAgent = userAgent;
            hrq.ContentType = "application/x-www-form-urlencoded";


            StringBuilder data = new StringBuilder("format=xml");
            foreach (string item in postValues)
            {
                data.Append("&" + item + "=" + HttpUtility.UrlEncode(postValues[item]));
            }

            byte[] byteData = Encoding.UTF8.GetBytes(data.ToString());
            hrq.ContentLength = byteData.Length;

            using (Stream postStream = hrq.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
                postStream.Flush();
            }

            HttpWebResponse hrs = hrq.GetResponse() as HttpWebResponse;
            if (hrs == null) return null;

            cookieJar.Add(hrs.Cookies);
            if (hrs.Headers["X-Database-Lag"] != null)
                throw new MediaWikiException("Slave is too lagged.");

            Stream rs = hrs.GetResponseStream();

            return rs;

        }

        public Stream sendHttpGet(WebHeaderCollection headers, string queryString)
        {
            ServicePointManager.Expect100Continue = false;
 
            System.Threading.Thread.Sleep(2000);

                HttpWebRequest hrq =
                    WebRequest.Create(_apiBase + "?format=xml&maxlag=" + maxlag + "&" + queryString) as HttpWebRequest;
                if (hrq == null)
                    return null;
            
                hrq.Method = "GET";
                hrq.CookieContainer = cookieJar;
                hrq.Headers = headers;
                hrq.UserAgent = userAgent;

                HttpWebResponse hrs = hrq.GetResponse() as HttpWebResponse;
                if (hrs == null)
                    return null;

                cookieJar.Add(hrs.Cookies);
                if (hrs.Headers["X-Database-Lag"] != null)
                    throw new MediaWikiSlaveLagException(hrs.Headers["X-Database-Lag"]);

                Stream rs = hrs.GetResponseStream();

                return rs;
           
        }

    }
}