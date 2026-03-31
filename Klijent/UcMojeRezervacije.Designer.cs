namespace Klijent
{
    partial class UcMojeRezervacije
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
            btnStorniraj = new Button();
            btnRefresh = new Button();
            lblNaslov = new Label();
            dgvRezervacije = new DataGridView();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(btnStorniraj);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(833, 60);
            pnlHeader.TabIndex = 0;
            // 
            // btnStorniraj
            // 
            btnStorniraj.Dock = DockStyle.Right;
            btnStorniraj.Location = new Point(645, 0);
            btnStorniraj.Name = "btnStorniraj";
            btnStorniraj.Size = new Size(94, 60);
            btnStorniraj.TabIndex = 2;
            btnStorniraj.Text = "❌Storniraj";
            btnStorniraj.UseVisualStyleBackColor = true;
            btnStorniraj.Click += btnStorniraj_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Right;
            btnRefresh.Location = new Point(739, 0);
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
            lblNaslov.Size = new Size(118, 20);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Moje rezervacije";
            // 
            // dgvRezervacije
            // 
            dgvRezervacije.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRezervacije.Dock = DockStyle.Fill;
            dgvRezervacije.Location = new Point(0, 60);
            dgvRezervacije.Name = "dgvRezervacije";
            dgvRezervacije.RowHeadersWidth = 51;
            dgvRezervacije.Size = new Size(833, 435);
            dgvRezervacije.TabIndex = 1;
            dgvRezervacije.CellDoubleClick += dgvRezervacije_CellDoubleClick;
            // 
            // UcMojeRezervacije
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRezervacije);
            Controls.Add(pnlHeader);
            Name = "UcMojeRezervacije";
            Size = new Size(833, 495);
            Load += UcMojeRezervacije_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRezervacije).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblNaslov;
        private Button btnRefresh;
        private DataGridView dgvRezervacije;
        private Button btnStorniraj;
    }
}
