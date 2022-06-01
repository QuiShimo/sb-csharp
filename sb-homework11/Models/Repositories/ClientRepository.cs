using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB_Homework11.Models.Entities;

namespace SB_Homework11.Models.Repositories
{
    internal class ClientRepository
    {
        private List<Client> _clients = new List<Client>();
        public List<Client> PublicClients;

        public ClientRepository()
        {
            LoadData();
            PublicClients = new List<Client>(_clients);
        }

        public void LoadData()
        {
            // добавить обработку, если файла нет
            if (File.Exists("client.txt"))
            {
                using (StreamReader sr = new StreamReader("client.txt"))
                {
                    string? line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('#');
                        _clients.Add(new Client(data[0], data[1], data[2], data[3], data[4], data[5]));
                    }
                }
            }
        }

        public void SaveData()
        {
            if (_clients.Count > 0)
            {
                using (StreamWriter sw = new StreamWriter("client.txt"))
                {
                    foreach (Client client in _clients)
                        sw.WriteLine(client.ToString());
                }
            }
        }
    }
}
