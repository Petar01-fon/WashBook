namespace Klijent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FrmPrijava());


            ApplicationConfiguration.Initialize();

            try
            {
                Komunikacija.Instance.Connect("127.0.0.1", 9999);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Ne može se uspostaviti konekcija sa serverom.\n{ex.Message}",
                    "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmPrijava());
        }
    }
}