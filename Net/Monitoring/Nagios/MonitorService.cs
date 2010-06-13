using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace Utility.Net.Monitoring.Nagios
{
    class MonitorService
    {
        TcpListener service;

        bool alive;

        Thread monitorthread;

        readonly string message;

        public MonitorService( int port, string message )
        {
            monitorthread = new Thread( new ThreadStart( threadMethod ) );

            this.message = message;

            service = new TcpListener( System.Net.IPAddress.Any, port );

            monitorthread.Start( );
        }

        void threadMethod( )
        {
            try
            {
                alive = true;
                service.Start( );

                while( service.Pending( ) || alive )
                {
                    if( !service.Pending( ) )
                    {
                        Thread.Sleep( 10 );
                        continue;
                    }

                    TcpClient client = service.AcceptTcpClient( );

                    StreamWriter sw = new StreamWriter( client.GetStream( ) );

                    sw.WriteLine( message );
                    sw.Flush( );
                    client.Close( );
                }
            }
            catch( ThreadAbortException )
            {
                throw;
            }
        }

        public void stop( )
        {
            service.Stop( );
            alive = false;

        }
    }
}