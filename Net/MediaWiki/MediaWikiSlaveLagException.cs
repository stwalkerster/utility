using System;

namespace Utility.Net.MediaWiki
{
   public class MediaWikiSlaveLagException : Exception
    {
       readonly string _message = "Slave is too lagged";
       private string _lag;

       public override string Message
        {
            get
            {
                return _message + ": " + _lag + " seconds";
            }
        }

       public string Lag
       {
           get { return _lag; }
       }

       public MediaWikiSlaveLagException(string lag)
        {
           _lag = lag;
        }
    }
}
