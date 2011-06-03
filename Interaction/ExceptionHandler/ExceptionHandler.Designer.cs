namespace Utility.Interaction.ExceptionHandler
{
    partial class ExceptionHandler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optionListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.exceptionHandlerOptionExit = new Utility.Interaction.ExceptionHandler.ExceptionHandlerOptionItem();
            this.exceptionHandlerOptionContinue = new Utility.Interaction.ExceptionHandler.ExceptionHandlerOptionItem();
            this.exceptionHandlerOptionSendReport = new Utility.Interaction.ExceptionHandler.ExceptionHandlerOptionItem();
            this.exceptionHandlerOptionBugTracker = new Utility.Interaction.ExceptionHandler.ExceptionHandlerOptionItem();
            this.exceptionHandlerOptionGitHub = new Utility.Interaction.ExceptionHandler.ExceptionHandlerOptionItem();
            this.exceptionHandlerOptionTechInfo = new Utility.Interaction.ExceptionHandler.ExceptionHandlerOptionItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.optionListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 614F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.optionListPanel, 2, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(780, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Utility.Properties.Resources.core;
            this.pictureBox1.Location = new System.Drawing.Point(3, 41);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(128, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.tableLayoutPanel1.SetRowSpan(this.pictureBox1, 2);
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Whoops! Something went wrong!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(639, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Well, it looks like something unexpected has gone wrong somewhere, and it\'s broug" +
                "ht the whole program crashing down with it. Sorry about that.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "At this point, you have several options:";
            // 
            // optionListPanel
            // 
            this.optionListPanel.AutoScroll = true;
            this.optionListPanel.Controls.Add(this.exceptionHandlerOptionSendReport);
            this.optionListPanel.Controls.Add(this.exceptionHandlerOptionBugTracker);
            this.optionListPanel.Controls.Add(this.exceptionHandlerOptionGitHub);
            this.optionListPanel.Controls.Add(this.exceptionHandlerOptionTechInfo);
            this.optionListPanel.Controls.Add(this.exceptionHandlerOptionContinue);
            this.optionListPanel.Controls.Add(this.exceptionHandlerOptionExit);
            this.optionListPanel.Location = new System.Drawing.Point(169, 122);
            this.optionListPanel.Name = "optionListPanel";
            this.optionListPanel.Size = new System.Drawing.Size(608, 138);
            this.optionListPanel.TabIndex = 4;
            // 
            // exceptionHandlerOptionExit
            // 
            this.exceptionHandlerOptionExit.ButtonColour = System.Drawing.Color.MistyRose;
            this.exceptionHandlerOptionExit.ButtonText = "Exit";
            this.exceptionHandlerOptionExit.Description = "Exit the Application";
            this.exceptionHandlerOptionExit.Location = new System.Drawing.Point(3, 178);
            this.exceptionHandlerOptionExit.MaximumSize = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionExit.Name = "exceptionHandlerOptionExit";
            this.exceptionHandlerOptionExit.Size = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionExit.TabIndex = 6;
            // 
            // exceptionHandlerOptionContinue
            // 
            this.exceptionHandlerOptionContinue.ButtonColour = System.Drawing.Color.Honeydew;
            this.exceptionHandlerOptionContinue.ButtonText = "Continue";
            this.exceptionHandlerOptionContinue.Description = "Attempt to continue (could cause application instability and lost data)";
            this.exceptionHandlerOptionContinue.Location = new System.Drawing.Point(3, 143);
            this.exceptionHandlerOptionContinue.MaximumSize = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionContinue.Name = "exceptionHandlerOptionContinue";
            this.exceptionHandlerOptionContinue.Size = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionContinue.TabIndex = 0;
            // 
            // exceptionHandlerOptionSendReport
            // 
            this.exceptionHandlerOptionSendReport.ButtonColour = System.Drawing.Color.Honeydew;
            this.exceptionHandlerOptionSendReport.ButtonText = "Send Report";
            this.exceptionHandlerOptionSendReport.Description = "Send a crash report to the developer via email";
            this.exceptionHandlerOptionSendReport.Location = new System.Drawing.Point(3, 3);
            this.exceptionHandlerOptionSendReport.MaximumSize = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionSendReport.Name = "exceptionHandlerOptionSendReport";
            this.exceptionHandlerOptionSendReport.Size = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionSendReport.TabIndex = 1;
            // 
            // exceptionHandlerOptionBugTracker
            // 
            this.exceptionHandlerOptionBugTracker.ButtonColour = System.Drawing.Color.Honeydew;
            this.exceptionHandlerOptionBugTracker.ButtonText = "Bug tracker";
            this.exceptionHandlerOptionBugTracker.Description = "Go to the bug tracker to submit a bug report";
            this.exceptionHandlerOptionBugTracker.Location = new System.Drawing.Point(3, 38);
            this.exceptionHandlerOptionBugTracker.MaximumSize = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionBugTracker.Name = "exceptionHandlerOptionBugTracker";
            this.exceptionHandlerOptionBugTracker.Size = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionBugTracker.TabIndex = 2;
            // 
            // exceptionHandlerOptionGitHub
            // 
            this.exceptionHandlerOptionGitHub.ButtonColour = System.Drawing.Color.Honeydew;
            this.exceptionHandlerOptionGitHub.ButtonText = "Browse Source Code";
            this.exceptionHandlerOptionGitHub.Description = "Browse the source code on GitHub";
            this.exceptionHandlerOptionGitHub.Location = new System.Drawing.Point(3, 73);
            this.exceptionHandlerOptionGitHub.MaximumSize = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionGitHub.Name = "exceptionHandlerOptionGitHub";
            this.exceptionHandlerOptionGitHub.Size = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionGitHub.TabIndex = 3;
            // 
            // exceptionHandlerOptionTechInfo
            // 
            this.exceptionHandlerOptionTechInfo.ButtonColour = System.Drawing.Color.Honeydew;
            this.exceptionHandlerOptionTechInfo.ButtonText = "Technical info";
            this.exceptionHandlerOptionTechInfo.Description = "View Technical information about this error";
            this.exceptionHandlerOptionTechInfo.Location = new System.Drawing.Point(3, 108);
            this.exceptionHandlerOptionTechInfo.MaximumSize = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionTechInfo.Name = "exceptionHandlerOptionTechInfo";
            this.exceptionHandlerOptionTechInfo.Size = new System.Drawing.Size(577, 29);
            this.exceptionHandlerOptionTechInfo.TabIndex = 4;
            // 
            // ExceptionHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 284);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionHandler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unhandled Exception";
            this.TopMost = true;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.optionListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel optionListPanel;
        private ExceptionHandlerOptionItem exceptionHandlerOptionExit;
        private ExceptionHandlerOptionItem exceptionHandlerOptionContinue;
        private ExceptionHandlerOptionItem exceptionHandlerOptionSendReport;
        private ExceptionHandlerOptionItem exceptionHandlerOptionBugTracker;
        private ExceptionHandlerOptionItem exceptionHandlerOptionGitHub;
        private ExceptionHandlerOptionItem exceptionHandlerOptionTechInfo;
    }
}