using System.IO;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.XPath;


namespace Utility.Net.MediaWiki
{
    public class DeleteToken
    {
        readonly string _token;
        readonly string _title;

        public DeleteToken(string token, string title)
        {
            _token = token;
            _title = title;
        }

        public string token
        {
            get
            {
                return _token;
            }
        }
        public string title
        {
            get
            {
                return _title;
            }
        }
        public static DeleteToken get(WebClient wc, string title)
        {
            Stream data = wc.sendHttpGet(new WebHeaderCollection(), "action=query&prop=info&intoken=delete&titles=" + HttpUtility.UrlEncode(title));

            XPathDocument xDoc = new XPathDocument(data);
            XPathNavigator xNavigator = xDoc.CreateNavigator();
            XmlNamespaceManager xNamespace = new XmlNamespaceManager(xNavigator.NameTable);

            XPathNodeIterator xIterator = xNavigator.Select("//page");
            xIterator.MoveNext();

            return new DeleteToken(xIterator.Current.GetAttribute("deletetoken", xNamespace.DefaultNamespace),
                                        xIterator.Current.GetAttribute("title", xNamespace.DefaultNamespace)
                                        );
        }
    }
}
