using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace Utility.Net.MediaWiki
{
    public class MediaWikiApi
    {
        string apiBase = "http://en.wikipedia.org/w/api.php";

        CookieContainer cookieJar = new CookieContainer();

        public MediaWikiApi()
        {
              
        }
        public MediaWikiApi(string apiBase)
        {
            this.apiBase = apiBase;
        }

        public void Login(string username, string password)
        {
            NameValueCollection vals = new NameValueCollection();
            vals.Add("lgpassword", password);
            Stream data = sendHttpPost(new WebHeaderCollection(), vals, "action=login&lgname=Stwalkerbot&lgpassword="+password);

            XPathDocument xDoc = new XPathDocument(data);
            XPathNavigator xNavigator = xDoc.CreateNavigator();
            XmlNamespaceManager xNamespace = new XmlNamespaceManager(xNavigator.NameTable);
            XPathNodeIterator xInterator = xNavigator.Select("//login");

            string token = "";
            xInterator.MoveNext();

            string result = xInterator.Current.GetAttribute("result", xNamespace.DefaultNamespace);
            if (result == "NeedToken")
                token = xInterator.Current.GetAttribute("token", xNamespace.DefaultNamespace);

            data = sendHttpPost(new WebHeaderCollection(), vals, "action=login&lgname=Stwalkerbot&lgtoken=" + token + "&lgpassword=" + password);

            xDoc = new XPathDocument(data);
            xNavigator = xDoc.CreateNavigator();
            xNamespace = new XmlNamespaceManager(xNavigator.NameTable);
            xInterator = xNavigator.Select("//login");
            xInterator.MoveNext();

            result = xInterator.Current.GetAttribute("result", xNamespace.DefaultNamespace);

            if (result != "Success")
                throw new MediaWikiException("Login failed: " + result);
        }

        private Stream sendHttpPost(WebHeaderCollection headers, NameValueCollection postValues, string queryString)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            HttpWebRequest hrq = WebRequest.Create(apiBase + "?format=xml&" + queryString) as HttpWebRequest;
            
            hrq.Method = "POST";
            hrq.CookieContainer = cookieJar;
            hrq.Headers = headers;
            hrq.UserAgent = "Utility/0.1 (MediaWikiApi +http://svn.helpmebot.org.uk:3690/svn/utility)";

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
    }
}
