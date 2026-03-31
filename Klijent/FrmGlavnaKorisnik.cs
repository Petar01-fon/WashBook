using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;

namespace Klijent
{
    public partial class FrmGlavnaKorisnik : Form
    {
        private Button aktivnoDugme;
        public FrmGlavnaKorisnik()
        {
            InitializeComponent();
            StilizujSidebar();
        }

        private void StilizujSidebar()
        {
            lblLogo.Text = "🚗 WashBook";
            lblLogo.ForeColor = Color.White;
            lblLogo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            lblLogo.Height = 70;
            lblLogo.Padding = new Padding(0, 10, 0, 10);

            lblKorisnik.ForeColor = Color.FromArgb(150, 180, 210);
            lblKorisnik.Font = new Font("Segoe UI", 9);
            lblKorisnik.TextAlign = ContentAlignment.MiddleCenter;
            lblKorisnik.Height = 35;

            Panel separator = new Panel
            {
                Height = 1,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(50, 80, 110)
            };
            pnlSidebar.Controls.Add(separator);

            StilizujDugme(btnMojeRezervacije, "📋  Moje rezervacije");
            StilizujDugme(btnNovaRezervacija, "➕  Nova rezervacija");
            StilizujDugme(btnOdjava, "🚪  Odjava");

            btnOdjava.ForeColor = Color.FromArgb(220, 100, 100);
        }

        private void StilizujDugme(Button btn, string tekst)
        {
            btn.Text = tekst;
            btn.ForeColor = Color.FromArgb(200, 220, 240);
            btn.BackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 60, 90);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(46, 134, 222);
            btn.Font = new Font("Segoe UI", 10);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Height = 48;
            btn.Cursor = Cursors.Hand;
        }

        private void btnMojeRezervacije_Click(object sender, EventArgs e)
        {
            PostaviAktivnoDugme(btnMojeRezervacije);
            PrikaziKontrol(new UcMojeRezervacije());
        }

        private void btnNovaRezervacija_Click(object sender, EventArgs e)
        {

            PostaviAktivnoDugme(btnNovaRezervacija);
            PrikaziKontrol(new UCNovaRez());
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Da li ste sigurni da želite da se odjavite?",
                "Odjava", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
                MainCoordinator.Instanca.Odjavi();
        }

        private void FrmGlavnaKorisnik_Load(object sender, EventArgs e)
        {
            Korisnik k = MainCoordinator.Instanca.PrijavljeniKorisnik;
            lblKorisnik.Text = $"{k.Ime} {k.Prezime}";
            PrikaziKontrol(new UcMojeRezervacije());
            PostaviAktivnoDugme(btnMojeRezervacije);
        }

        private void PostaviAktivnoDugme(Button btn)
        {
            if (aktivnoDugme != null)
            {
                aktivnoDugme.BackColor = Color.Transparent;
                aktivnoDugme.ForeColor = Color.FromArgb(200, 220, 240);
            }
            aktivnoDugme = btn;
            aktivnoDugme.BackColor = Color.FromArgb(46, 134, 222);
            aktivnoDugme.ForeColor = Color.White;
        }

        private void PrikaziKontrol(UserControl uc)
        {
            pnlSadrzaj.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlSadrzaj.Controls.Add(uc);
        }
    }
}
