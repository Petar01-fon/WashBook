using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class TCPServer
    {
        private Socket serverSocket;
        private bool radi;
        private Action<string> log;

        public TCPServer(Action<string> log)
        {
            this.log = log;
        }

        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 9999));
            serverSocket.Listen(10);
            radi = true;

            while (radi)
            {
                try
                {
                    Socket klijent = serverSocket.Accept();
                    Thread t = new Thread(() =>
                    {
                        ClientHandler handler = new ClientHandler(klijent);
                        handler.ObradiZahtev();
                    });

                    t.IsBackground = true;
                    t.Start();

                }catch (SocketException ex) when (!radi)
                {
                    log($"Server zaustavljen: {ex.Message}");
                }
                catch (SocketException ex)
                {
                    log($"Greška na serveru: {ex.Message}");
                    throw;
                }
            }
        }

        public void Stop()
        {
            radi = false;
            serverSocket.Close();
        }
    }
}
