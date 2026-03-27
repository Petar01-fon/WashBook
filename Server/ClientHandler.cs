using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Zajednicki;
using Zajednicki.Domen;
using Zajednicki.Komunikacija;

namespace Server
{
    public class ClientHandler
    {
        private Socket clientSocket;

        private JsonNetworkSerializer serializer;

        private Action<string> log;

        public ClientHandler(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            serializer = new JsonNetworkSerializer(clientSocket);
            this.log = log;
        }

        public void ObradiZahtev()
        {
            try
            {
                while (true)
                {
                    Zahtev zahtev = serializer.Receive<Zahtev>();
                    Odgovor odgovor = IzvrsiOperaciju(zahtev);
                    serializer.Send(odgovor);
                }
            }
            catch (SocketException ex)
            {
                // klijent se iznenada diskonektovao
                log($"Klijent diskonektovan (SocketException): {ex.Message}");
            }
            catch (IOException ex)
            {
                // greška pri čitanju/pisanju na stream
                log($"Greška pri čitanju/pisanju: {ex.Message}");
            }
            catch (ObjectDisposedException ex)
            {
                // socket je već zatvoren
                log($"Socket već zatvoren: {ex.Message}");
            }
            finally
            {
                serializer.Close();
                clientSocket.Close();
            }

        }

        private Odgovor IzvrsiOperaciju(Zahtev zahtev)
        {
            try
            {
                Operacija op = Enum.Parse<Operacija>(zahtev.Operacija);

                switch (op)
                {
                    case Operacija.PrijaviRadnika:
                        {
                            Radnik r = serializer.ReadType<Radnik>(zahtev.Objekat);
                            Radnik result = Kontroler.Instance.PrijaviRadnika(r.KorisnickoIme, r.Sifra);
                            return new Odgovor { Uspesno = true, Objekat = result };
                        }
                    case Operacija.VratiSveRadnike:
                        {
                            var result = Kontroler.Instance.VratiSveRadnike();
                            return new Odgovor { Uspesno = true, Objekat = result };
                        }
                    case Operacija.UbaciRezervaciju:
                        {
                            Rezervacija r = serializer.ReadType<Rezervacija>(zahtev.Objekat);
                            Kontroler.Instance.UbaciRezervaciju(r);
                            return new Odgovor { Uspesno = true };
                        }
                    case Operacija.PromeniRezervaciju:
                        {
                            Rezervacija r = serializer.ReadType<Rezervacija>(zahtev.Objekat);
                            Kontroler.Instance.PromeniRezervaciju(r);
                            return new Odgovor { Uspesno = true };
                        }
                    case Operacija.ObrisiRezervaciju:
                        {
                            Rezervacija r = serializer.ReadType<Rezervacija>(zahtev.Objekat);
                            Kontroler.Instance.ObrisiRezervaciju(r);
                            return new Odgovor { Uspesno = true };
                        }
                    case Operacija.PretraziRezervaciju:
                        {
                            Rezervacija r = serializer.ReadType<Rezervacija>(zahtev.Objekat);
                            Rezervacija result = Kontroler.Instance.PretraziRezervaciju(r.IdRezervacija);
                            return new Odgovor { Uspesno = true, Objekat = result };
                        }
                    case Operacija.VratiListuRezervacija:
                        {
                            string condition = serializer.ReadType<string>(zahtev.Objekat);
                            var result = Kontroler.Instance.VratiListuRezervacija(condition);
                            return new Odgovor { Uspesno = true, Objekat = result };
                        }
                    case Operacija.VratiSveKorisnike:
                        {
                            var result = Kontroler.Instance.VratiSveKorisnike();
                            return new Odgovor { Uspesno = true, Objekat = result };
                        }
                    default:
                        return new Odgovor { Uspesno = false, Greska = "Nepoznata operacija." };
                }
            }
            catch (Exception ex)
            {
                return new Odgovor { Uspesno = false, Greska = ex.Message };
            }
        }
    }
}
    

