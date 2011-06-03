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
        #region static stuff
        private static ExceptionHandlerConfiguration _configuration;

        public static void threadExceptionEventHandler(object sender, ThreadExceptionEventArgs e)
        {
            if (_configuration == null)
                _configuration = new ExceptionHandlerConfiguration();

            ExceptionHandler handler = new ExceptionHandler();
            handler.isRecoverable = true;
            handler.setupDialog(sender, e.Exception);
            handler.ShowDialog();
        }

        public static void currentDomainUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            if (_configuration == null)
                _configuration = new ExceptionHandlerConfiguration();

            ExceptionHandler handler = new ExceptionHandler();
            handler.isRecoverable = false;
            handler.setupDialog(sender, (Exception) e.ExceptionObject);
            handler.ShowDialog();
        }

        public static void registerHandler(ExceptionHandlerConfiguration configuration)
        {
            setConfiguration(configuration);

            Application.ThreadException += threadExceptionEventHandler;
        }

        public static void setConfiguration(ExceptionHandlerConfiguration configuration)
        {
            if (configuration == null)
                configuration = new ExceptionHandlerConfiguration();

            _configuration = configuration;
        }
        #endregion
        
        private object _sender;
        private Exception _exception;

        public bool isRecoverable { get; private set; }

        protected ExceptionHandler()
        {
            InitializeComponent();
            
            if (_configuration == null)
                _configuration = new ExceptionHandlerConfiguration();
        }

        private void bugtrackerCallback(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_configuration.bugTracker);
        }

        private void continueCallback(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitCallback(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void githubCallback(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/" + _configuration.gitHubRepository);
        }

        private void emailCallback(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void techinfoCallback(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void setupDialog(object sender, Exception e)
        {
            _exception = e;
            _sender = sender;


            exceptionHandlerOptionBugTracker.Visible = (_configuration.bugTracker != string.Empty);
            exceptionHandlerOptionBugTracker.setCallback(new EventHandler(bugtrackerCallback));

            exceptionHandlerOptionContinue.Visible = isRecoverable;
            exceptionHandlerOptionContinue.setCallback(new EventHandler(continueCallback));

            exceptionHandlerOptionExit.setCallback(new EventHandler(exitCallback));

            exceptionHandlerOptionGitHub.Visible = (_configuration.gitHubRepository != string.Empty);
            exceptionHandlerOptionGitHub.setCallback(new EventHandler(githubCallback));

            exceptionHandlerOptionSendReport.Visible = (_configuration.contactEmailAddress != string.Empty);
            exceptionHandlerOptionSendReport.setCallback(new EventHandler(emailCallback));

            exceptionHandlerOptionTechInfo.Visible = _configuration.showTechnicalInformation;
            exceptionHandlerOptionTechInfo.setCallback(new EventHandler(techinfoCallback));


        }


    }
}
