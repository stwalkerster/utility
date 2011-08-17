using System;
using System.Text;

namespace Utility.Net
{
   public class IPAddress 
    {

        [Obsolete]
        public static System.Net.IPAddress newFromString( string ipText )
        {
            System.Net.IPAddress ip;
            return System.Net.IPAddress.TryParse(ipText, out ip) ? ip : null;
        }

        public static System.Net.IPAddress newFromEncodedString( byte[ ] IPv4Address )
        {
            System.Net.IPAddress ip;
            return System.Net.IPAddress.TryParse(Encoding.ASCII.GetString(IPv4Address), out ip) ? ip : null;
        }

        public static string getReversedIpString(System.Net.IPAddress ipAddress)
        {
            byte[ ] ipForward = ipAddress.GetAddressBytes( );
            byte[ ] ipReverse = new byte[ 4 ];
            ipReverse[ 0 ] = ipForward[ 3 ];
            ipReverse[ 1 ] = ipForward[ 2 ];
            ipReverse[ 2 ] = ipForward[ 1 ];
            ipReverse[ 3 ] = ipForward[ 0 ];
            return new System.Net.IPAddress(ipReverse).ToString();
        }
    }
}
