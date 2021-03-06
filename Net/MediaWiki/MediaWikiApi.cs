﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.XPath;

namespace Utility.Net.MediaWiki
{
    public class MediaWikiApi
    {
        readonly WebClient _wc;

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

        public MediaWikiApi()
        {
            _wc = new WebClient("http://en.wikipedia.org/w/api.php");
        }
        public MediaWikiApi(string apiBase)
        {
            _wc = new WebClient(apiBase);
        }

        [Obsolete()]
        public void login(string username, string password)
        {
            string result;
            login(username, password, out result);

            if (result != "Success")
                throw new MediaWikiException("Login failed: " + result);
        }

        public bool login(string username, string password, out string result)
        {
            return login(username, password, "", out result);
        }
        public bool login(string username, string password, string domain, out string result)
        {
            NameValueCollection vals = new NameValueCollection();
            vals.Add("lgpassword", password );
            if(domain != "")
            {
                vals.Add("lgdomain", domain);
            }

            Stream data = _wc.sendHttpPost(new WebHeaderCollection(), vals, "action=login&lgname=" + username + "&lgpassword=" + password);

            XmlNamespaceManager xNamespace;
            XPathNodeIterator xIterator = getIterator(data, "//login", out xNamespace);

            xIterator.MoveNext();

            result = xIterator.Current.GetAttribute("result", xNamespace.DefaultNamespace);
            if (result == "NeedToken")
            {
                string token = xIterator.Current.GetAttribute("token", xNamespace.DefaultNamespace);

                data = _wc.sendHttpPost(new WebHeaderCollection(), vals, "action=login&lgname=" + username + "&lgtoken=" + token + "&lgpassword=" + password);

                xIterator = getIterator(data, "//login");
                xIterator.MoveNext();

                result = xIterator.Current.GetAttribute("result", xNamespace.DefaultNamespace);
            }

            if (result == "Success")
                return true;
            return false;
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
        public void edit(string title, string text, string summary, int exists, bool minor, bool bot, int location, int section)
        {
            EditToken t = EditToken.get(_wc, title);

            NameValueCollection vals = new NameValueCollection();
            if (section != ACTION_EDIT_SECTION_ALL)
            {
                vals.Add("section", section == ACTION_EDIT_SECTION_NEW ? "new" : section.ToString());
            }

            vals.Add("summary", summary);
            vals.Add("basetimestamp", t.lastEdit);
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

            vals.Add("starttimestamp", t.timestamp);
            vals.Add("token", t.token);

            Stream data = _wc.sendHttpPost(new WebHeaderCollection(), vals, "action=edit&assert=user&title=" + HttpUtility.UrlEncode(t.title) + (bot ? "&bot" : "") + "&token=" + t.token);
            XmlNamespaceManager ns;
            XPathNodeIterator it = getIterator(data, "//error", out ns);
            if (it.Count != 0)
            {
                it.MoveNext();
                throw new MediaWikiException(it.Current.GetAttribute("info", ns.DefaultNamespace));
            }
            System.Threading.Thread.Sleep(1000 * 10);
        }

        public string getPageContent(string title)
        {
            Stream data = _wc.sendHttpGet(new WebHeaderCollection(), "action=query&assert=user&prop=revisions&rvprop=content&titles=" + HttpUtility.UrlEncode(title));
            XmlNamespaceManager xn;
            XPathNodeIterator xIterator = getIterator(data, "//rev", out xn);
            xIterator.MoveNext();
            return (string)xIterator.Current.TypedValue;
        }

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

        public ArrayList getPages(int ns, int limit)
        {
            Stream data = _wc.sendHttpGet(new WebHeaderCollection(),
                                          "action=query&list=allpages&apnamespace=" + ns + "&aplimit=" + limit);
            XmlNamespaceManager xn;
            XPathNodeIterator xIterator = getIterator(data, "//p", out xn);

            ArrayList l = new ArrayList();
            while (xIterator.MoveNext())
            {
                l.Add(xIterator.Current.GetAttribute("title", xn.DefaultNamespace));
            }

            return l;
        }
    
        public ArrayList getCurrentUserRights()
        {
            Stream data = _wc.sendHttpGet(new WebHeaderCollection(), "action=query&meta=userinfo&uiprop=rights");
            XmlNamespaceManager xn;
            XPathNodeIterator xIterator = getIterator(data, "//r", out xn);

            ArrayList l = new ArrayList();
            while (xIterator.MoveNext())
            {
                l.Add(xIterator.Current.Value);
            }

            return l;
        }

        //public bool pageExists(string title)
        //{
        //    //Stream data = _wc.sendHttpGet(new WebHeaderCollection(),
        //    //                  "action=query&list=allpages&apnamespace=" + ns + "&aplimit=" + limit);
        //    //XmlNamespaceManager xn;
        //    //XPathNodeIterator xIterator = getIterator(data, "//p", out xn);

        //    //ArrayList l = new ArrayList();
        //    //while (xIterator.MoveNext())
        //    //{
        //    //    l.Add(xIterator.Current.GetAttribute("title", xn.DefaultNamespace));
        //    //}

        //    //return l;
        //}

        public void delete(string title, string reason)
        {
            DeleteToken t = DeleteToken.get(_wc, title);

            NameValueCollection vals = new NameValueCollection();

            vals.Add("title", title);
            vals.Add("token", t.token);
            vals.Add("reason", reason);

            Stream data = _wc.sendHttpPost(new WebHeaderCollection(), vals, "action=delete");
            XmlNamespaceManager ns;
            XPathNodeIterator it = getIterator(data, "//error", out ns);
            if (it.Count != 0)
            {
                it.MoveNext();
                throw new MediaWikiException(it.Current.GetAttribute("info", ns.DefaultNamespace));
            }
        }
    
        public bool hasBacklinks(string title)
        {
            Stream data = _wc.sendHttpGet(new WebHeaderCollection(), "action=query&list=backlinks&bllimit=1&bltitle=" + HttpUtility.UrlEncode(title) );
            XmlNamespaceManager ns;
            XPathNodeIterator it = getIterator(data, "//bl", out ns);
            return it.Count != 0;
        }

        public bool imageIsUsed(string title)
        {

            Stream data = _wc.sendHttpGet(new WebHeaderCollection(), "action=query&list=imageusage&iutitle=" + HttpUtility.UrlEncode(title));
            XmlNamespaceManager ns;
            XPathNodeIterator it = getIterator(data, "//iu", out ns);
            return it.Count != 0;
            return true;
        }

        public bool isRedirect(string title)
        {
            Stream data = _wc.sendHttpGet(new WebHeaderCollection(), "action=query&prop=info&titles=" + HttpUtility.UrlEncode(title) );
            XmlNamespaceManager ns;
            XPathNodeIterator it = getIterator(data, "//page", out ns);

            it.MoveNext();
            if (it.Current.OuterXml.Contains("redirect=\"\""))
                return true;
            return false;
        }
    }
}
