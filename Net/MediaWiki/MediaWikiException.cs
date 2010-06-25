using System;

namespace Utility.Net.MediaWiki
{
   public class MediaWikiException : Exception
    {
       readonly string _message;

        public override string Message
        {
            get
            {
                return _message;
            }
        }

        public MediaWikiException(string message)
        {
            _message = message;
        }
    }
}
