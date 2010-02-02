using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Utility
{
    public class DotHmbotConfigurationFile
    {
        string host, user, password, db;
        uint port;

        public DotHmbotConfigurationFile( string filename )
        {
            try
            {
                StreamReader settingsreader = new StreamReader( filename );
                mySqlServerHostname = settingsreader.ReadLine( );
                mySqlServerPort = uint.Parse( settingsreader.ReadLine( ) );
                mySqlUsername = settingsreader.ReadLine( );
                mySqlPassword = settingsreader.ReadLine( );
                mySqlSchema = settingsreader.ReadLine( );
                settingsreader.Close( );
            }
            catch( Exception )
            {
            }
        }

        public void save( string filename )
        {
            StreamWriter sw = new StreamWriter( filename );
            sw.WriteLine( mySqlServerHostname );
            sw.WriteLine( mySqlServerPort.ToString( ) );
            sw.WriteLine( mySqlUsername );
            sw.WriteLine( mySqlPassword );
            sw.WriteLine( mySqlSchema );
        }

        public string mySqlServerHostname
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }
        public uint mySqlServerPort
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
        public string mySqlUsername
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public string mySqlPassword
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public string mySqlSchema
        {
            get
            {
                return db;
            }
            set
            {
                db = value;
            }
        }
    }
}
