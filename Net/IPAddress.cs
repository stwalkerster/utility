using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Utility.Net
{
   public class IPAddress 
    {
        public static System.Net.IPAddress newFromString( string ipText )
        {
            if( ipText == string.Empty )
                return null;
            if( ipText.Contains( '/' ) )
                return null;

            string[ ] ipOctets = ipText.Split( '.' );
            byte[ ] ipAddr = new byte[ 4 ];
            for( int i = 0; i < 4; i++ )
            {
                ipAddr[ i ] = byte.Parse( ipOctets[ i ], System.Globalization.NumberStyles.Integer );
            }

           return new System.Net.IPAddress( ipAddr );
        }

        public static System.Net.IPAddress newFromEncodedString( byte[ ] IPv4Address )
        {
            return newFromString( ASCIIEncoding.ASCII.GetString( IPv4Address ) );
        }
    }
}
