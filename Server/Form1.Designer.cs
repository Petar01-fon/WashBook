namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbLogovi = new ListBox();
            btnStart = new Button();
            btnStop = new Button();
            SuspendLayout();
            // 
            // lbLogovi
            // 
            lbLogovi.FormattingEnabled = true;
            lbLogovi.Location = new Point(12, 12);
            lbLogovi.Name = "lbLogovi";
            lbLogovi.Size = new Size(436, 204);
            lbLogovi.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 222);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(210, 29);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(228, 222);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(220, 29);
            btnStop.TabIndex = 2;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 264);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(lbLogovi);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbLogovi;
        private Button btnStart;
        private Button btnStop;
    }
}
