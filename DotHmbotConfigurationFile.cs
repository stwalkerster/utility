using System;
using System.Collections.Generic;
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
                StreamReader settingsreader = new StreamReader( filename );
                mySqlServerHostname = settingsreader.ReadLine( );
                mySqlServerPort = uint.Parse( settingsreader.ReadLine( ) );
                mySqlUsername = settingsreader.ReadLine( );
                mySqlPassword = settingsreader.ReadLine( );
                mySqlSchema = settingsreader.ReadLine( );
                settingsreader.Close( );
        }
        private DotHmbotConfigurationFile( )
        {
        }
        public void save( string filename )
        {
            StreamWriter sw = new StreamWriter( filename );
            sw.WriteLine( mySqlServerHostname );
            sw.WriteLine( mySqlServerPort.ToString( ) );
            sw.WriteLine( mySqlUsername );
            sw.WriteLine( mySqlPassword );
            sw.WriteLine( mySqlSchema );
            sw.Close( );
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

        public static DotHmbotConfigurationFile Create( string filename, string serverHostname, uint serverPort,
                                                string username, string password, string schema )
        {
            DotHmbotConfigurationFile x = new DotHmbotConfigurationFile( );
            x.mySqlPassword = password;
            x.mySqlSchema = schema;
            x.mySqlServerHostname = serverHostname;
            x.mySqlServerPort = serverPort;
            x.mySqlUsername = username;

            x.save( filename );

            return new DotHmbotConfigurationFile( filename );
        }
    }
}
