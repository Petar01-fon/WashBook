namespace Klijent
{
    partial class FrmGlavnaRadnik
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
            pnlSidebar = new Panel();
            btnOdjava = new Button();
            btnPretraga = new Button();
            btnNovaRezervacija = new Button();
            btnSveRezervacije = new Button();
            lblKorisnik = new Label();
            lblLogo = new Label();
            pnlSadrzaj = new Panel();
            pnlSidebar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(30, 42, 58);
            pnlSidebar.Controls.Add(btnOdjava);
            pnlSidebar.Controls.Add(btnPretraga);
            pnlSidebar.Controls.Add(btnNovaRezervacija);
            pnlSidebar.Controls.Add(btnSveRezervacije);
            pnlSidebar.Controls.Add(lblKorisnik);
            pnlSidebar.Controls.Add(lblLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Padding = new Padding(10, 20, 10, 0);
            pnlSidebar.Size = new Size(220, 603);
            pnlSidebar.TabIndex = 0;
            // 
            // btnOdjava
            // 
            btnOdjava.Dock = DockStyle.Top;
            btnOdjava.Location = new Point(10, 147);
            btnOdjava.Name = "btnOdjava";
            btnOdjava.Size = new Size(200, 29);
            btnOdjava.TabIndex = 4;
            btnOdjava.Text = "button1";
            btnOdjava.UseVisualStyleBackColor = true;
            btnOdjava.Click += btnOdjava_Click;
            // 
            // btnPretraga
            // 
            btnPretraga.Dock = DockStyle.Top;
            btnPretraga.Location = new Point(10, 118);
            btnPretraga.Name = "btnPretraga";
            btnPretraga.Size = new Size(200, 29);
            btnPretraga.TabIndex = 3;
            btnPretraga.Text = "button1";
            btnPretraga.UseVisualStyleBackColor = true;
            btnPretraga.Click += btnPretraga_Click;
            // 
            // btnNovaRezervacija
            // 
            btnNovaRezervacija.Dock = DockStyle.Top;
            btnNovaRezervacija.Location = new Point(10, 89);
            btnNovaRezervacija.Name = "btnNovaRezervacija";
            btnNovaRezervacija.Size = new Size(200, 29);
            btnNovaRezervacija.TabIndex = 2;
            btnNovaRezervacija.Text = "button1";
            btnNovaRezervacija.UseVisualStyleBackColor = true;
            btnNovaRezervacija.Click += btnNovaRezervacija_Click;
            // 
            // btnSveRezervacije
            // 
            btnSveRezervacije.Dock = DockStyle.Top;
            btnSveRezervacije.Location = new Point(10, 60);
            btnSveRezervacije.Name = "btnSveRezervacije";
            btnSveRezervacije.Size = new Size(200, 29);
            btnSveRezervacije.TabIndex = 2;
            btnSveRezervacije.Text = "button1";
            btnSveRezervacije.UseVisualStyleBackColor = true;
            btnSveRezervacije.Click += btnSveRezervacije_Click;
            // 
            // lblKorisnik
            // 
            lblKorisnik.AutoSize = true;
            lblKorisnik.Dock = DockStyle.Top;
            lblKorisnik.Location = new Point(10, 40);
            lblKorisnik.Name = "lblKorisnik";
            lblKorisnik.Size = new Size(50, 20);
            lblKorisnik.TabIndex = 1;
            lblKorisnik.Text = "label1";
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Location = new Point(10, 20);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(0, 20);
            lblLogo.TabIndex = 0;
            // 
            // pnlSadrzaj
            // 
            pnlSadrzaj.Dock = DockStyle.Fill;
            pnlSadrzaj.Location = new Point(220, 0);
            pnlSadrzaj.Name = "pnlSadrzaj";
            pnlSadrzaj.Padding = new Padding(20);
            pnlSadrzaj.Size = new Size(862, 603);
            pnlSadrzaj.TabIndex = 1;
            // 
            // FrmGlavnaRadnik
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 246, 249);
            ClientSize = new Size(1082, 603);
            Controls.Add(pnlSadrzaj);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1100, 650);
            Name = "FrmGlavnaRadnik";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WashBook";
            Load += FrmGlavnaRadnik_Load;
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Panel pnlSadrzaj;
        private Button btnPretraga;
        private Button btnNovaRezervacija;
        private Button btnSveRezervacije;
        private Label lblKorisnik;
        private Label lblLogo;
        private Button btnOdjava;
    }
}