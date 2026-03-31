using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent
{
    public partial class FrmPromeniStatus : Form
    {
        private Rezervacija rezervacija;
        public FrmPromeniStatus(Rezervacija rezervacija)
        {
            InitializeComponent();
            this.rezervacija = rezervacija;
            StilizujFormu();

        }

        private void StilizujFormu()
        {
            BackColor = Color.FromArgb(244, 246, 249);

            lblInfo.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblInfo.ForeColor = Color.FromArgb(30, 42, 58);
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            lblInfo.Height = 60;
            lblInfo.Padding = new Padding(0, 10, 0, 10);

            lblStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(80, 100, 120);

            cmbStatus.Font = new Font("Segoe UI", 10);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Height = 36;

            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSacuvaj.Height = 44;
            btnSacuvaj.Cursor = Cursors.Hand;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Izaberite status.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((StatusRezervacije)cmbStatus.SelectedItem == rezervacija.StatusRezervacije)
            {
                MessageBox.Show("Status nije promenjen.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                rezervacija.StatusRezervacije = (StatusRezervacije)cmbStatus.SelectedItem;

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.PromeniRezervaciju, rezervacija);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Status je uspešno promenjen!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPromeniStatus_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Rezervacija #{rezervacija.IdRezervacija}\n" +
                           $"Termin: {rezervacija.Termin:dd.MM.yyyy HH:mm}";

            foreach (StatusRezervacije s in Enum.GetValues(typeof(StatusRezervacije)))
                cmbStatus.Items.Add(s);

            cmbStatus.SelectedItem = rezervacija.StatusRezervacije;
        }
    }
}
