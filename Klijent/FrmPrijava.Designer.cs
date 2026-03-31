namespace Klijent
{
    partial class FrmPrijava
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
            label1 = new Label();
            txtKorisnickoIme = new TextBox();
            btnPrijava = new Button();
            label2 = new Label();
            txtSifra = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 39);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Korisničko ime:";
            // 
            // txtKorisnickoIme
            // 
            txtKorisnickoIme.Location = new Point(157, 36);
            txtKorisnickoIme.Name = "txtKorisnickoIme";
            txtKorisnickoIme.Size = new Size(139, 27);
            txtKorisnickoIme.TabIndex = 1;
            // 
            // btnPrijava
            // 
            btnPrijava.Location = new Point(202, 125);
            btnPrijava.Name = "btnPrijava";
            btnPrijava.Size = new Size(94, 29);
            btnPrijava.TabIndex = 2;
            btnPrijava.Text = "Prijava";
            btnPrijava.UseVisualStyleBackColor = true;
            btnPrijava.Click += btnPrijava_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 72);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 0;
            label2.Text = "Šifra:";
            // 
            // txtSifra
            // 
            txtSifra.Location = new Point(157, 69);
            txtSifra.Name = "txtSifra";
            txtSifra.Size = new Size(139, 27);
            txtSifra.TabIndex = 1;
            // 
            // FormPrijava
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 189);
            Controls.Add(btnPrijava);
            Controls.Add(txtSifra);
            Controls.Add(label2);
            Controls.Add(txtKorisnickoIme);
            Controls.Add(label1);
            Name = "FormPrijava";
            Text = "FormPrijava";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtKorisnickoIme;
        private Button btnPrijava;
        private Label label2;
        private TextBox txtSifra;
    }
}
