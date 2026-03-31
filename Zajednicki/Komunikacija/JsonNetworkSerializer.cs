using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Zajednicki.Komunikacija
{
    public class JsonNetworkSerializer
    {
        private readonly Socket s;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket s)
        {
            this.s = s;
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }


        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }

        public T Receive<T>()
        {
            string json = reader.ReadLine();
            return JsonSerializer.Deserialize<T>(json);
        }

        //public T ReadType<T>(object podaci) where T : class
        //{
        //    return podaci == null ? null : JsonSerializer.Deserialize<T>((JsonElement)podaci);
        //}

        public T ReadType<T>(object podaci)
        {
            return podaci == null ? default : JsonSerializer.Deserialize<T>((JsonElement)podaci);
        }

        public void Close()
        {
            reader.Close();
            writer.Close();
            stream.Close();

        }
    }
}
