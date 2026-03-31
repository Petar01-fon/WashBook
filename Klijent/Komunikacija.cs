using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Zajednicki.Komunikacija;

namespace Klijent
{
    public class Komunikacija
    {
        private static Komunikacija instance;

        public static Komunikacija Instance => instance ??= new Komunikacija();
        private Komunikacija() { }

        private Socket socket;
        private JsonNetworkSerializer serializer;
        public JsonNetworkSerializer Serializer => serializer;
        public void Connect(string ip, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
            serializer = new JsonNetworkSerializer(socket);
        }


        public Odgovor PosaljiZahtev(Operacija operacija, object objekat = null)
        {
            try
            {
                Zahtev zahtev = new Zahtev
                {
                    Operacija = operacija.ToString(),
                    Objekat = objekat
                };
                serializer.Send(zahtev);
                return serializer.Receive<Odgovor>();
            }
            catch (SocketException ex)
            {
                throw new Exception($"Greška u komunikaciji sa serverom: {ex.Message}");
            }
            catch (IOException ex)
            {
                throw new Exception($"Greška pri slanju/primanju podataka: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            try
            {
                serializer?.Close();
                socket?.Close();
            }
            catch (SocketException ex)
            {
                throw new Exception($"Greška pri zatvaranju konekcije: {ex.Message}");
            }
        }
    }
}
