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
    public partial class UcPretragaRezervacija : UserControl
    {
        public UcPretragaRezervacija()
        {
            InitializeComponent();
            StilizujKontrole();
        }

        private void StilizujKontrole()
        {
            pnlHeader.BackColor = Color.White;
            pnlHeader.Padding = new Padding(20, 0, 20, 0);

            lblNaslov.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblNaslov.ForeColor = Color.FromArgb(30, 42, 58);
            lblNaslov.TextAlign = ContentAlignment.MiddleLeft;

            pnlFilter.BackColor = Color.FromArgb(244, 246, 249);
            pnlFilter.Padding = new Padding(20, 10, 20, 10);

            Font labelFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Color labelColor = Color.FromArgb(80, 100, 120);
            foreach (Control c in pnlFilter.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.Font = labelFont;
                    lbl.ForeColor = labelColor;
                }
            }

            dtpDatum.Font = new Font("Segoe UI", 10);

            cmbStatus.Font = new Font("Segoe UI", 10);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;

            btnPretrazi.FlatStyle = FlatStyle.Flat;
            btnPretrazi.FlatAppearance.BorderSize = 0;
            btnPretrazi.BackColor = Color.FromArgb(46, 134, 222);
            btnPretrazi.ForeColor = Color.White;
            btnPretrazi.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnPretrazi.Height = 36;
            btnPretrazi.Width = 120;
            btnPretrazi.Cursor = Cursors.Hand;

            // DGV stil
            dgvRezervacije.BackgroundColor = Color.FromArgb(244, 246, 249);
            dgvRezervacije.BorderStyle = BorderStyle.None;
            dgvRezervacije.RowHeadersVisible = false;
            dgvRezervacije.AllowUserToAddRows = false;
            dgvRezervacije.ReadOnly = true;
            dgvRezervacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRezervacije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRezervacije.Font = new Font("Segoe UI", 9);
            dgvRezervacije.RowTemplate.Height = 40;
            dgvRezervacije.GridColor = Color.FromArgb(220, 228, 240);
            dgvRezervacije.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 42, 58);
            dgvRezervacije.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvRezervacije.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvRezervacije.ColumnHeadersHeight = 44;
            dgvRezervacije.EnableHeadersVisualStyles = false;
            dgvRezervacije.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 134, 222);
            dgvRezervacije.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRezervacije.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvRezervacije.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            try
            {
                string condition = IzgradiUslov();

                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.VratiListuRezervacija, condition);

                if (!odgovor.Uspesno)
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<Rezervacija> lista = Komunikacija.Instance
                    .Serializer.ReadType<List<Rezervacija>>(odgovor.Objekat);

                dgvRezervacije.DataSource = lista;
                PodesiKolone();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodesiKolone()
        {
            if (dgvRezervacije.Columns.Count == 0) return;

            foreach (DataGridViewColumn col in dgvRezervacije.Columns)
                col.Visible = false;

            string[] vidljive = { "IdRezervacija", "Termin", "StatusRezervacije" };
            foreach (string ime in vidljive)
                if (dgvRezervacije.Columns.Contains(ime))
                    dgvRezervacije.Columns[ime].Visible = true;

            if (dgvRezervacije.Columns.Contains("IdRezervacija"))
                dgvRezervacije.Columns["IdRezervacija"].HeaderText = "ID";
            if (dgvRezervacije.Columns.Contains("Termin"))
                dgvRezervacije.Columns["Termin"].HeaderText = "Termin";
            if (dgvRezervacije.Columns.Contains("StatusRezervacije"))
                dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";

        }

        private string IzgradiUslov()
        {
            List<string> uslovi = new List<string>();

            // Datum filter
            uslovi.Add($"CAST(r.termin AS DATE) = '{dtpDatum.Value:yyyy-MM-dd}'");

            // Status filter
            if (cmbStatus.SelectedItem?.ToString() != "Svi")
                uslovi.Add($"r.statusRezervacije = '{cmbStatus.SelectedItem}'");

            // Ako je korisnik ulogovan, vidi samo svoje rezervacije
            if (MainCoordinator.Instanca.PrijavljeniKorisnik != null)
                uslovi.Add($"r.idKorisnik = {MainCoordinator.Instanca.PrijavljeniKorisnik.IdKorisnik}");

            return string.Join(" AND ", uslovi);
        }

        private void UcPretragaRezervacija_Load(object sender, EventArgs e)
        {
            // Popuni status ComboBox
            cmbStatus.Items.Add("Svi");
            foreach (StatusRezervacije s in Enum.GetValues(typeof(StatusRezervacije)))
                cmbStatus.Items.Add(s);
            cmbStatus.SelectedIndex = 0;

            dtpDatum.Value = DateTime.Today;
        }
    }
}
