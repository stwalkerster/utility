using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.XPath;


namespace Utility.Net.MediaWiki
{
    public class EditToken
    {
        readonly string _token;
        readonly string _timestamp;
        readonly string _title;
        readonly string _lastedit;

        public EditToken(string token, string timestamp, string title, string lastedit)
        {
            _token = token;
            _timestamp = timestamp;
            _title = title;
            _lastedit = lastedit;
        }

        public string token
        {
            get
            {
                return _token;
            }
        }
        public string timestamp
        {
            get
            {
                return _timestamp;
            }
        }
        public string title
        {
            get
            {
                return _title;
            }
        }
        public string lastEdit
        {
            get
            {
                return _lastedit;
            }
        }

        public static EditToken get(WebClient wc, string title)
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
