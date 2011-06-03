namespace Utility.Interaction.ExceptionHandler
{
    partial class ExceptionHandlerOptionItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionButton = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // actionButton
            // 
            this.actionButton.BackColor = System.Drawing.Color.Honeydew;
            this.actionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionButton.Location = new System.Drawing.Point(431, 3);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(143, 23);
            this.actionButton.TabIndex = 7;
            this.actionButton.Text = "{1} >>>";
            this.actionButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.actionButton.UseVisualStyleBackColor = false;
            this.actionButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionLabel.Location = new System.Drawing.Point(3, 6);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(25, 16);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "{0}";
            // 
            // ExceptionHandlerOptionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.descriptionLabel);
            this.MaximumSize = new System.Drawing.Size(577, 29);
            this.Name = "ExceptionHandlerOptionItem";
            this.Size = new System.Drawing.Size(577, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Label descriptionLabel;
    }
}
