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
    public partial class UcMojeRezervacije : UserControl
    {
        public UcMojeRezervacije()
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

            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.BackColor = Color.FromArgb(46, 134, 222);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Font = new Font("Segoe UI", 9);
            btnRefresh.Height = 34;
            btnRefresh.Width = 100;
            btnRefresh.Cursor = Cursors.Hand;

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
            dgvRezervacije.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvRezervacije.ColumnHeadersHeight = 44;
            dgvRezervacije.EnableHeadersVisualStyles = false;
            dgvRezervacije.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 134, 222);
            dgvRezervacije.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvRezervacije.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvRezervacije.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);

        }

        private void UcMojeRezervacije_Load(object sender, EventArgs e)
        {
            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
                lblNaslov.Text = "Moje zakazane rezervacije";
            else
                lblNaslov.Text = "Moje rezervacije";

            UcitajRezervacije();
        }

        private void UcitajRezervacije()
        {
            try
            {
                string condition;

                if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
                    condition = $"r.idRadnik = {MainCoordinator.Instanca.PrijavljeniRadnik.IdRadnik}";
                else
                    condition = $"r.idKorisnik = {MainCoordinator.Instanca.PrijavljeniKorisnik.IdKorisnik}";

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

            string[] vidljive = { "Termin", "ImeRadnika", "StatusRezervacije", "NazivTipVozila", "NazivUsluge", "Registracija", "Cena" };
            foreach (string ime in vidljive)
                if (dgvRezervacije.Columns.Contains(ime))
                    dgvRezervacije.Columns[ime].Visible = true;

            if (dgvRezervacije.Columns.Contains("IdRezervacija"))
                dgvRezervacije.Columns["IdRezervacija"].HeaderText = "ID";
            if (dgvRezervacije.Columns.Contains("Termin"))
                dgvRezervacije.Columns["Termin"].HeaderText = "Termin";
            if (dgvRezervacije.Columns.Contains("ImeRadnika"))
                dgvRezervacije.Columns["ImeRadnika"].HeaderText = "Radnik";
            if (dgvRezervacije.Columns.Contains("StatusRezervacije"))
                dgvRezervacije.Columns["StatusRezervacije"].HeaderText = "Status";
            if (dgvRezervacije.Columns.Contains("NazivTipVozila"))
                dgvRezervacije.Columns["NazivTipVozila"].HeaderText = "Tip vozila";
            if (dgvRezervacije.Columns.Contains("Usluga"))
                dgvRezervacije.Columns["Usluga"].HeaderText = "Usluga";
            if (dgvRezervacije.Columns.Contains("Registracija"))
                dgvRezervacije.Columns["Registracija"].HeaderText = "Registracija";
            if (dgvRezervacije.Columns.Contains("Cena"))
                dgvRezervacije.Columns["Cena"].HeaderText = "Cena (RSD)";

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UcitajRezervacije();
        }

        private void dgvRezervacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Rezervacija izabrana = (Rezervacija)dgvRezervacije.Rows[e.RowIndex].DataBoundItem;

            if (MainCoordinator.Instanca.PrijavljeniRadnik != null)
            {
                FrmPromeniStatus frm = new FrmPromeniStatus(izabrana);
                frm.ShowDialog();
            }
            else
            {
                FrmPromeniTermin frm = new FrmPromeniTermin(izabrana);
                frm.ShowDialog();
            }

            UcitajRezervacije();
        }

        private void btnStorniraj_Click(object sender, EventArgs e)
        {
            if (dgvRezervacije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite rezervaciju.", "Upozorenje",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Rezervacija selected = (Rezervacija)dgvRezervacije.SelectedRows[0].DataBoundItem;

            if (selected.StatusRezervacije != StatusRezervacije.KREIRANA)
            {
                MessageBox.Show("Moguće je stornirati samo rezervacije u statusu KREIRANA.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selected.Termin <= DateTime.Now)
            {
                MessageBox.Show("Nije moguće stornirati rezervaciju čiji je termin već prošao.",
                    "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var potvrda = MessageBox.Show(
                $"Da li ste sigurni da želite da stornirate rezervaciju #{selected.IdRezervacija}?",
                "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (potvrda != DialogResult.Yes) return;

            try
            {
                MessageBox.Show($"ID: {selected.IdRezervacija}\nStatus: {selected.StatusRezervacije}\nTermin: {selected.Termin}");
                Odgovor odgovor = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.StornirajRezervaciju, selected);

                if (odgovor.Uspesno)
                {
                    MessageBox.Show("Rezervacija je uspešno stornirana.", "Uspeh",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UcitajRezervacije();
                }
                else
                {
                    MessageBox.Show(odgovor.Greska, "Greška",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
