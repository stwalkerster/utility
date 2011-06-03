using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Utility.Interaction.ExceptionHandler
{
    public partial class ExceptionHandlerOptionItem : UserControl
    {
        private Delegate _callback;
        private string rawbuttontext;

        public ExceptionHandlerOptionItem()
        {
            InitializeComponent();
        }

        public ExceptionHandlerOptionItem(string description, string buttontext, Color buttonColour, Delegate callback) : this()
        {
            _callback = callback;
            descriptionLabel.Text = description;
            rawbuttontext = buttontext;
            actionButton.Text = rawbuttontext + " >>>";
            actionButton.BackColor = buttonColour;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this._callback.DynamicInvoke(sender, e);
        }

        public string Description
        {
            get { return descriptionLabel.Text; }
            set { descriptionLabel.Text = value; }
        }

        public string ButtonText
        {
            get { return rawbuttontext; }
            set
            {
                actionButton.Text = value + " >>>";
                rawbuttontext = value;
            }
        }

        public Color ButtonColour
        { get { return actionButton.BackColor; } set { actionButton.BackColor = value; } }

        public void setCallback(Delegate callback)
        {
            this._callback = callback;
        }
    }
}
