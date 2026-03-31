using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Klijent
{
    public partial class FrmPromeniTermin : Form
    {
        private Rezervacija rezervacija;
        public FrmPromeniTermin(Rezervacija rezervacija)
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

            lblDatum.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblDatum.ForeColor = Color.FromArgb(80, 100, 120);

            lblTermin.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTermin.ForeColor = Color.FromArgb(80, 100, 120);

            dtpDatum.Font = new Font("Segoe UI", 10);

            cmbTermin.Font = new Font("Segoe UI", 10);
            cmbTermin.DropDownStyle = ComboBoxStyle.DropDownList;

            btnSacuvaj.FlatStyle = FlatStyle.Flat;
            btnSacuvaj.FlatAppearance.BorderSize = 0;
            btnSacuvaj.BackColor = Color.FromArgb(46, 134, 222);
            btnSacuvaj.ForeColor = Color.White;
            btnSacuvaj.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnSacuvaj.Height = 44;
            btnSacuvaj.Cursor = Cursors.Hand;
        }

        private void FrmPromeniTermin_Load(object sender, EventArgs e)
        {
            lblInfo.Text = $"Rezervacija #{rezervacija.IdRezervacija}\n" +
                         $"Trenutni termin: {rezervacija.Termin:dd.MM.yyyy HH:mm}";

            dtpDatum.Value = rezervacija.Termin.Date;
            dtpDatum.MinDate = DateTime.Today;

            UcitajSlobodneTermine(rezervacija.Termin.Date, rezervacija.Termin);
        }

        private void UcitajSlobodneTermine(DateTime datum, DateTime trenutniTermin)
        {
            try
            {
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiZauzeteTermine, datum);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<DateTime> zauzeti = Komunikacija.Instance
                    .Serializer.ReadType<List<DateTime>>(odgovor.Objekat);

                List<DateTime> slobodni = new List<DateTime>();
                for (int sat = 8; sat <= 19; sat++)
                {
                    DateTime t = datum.Date.AddHours(sat);
                    bool jeZauzet = zauzeti.Any(z => z.Hour == sat);
                    bool jeKurrentni = t.Hour == trenutniTermin.Hour
                                    && datum.Date == trenutniTermin.Date;
                    if (!jeZauzet || jeKurrentni)
                        slobodni.Add(t);
                }

                cmbTermin.DataSource = null;
                cmbTermin.DataSource = slobodni;
                cmbTermin.Format += (s, ev) =>
                {
                    if (ev.Value is DateTime dt)
                        ev.Value = dt.ToString("HH:mm");
                };

                cmbTermin.SelectedItem = slobodni
                    .FirstOrDefault(t => t.Hour == trenutniTermin.Hour);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (cmbTermin.SelectedItem == null)
            {
                MessageBox.Show("Izaberite termin.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime noviTermin = (DateTime)cmbTermin.SelectedItem;

            if (noviTermin == rezervacija.Termin)
            {
                MessageBox.Show("Termin nije promenjen.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                rezervacija.Termin = noviTermin;

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.PromeniRezervaciju, rezervacija);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Termin je uspešno promenjen!", "Uspeh",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDatum_ValueChanged(object sender, EventArgs e)
        {
            UcitajSlobodneTermine(dtpDatum.Value, DateTime.MinValue);
        }
    }
}
