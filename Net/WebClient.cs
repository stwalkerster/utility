using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace Utility.Net
{
  public  class WebClient
    {
        public WebClient(string baseUrl)
        {
            cookieJar = new CookieContainer();
            apiBase=baseUrl;
        }


        string apiBase;
        CookieContainer cookieJar;

        public Stream sendHttpPost(WebHeaderCollection headers, NameValueCollection postValues, string queryString)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            HttpWebRequest hrq = WebRequest.Create(apiBase + "?format=xml&" + queryString) as HttpWebRequest;

            hrq.Method = "POST";
            hrq.CookieContainer = cookieJar;
            hrq.Headers = headers;
            hrq.UserAgent = "Utility/0.1 (WebClient +http://svn.helpmebot.org.uk:3690/svn/utility)";

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
            cookieJar = new CookieContainer();
            cookieJar.Add(hrs.Cookies);

            StreamReader sr = new StreamReader(hrs.GetResponseStream());

            Stream rs = hrs.GetResponseStream();

            return rs;
        }

        public Stream sendHttpGet(WebHeaderCollection headers, string queryString)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            HttpWebRequest hrq = WebRequest.Create(apiBase + "?format=xml&" + queryString) as HttpWebRequest;

            hrq.Method = "GET";
            hrq.CookieContainer = cookieJar;
            hrq.Headers = headers;
            hrq.UserAgent = "Utility/0.1 (WebClient +http://svn.helpmebot.org.uk:3690/svn/utility)";

            HttpWebResponse hrs = hrq.GetResponse() as HttpWebResponse;
            cookieJar = new CookieContainer();
            cookieJar.Add(hrs.Cookies);

            StreamReader sr = new StreamReader(hrs.GetResponseStream());

            Stream rs = hrs.GetResponseStream();

            return rs;
        }

    }
}
