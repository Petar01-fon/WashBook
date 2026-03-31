namespace Klijent
{
    partial class UcSveRezervacije
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
            btnObrisi = new Button();
            btnRefresh = new Button();
            lblNaslov = new Label();
            dgvRezervacije = new DataGridView();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnObrisi);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(736, 60);
            pnlHeader.TabIndex = 0;
            // 
            // btnObrisi
            // 
            btnObrisi.Dock = DockStyle.Right;
            btnObrisi.Location = new Point(548, 0);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(94, 60);
            btnObrisi.TabIndex = 2;
            btnObrisi.Text = "🗑️Obriši";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Right;
            btnRefresh.Location = new Point(642, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 60);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "🔄 Osveži";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Dock = DockStyle.Left;
            lblNaslov.Location = new Point(0, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(107, 20);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Sve rezervacije";
            // 
            // dgvRezervacije
            // 
            dgvRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRezervacije.Dock = DockStyle.Fill;
            dgvRezervacije.Location = new Point(0, 60);
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.RowHeadersWidth = 51;
            dgvRezervacije.Size = new Size(736, 360);
            dgvRezervacije.TabIndex = 1;
            dgvRezervacije.CellDoubleClick += dgvRezervacije_CellDoubleClick;
            // 
            // UcSveRezervacije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRezervacije);
            Controls.Add(pnlHeader);
            Name = "UcSveRezervacije";
            Size = new Size(736, 420);
            Load += UcSveRezervacije_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnRefresh;
        private Label lblNaslov;
        private DataGridView dgvRezervacije;
        private Button btnObrisi;
    }
}
