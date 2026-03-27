namespace Server
{
    public partial class Form1 : Form
    {
        private TCPServer server;
        private Thread serverThread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Log(string poruka)
        {
            if (InvokeRequired)
            {
                Invoke(() => Log(poruka));
                return;
            }
            lbLogovi.Items.Add($"[{DateTime.Now:HH:mm:ss}] {poruka}");
            lbLogovi.TopIndex = lbLogovi.Items.Count - 1; // skroluj na kraj
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new TCPServer(Log);

            serverThread = new Thread(() =>
            {
                try
                {
                    server.Start();
                }
                catch (Exception ex)
                {
                    Log($"Fatalna greška servera: {ex.Message}");
                }
            });

            serverThread.IsBackground = true;
            serverThread.Start();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server?.Stop();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }
    }
}
