namespace Klijent
{
    partial class FrmPromeniTermin
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
            lblInfo = new Label();
            lblDatum = new Label();
            lblTermin = new Label();
            dtpDatum = new DateTimePicker();
            cmbTermin = new ComboBox();
            btnSacuvaj = new Button();
            SuspendLayout();
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Dock = DockStyle.Top;
            lblInfo.Location = new Point(0, 0);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(50, 20);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "label1";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Location = new Point(45, 69);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(90, 20);
            lblDatum.TabIndex = 1;
            lblDatum.Text = "Novi datum:";
            // 
            // lblTermin
            // 
            lblTermin.AutoSize = true;
            lblTermin.Location = new Point(45, 142);
            lblTermin.Name = "lblTermin";
            lblTermin.Size = new Size(90, 20);
            lblTermin.TabIndex = 2;
            lblTermin.Text = "Novi termin:";
            // 
            // dtpDatum
            // 
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(153, 64);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(179, 27);
            dtpDatum.TabIndex = 3;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // cmbTermin
            // 
            cmbTermin.FormattingEnabled = true;
            cmbTermin.Location = new Point(153, 139);
            cmbTermin.Name = "cmbTermin";
            cmbTermin.Size = new Size(179, 28);
            cmbTermin.TabIndex = 4;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(125, 219);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(109, 42);
            btnSacuvaj.TabIndex = 5;
            btnSacuvaj.Text = "💾 Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // FrmPromeniTermin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 303);
            Controls.Add(btnSacuvaj);
            Controls.Add(cmbTermin);
            Controls.Add(dtpDatum);
            Controls.Add(lblTermin);
            Controls.Add(lblDatum);
            Controls.Add(lblInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmPromeniTermin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Promeni termin rezervacije";
            Load += FrmPromeniTermin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInfo;
        private Label lblDatum;
        private Label lblTermin;
        private DateTimePicker dtpDatum;
        private ComboBox cmbTermin;
        private Button btnSacuvaj;
    }
}