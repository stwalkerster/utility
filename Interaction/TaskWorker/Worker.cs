using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Utility.Interaction.TaskWorker
{
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The text that appears on the main form itself.
        /// </summary>
        public string Description
        {
            get { return label1.Text; }
            set { label1.Text = value;}
        }

        public void DoWork(params WorkerTask[] tasks)
        {
            
        }


        private void Worker_Load(object sender, EventArgs e)
        {

        }
    }
}
