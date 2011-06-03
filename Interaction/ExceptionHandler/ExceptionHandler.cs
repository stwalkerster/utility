using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Utility.Interaction.ExceptionHandler
{
    public partial class ExceptionHandler : Form
    {
        private object _sender;
        private ThreadExceptionEventArgs _threadExceptionEventArgs;
        private static ExceptionHandlerConfiguration _configuration;

        public static void threadExceptionEventHandler(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionHandler handler = new ExceptionHandler();
            handler.setRelevantData( sender,  e);
            handler.ShowDialog();
        }

        public static void registerHandler(ExceptionHandlerConfiguration configuration)
        {
            if(configuration == null)
                configuration = new ExceptionHandlerConfiguration();

            _configuration = configuration;

            Application.SetUnhandledExceptionMode(configuration.unhandledExceptionMode);
            Application.ThreadException += threadExceptionEventHandler;
        }

        protected ExceptionHandler()
        {
            InitializeComponent();

            exceptionHandlerOptionExit.setCallback(new EventHandler(exitCallback));
        }

        private void exitCallback(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected void setRelevantData(object sender, ThreadExceptionEventArgs e)
        {
            _threadExceptionEventArgs = e;
            _sender = sender;
        }


    }
}
