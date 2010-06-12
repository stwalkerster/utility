using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.Net.MediaWiki
{
   public class MediaWikiException : Exception
    {
        string _message;

        public override string Message
        {
            get
            {
                return _message;
            }
        }

        public MediaWikiException(string message)
        {
            this._message = message;
        }
    }
}
