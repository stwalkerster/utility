using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.XPath;


namespace Utility.Net.MediaWiki
{
    public class EditToken
    {
        string _token, _timestamp, _title, _lastedit;
        public EditToken(string token, string timestamp, string title, string lastedit)
        {
            _token = token;
            _timestamp = timestamp;
            _title = title;
            _lastedit = lastedit;
        }

        public string Token
        {
            get
            {
                return _token;
            }
        }
        public string Timestamp
        {
            get
            {
                return _timestamp;
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
        }
        public string LastEdit
        {
            get
            {
                return _lastedit;
            }
        }

        public static EditToken Get(WebClient wc, string title)
        {
            Stream data = wc.sendHttpGet(new WebHeaderCollection(), "action=query&prop=info|revisions&intoken=edit&titles=" + HttpUtility.UrlEncode(title));

            XPathDocument xDoc = new XPathDocument(data);
            XPathNavigator xNavigator = xDoc.CreateNavigator();
            XmlNamespaceManager xNamespace = new XmlNamespaceManager(xNavigator.NameTable);

            XPathNodeIterator xIterator = xNavigator.Select("//rev");
            xIterator.MoveNext();

            string lastEdit = xIterator.Current.GetAttribute("timestamp", xNamespace.DefaultNamespace);

            xIterator = xNavigator.Select("//page");
            xIterator.MoveNext();

            return new EditToken(xIterator.Current.GetAttribute("edittoken", xNamespace.DefaultNamespace),
                                        xIterator.Current.GetAttribute("starttimestamp", xNamespace.DefaultNamespace),
                                        xIterator.Current.GetAttribute("title", xNamespace.DefaultNamespace),
                                        lastEdit);
        }
    }
}
