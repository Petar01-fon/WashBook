using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Klijent
{
    public partial class FrmPrijava : Form
    {
        public FrmPrijava()
        {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) ||
        string.IsNullOrWhiteSpace(txtSifra.Text))
            {
                MessageBox.Show("Unesite korisničko ime i šifru.",
                                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string korisnickoIme = txtKorisnickoIme.Text.Trim();
            string sifra = txtSifra.Text.Trim();

            try
            {
                // Pokušaj kao Radnik
                Odgovor odgovorRadnik = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.PrijaviRadnika,
                    new Radnik { KorisnickoIme = korisnickoIme, Sifra = sifra });

                if (odgovorRadnik.Uspesno)
                {
                    Radnik radnik = Komunikacija.Instance
                        .Serializer.ReadType<Radnik>(odgovorRadnik.Objekat);
                    MainCoordinator.Instanca.PrijaviRadnika(radnik);
                    this.Hide();
                    return;
                }

                // Pokušaj kao Korisnik
                Odgovor odgovorKorisnik = Komunikacija.Instance.PosaljiZahtev(
                    Operacija.PrijaviKorisnika,
                    new Korisnik { KorisnickoIme = korisnickoIme, Sifra = sifra });

                if (odgovorKorisnik.Uspesno)
                {
                    Korisnik korisnik = Komunikacija.Instance
                        .Serializer.ReadType<Korisnik>(odgovorKorisnik.Objekat);
                    MainCoordinator.Instanca.PrijaviKorisnika(korisnik);
                    this.Hide();

                    return;
                }

                // Ni radnik ni korisnik
                MessageBox.Show("Pogrešno korisničko ime ili šifra.",
                                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
