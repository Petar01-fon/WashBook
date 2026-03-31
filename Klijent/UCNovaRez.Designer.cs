namespace Klijent
{
    partial class UCNovaRez
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
            lblNaslov = new Label();
            pnlForma = new Panel();
            txtRegistracija = new TextBox();
            btnSacuvaj = new Button();
            dtpDatum = new DateTimePicker();
            cmbUsluga = new ComboBox();
            cmbTipVozila = new ComboBox();
            lblCena = new Label();
            lblC = new Label();
            lblRegistracija = new Label();
            lblUsluga = new Label();
            cmbTermin = new ComboBox();
            lblTipVozila = new Label();
            cmbIzbor = new ComboBox();
            lblTermin = new Label();
            lblDatum = new Label();
            lblIzbor = new Label();
            pnlHeader = new Panel();
            pnlForma.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // lblNaslov
            // 
            lblNaslov.AutoSize = true;
            lblNaslov.Dock = DockStyle.Left;
            lblNaslov.Location = new Point(0, 0);
            lblNaslov.Name = "lblNaslov";
            lblNaslov.Size = new Size(119, 20);
            lblNaslov.TabIndex = 0;
            lblNaslov.Text = "Nova rezervacija";
            // 
            // pnlForma
            // 
            pnlForma.Controls.Add(txtRegistracija);
            pnlForma.Controls.Add(btnSacuvaj);
            pnlForma.Controls.Add(dtpDatum);
            pnlForma.Controls.Add(cmbUsluga);
            pnlForma.Controls.Add(cmbTipVozila);
            pnlForma.Controls.Add(lblCena);
            pnlForma.Controls.Add(lblC);
            pnlForma.Controls.Add(lblRegistracija);
            pnlForma.Controls.Add(lblUsluga);
            pnlForma.Controls.Add(cmbTermin);
            pnlForma.Controls.Add(lblTipVozila);
            pnlForma.Controls.Add(cmbIzbor);
            pnlForma.Controls.Add(lblTermin);
            pnlForma.Controls.Add(lblDatum);
            pnlForma.Controls.Add(lblIzbor);
            pnlForma.Dock = DockStyle.Fill;
            pnlForma.Location = new Point(0, 60);
            pnlForma.Name = "pnlForma";
            pnlForma.Padding = new Padding(30);
            pnlForma.Size = new Size(890, 435);
            pnlForma.TabIndex = 3;
            // 
            // txtRegistracija
            // 
            txtRegistracija.Location = new Point(400, 265);
            txtRegistracija.Name = "txtRegistracija";
            txtRegistracija.Size = new Size(175, 27);
            txtRegistracija.TabIndex = 4;
            // 
            // btnSacuvaj
            // 
            btnSacuvaj.Location = new Point(643, 320);
            btnSacuvaj.Name = "btnSacuvaj";
            btnSacuvaj.Size = new Size(110, 41);
            btnSacuvaj.TabIndex = 3;
            btnSacuvaj.Text = "Sačuvaj";
            btnSacuvaj.UseVisualStyleBackColor = true;
            btnSacuvaj.Click += btnSacuvaj_Click;
            // 
            // dtpDatum
            // 
            dtpDatum.Format = DateTimePickerFormat.Short;
            dtpDatum.Location = new Point(400, 79);
            dtpDatum.Name = "dtpDatum";
            dtpDatum.Size = new Size(175, 27);
            dtpDatum.TabIndex = 2;
            dtpDatum.ValueChanged += dtpDatum_ValueChanged;
            // 
            // cmbUsluga
            // 
            cmbUsluga.FormattingEnabled = true;
            cmbUsluga.Location = new Point(400, 222);
            cmbUsluga.Name = "cmbUsluga";
            cmbUsluga.Size = new Size(175, 28);
            cmbUsluga.TabIndex = 1;
            cmbUsluga.SelectedIndexChanged += cmbUsluga_SelectedIndexChanged;
            // 
            // cmbTipVozila
            // 
            cmbTipVozila.FormattingEnabled = true;
            cmbTipVozila.Location = new Point(400, 174);
            cmbTipVozila.Name = "cmbTipVozila";
            cmbTipVozila.Size = new Size(175, 28);
            cmbTipVozila.TabIndex = 1;
            cmbTipVozila.SelectedIndexChanged += cmbTipVozila_SelectedIndexChanged;
            // 
            // lblCena
            // 
            lblCena.AutoSize = true;
            lblCena.Location = new Point(400, 320);
            lblCena.Name = "lblCena";
            lblCena.Size = new Size(0, 20);
            lblCena.TabIndex = 0;
            // 
            // lblC
            // 
            lblC.AutoSize = true;
            lblC.Location = new Point(252, 320);
            lblC.Name = "lblC";
            lblC.Size = new Size(45, 20);
            lblC.TabIndex = 0;
            lblC.Text = "Cena:";
            // 
            // lblRegistracija
            // 
            lblRegistracija.AutoSize = true;
            lblRegistracija.Location = new Point(252, 268);
            lblRegistracija.Name = "lblRegistracija";
            lblRegistracija.Size = new Size(89, 20);
            lblRegistracija.TabIndex = 0;
            lblRegistracija.Text = "Registracija:";
            // 
            // lblUsluga
            // 
            lblUsluga.AutoSize = true;
            lblUsluga.Location = new Point(252, 225);
            lblUsluga.Name = "lblUsluga";
            lblUsluga.Size = new Size(57, 20);
            lblUsluga.TabIndex = 0;
            lblUsluga.Text = "Usluga:";
            // 
            // cmbTermin
            // 
            cmbTermin.FormattingEnabled = true;
            cmbTermin.Location = new Point(400, 126);
            cmbTermin.Name = "cmbTermin";
            cmbTermin.Size = new Size(175, 28);
            cmbTermin.TabIndex = 1;
            // 
            // lblTipVozila
            // 
            lblTipVozila.AutoSize = true;
            lblTipVozila.Location = new Point(252, 177);
            lblTipVozila.Name = "lblTipVozila";
            lblTipVozila.Size = new Size(76, 20);
            lblTipVozila.TabIndex = 0;
            lblTipVozila.Text = "Tip vozila:";
            // 
            // cmbIzbor
            // 
            cmbIzbor.FormattingEnabled = true;
            cmbIzbor.Location = new Point(400, 31);
            cmbIzbor.Name = "cmbIzbor";
            cmbIzbor.Size = new Size(175, 28);
            cmbIzbor.TabIndex = 1;
            // 
            // lblTermin
            // 
            lblTermin.AutoSize = true;
            lblTermin.Location = new Point(252, 129);
            lblTermin.Name = "lblTermin";
            lblTermin.Size = new Size(57, 20);
            lblTermin.TabIndex = 0;
            lblTermin.Text = "Termin:";
            // 
            // lblDatum
            // 
            lblDatum.AutoSize = true;
            lblDatum.Location = new Point(252, 81);
            lblDatum.Name = "lblDatum";
            lblDatum.Size = new Size(132, 20);
            lblDatum.TabIndex = 0;
            lblDatum.Text = "Datum rezervacije:";
            // 
            // lblIzbor
            // 
            lblIzbor.AutoSize = true;
            lblIzbor.Location = new Point(252, 34);
            lblIzbor.Name = "lblIzbor";
            lblIzbor.Size = new Size(60, 20);
            lblIzbor.TabIndex = 0;
            lblIzbor.Text = "lblIzbor";
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblNaslov);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(890, 60);
            pnlHeader.TabIndex = 2;
            // 
            // UCNovaRez
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlForma);
            Controls.Add(pnlHeader);
            Name = "UCNovaRez";
            Size = new Size(890, 495);
            Load += UserControl1_Load;
            pnlForma.ResumeLayout(false);
            pnlForma.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNaslov;
        private Panel pnlForma;
        private Button btnSacuvaj;
        private DateTimePicker dtpDatum;
        private ComboBox cmbTermin;
        private ComboBox cmbIzbor;
        private Label lblTermin;
        private Label lblDatum;
        private Label lblIzbor;
        private Panel pnlHeader;
        private ComboBox cmbTipVozila;
        private Label lblTipVozila;
        private ComboBox cmbUsluga;
        private Label lblUsluga;
        private TextBox txtRegistracija;
        private Label lblCena;
        private Label lblC;
        private Label lblRegistracija;
    }
}
