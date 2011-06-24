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
            set { label1.Text = value; }
        }

        private Queue<WorkerTask> taskQueue = new Queue<WorkerTask>();

        public void DoWork(params WorkerTask[] tasks)
        {
            if (backgroundWorker1.IsBusy)
            {// append, display, start
                foreach (var workerTask in tasks)
                {
                    taskQueue.Enqueue(workerTask);
                }
                progressBar1.Value = 0;
                progressBar1.Maximum = taskQueue.Count;
                this.Show();
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {// append, increment progress bar
                foreach (var workerTask in tasks)
                {
                    taskQueue.Enqueue(workerTask);
                }
                progressBar1.Maximum += tasks.Length;
            }
        }


        private void Worker_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (taskQueue.Count != 0)
            {
                WorkerTask t = taskQueue.Dequeue();
                updateLabel(t.ToString());
                t.execute();
                backgroundWorker1.ReportProgress(0);
            }
        }

        private void updateLabel(string descr)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(updateLabel), descr);
            }
            else
            {
                label2.Text = descr;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
