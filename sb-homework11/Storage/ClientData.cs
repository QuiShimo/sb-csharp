using SB_Homework11.Entity;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace SB_Homework11.Storage
{
    internal class ClientData
    {
        public BindingList<Client> Clients = new BindingList<Client>();

        public ClientData()
        {
            LoadData();
        }

        public void LoadData()
        {
            if (File.Exists("client.txt"))
            {
                using (StreamReader sr = new StreamReader("client.txt"))
                {
                    string? line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('#');
                        Clients.Add(new Client(data[0], data[1], data[2], data[3], data[4], data[5]));
                    }
                }
            }
        }

        public void SaveData()
        {
            if (Clients.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter("client.txt"))
                {
                    foreach(Client client in Clients)
                        sw.WriteLine(client.ToString());
                }
            }
        }
    }
}
