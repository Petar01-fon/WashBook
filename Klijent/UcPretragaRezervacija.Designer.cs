namespace Klijent
{
    partial class UcPretragaRezervacija
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
            pnlHeader = new Panel();
            lblNaslov = new Label();
            pnlFilter = new Panel();
            btnPretrazi = new Button();
            cmbStatus = new ComboBox();
            dtpDatum = new DateTimePicker();
            lblStatus = new Label();
            lblDatumOd = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvRezervacije = new DataGridView();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(899, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Dock = DockStyle.Left;
            lblNaslov.Location = new Point(0, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(140, 20);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Pretraga rezervacija";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(244, 246, 249);
            pnlFilter.Controls.Add(btnPretrazi);
            pnlFilter.Controls.Add(cmbStatus);
            pnlFilter.Controls.Add(dtpDatum);
            pnlFilter.Controls.Add(lblStatus);
            pnlFilter.Controls.Add(lblDatumOd);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 60);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(20);
            pnlFilter.Size = new Size(899, 70);
            pnlFilter.TabIndex = 1;
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(678, 21);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(150, 29);
            btnPretrazi.TabIndex = 3;
            btnPretrazi.Text = "🔍 Pretraži";
            btnPretrazi.UseVisualStyleBackColor = true;
            btnPretrazi.Click += btnPretrazi_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(391, 22);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(151, 28);
            cmbStatus.TabIndex = 2;
            // 
            // dtpDatum
            // 
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(98, 22);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(163, 27);
            dtpDatum.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(300, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 20);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Status:";
            // 
            // lblDatumOd
            // 
            lblDatumOd.AutoSize = true;
            lblDatumOd.Location = new Point(23, 27);
            lblDatumOd.Name = "lblDatumOd";
            lblDatumOd.Size = new Size(57, 20);
            lblDatumOd.TabIndex = 0;
            lblDatumOd.Text = "Datum:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvRezervacije
            // 
            dgvRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRezervacije.Dock = DockStyle.Fill;
            dgvRezervacije.Location = new Point(0, 130);
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.RowHeadersWidth = 51;
            dgvRezervacije.Size = new Size(899, 374);
            dgvRezervacije.TabIndex = 3;
            // 
            // UcPretragaRezervacija
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRezervacije);
            Controls.Add(pnlFilter);
            Controls.Add(pnlHeader);
            Name = "UcPretragaRezervacija";
            Size = new Size(899, 504);
            Load += UcPretragaRezervacija_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblNaslov;
        private Panel pnlFilter;
        private DateTimePicker dtpDatum;
        private Label lblStatus;
        private Label lblDatumOd;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Button btnPretrazi;
        private ComboBox cmbStatus;
        private DataGridView dgvRezervacije;
    }
}
