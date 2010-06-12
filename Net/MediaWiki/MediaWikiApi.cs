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
        WebClient wc ;

#region Constants
       public const int ACTION_EDIT_EXISTS_DOESEXIST = 1;
       public const int ACTION_EDIT_EXISTS_NOCHECK = 0;
       public const int ACTION_EDIT_EXISTS_NOTEXIST = -1;

       public const int ACTION_EDIT_TEXT_PREPEND = -1;
       public const int ACTION_EDIT_TEXT_REPLACE = 0;
       public const int ACTION_EDIT_TEXT_APPEND = 1;

       public const int ACTION_EDIT_SECTION_NEW = -2;
       public const int ACTION_EDIT_SECTION_ALL = -1;
#endregion

        string editToken = "+\\";
        string editTokenTimestamp = "1970-01-01T00:00:00Z";

        public MediaWikiApi()
        {
              wc= new WebClient("http://en.wikipedia.org/w/api.php");
        }
        public MediaWikiApi(string apiBase)
        {
            wc= new WebClient(apiBase);
        }

        public void Login(string username, string password)
        {
            NameValueCollection vals = new NameValueCollection();
            vals.Add("lgpassword", password);
            Stream data = wc.sendHttpPost(new WebHeaderCollection(), vals, "action=login&lgname=Stwalkerbot&lgpassword="+password);

            XmlNamespaceManager xNamespace;
            XPathNodeIterator xIterator = getIterator(data, "//login", out xNamespace);

            string token = "";
            xIterator.MoveNext();

            string result = xIterator.Current.GetAttribute("result", xNamespace.DefaultNamespace);
            if (result == "NeedToken")
            {
                token = xIterator.Current.GetAttribute("token", xNamespace.DefaultNamespace);

                data = wc.sendHttpPost(new WebHeaderCollection(), vals, "action=login&lgname=Stwalkerbot&lgtoken=" + token + "&lgpassword=" + password);

                xIterator = getIterator(data, "//login");
                xIterator.MoveNext();

                result = xIterator.Current.GetAttribute("result", xNamespace.DefaultNamespace);
            }

            if (result != "Success")
                throw new MediaWikiException("Login failed: " + result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">article to edit</param>
        /// <param name="text">new text to insert</param>
        /// <param name="summary">edit summary, or section title if section=ACTION_EDIT_SECTION_NEW</param>
        /// <param name="exists">What to do if the article exists.</param>
        /// <param name="minor">flag as a minor edit</param>
        /// <param name="bot">flag as a bot edit</param>
        /// <param name="location">Where to put the text</param>
        /// <param name="section">section to edit</param>
        public void Edit(string title, string text, string summary, int exists, bool minor, bool bot, int location, int section)
        {
            EditToken t = EditToken.Get(wc, title);

            NameValueCollection vals = new NameValueCollection();
            if (section != ACTION_EDIT_SECTION_ALL)
            {
                if (section == ACTION_EDIT_SECTION_NEW)
                    vals.Add("section", "new");
                else
                    vals.Add("section", section.ToString());

            }


     

            vals.Add("summary", summary);
            vals.Add("basetimestamp", t.LastEdit);
            switch (location)
            {
                case ACTION_EDIT_TEXT_APPEND:
                    vals.Add("appendtext", text);
                    break;
                case ACTION_EDIT_TEXT_PREPEND:
                    vals.Add("prependtext", text);
                    break;
                case ACTION_EDIT_TEXT_REPLACE:
                    vals.Add("text", text);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("location");
            }

            switch (exists)
            {
                case ACTION_EDIT_EXISTS_DOESEXIST:
                    vals.Add("nocreate", "true");
                    break;
                case ACTION_EDIT_EXISTS_NOCHECK:
                    break;
                case ACTION_EDIT_EXISTS_NOTEXIST:
                    vals.Add("createonly", "true");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("exists");
            }

            
            vals.Add("starttimestamp", t.Timestamp);
            vals.Add("token", t.Token);

            Stream data = wc.sendHttpPost(new WebHeaderCollection(), vals, "action=edit&title=" + HttpUtility.UrlEncode(t.Title) + ( bot ? "&bot" : "" ));
            XmlNamespaceManager ns;
            XPathNodeIterator it = getIterator(data, "//error", out ns);
            if(it.Count != 0){
                it.MoveNext();
                throw new MediaWikiException(it.Current.GetAttribute("info", ns.DefaultNamespace)); 
        }}

        private XPathNodeIterator getIterator(Stream data, string xpath)
        {
            XmlNamespaceManager xNamespace;
            return getIterator(data, xpath, out xNamespace);
        }
        private XPathNodeIterator getIterator(Stream data, string xpath, out  XmlNamespaceManager xNamespace)
        {
            return getIterator(data, XPathExpression.Compile(xpath), out xNamespace);
        }
        private XPathNodeIterator getIterator(Stream data, XPathExpression xpath)
        {
            XmlNamespaceManager xNamespace;
            return getIterator(data, xpath, out xNamespace);
        }

        private XPathNodeIterator getIterator(Stream data, XPathExpression xpath, out XmlNamespaceManager xNamespace)
        {
            XPathDocument xDoc = new XPathDocument(data);
            XPathNavigator xNavigator = xDoc.CreateNavigator();
            xNamespace = new XmlNamespaceManager(xNavigator.NameTable);
            XPathNodeIterator xInterator = xNavigator.Select(xpath);

            return xInterator;
        }
    }
}
