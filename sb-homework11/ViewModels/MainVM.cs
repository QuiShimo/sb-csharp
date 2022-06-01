using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB_Homework11.Models.Entities;
using SB_Homework11.Models.Repositories;

namespace SB_Homework11.ViewModels
{
    internal class MainVM
    {
        readonly ClientRepository _clientRepository = new ClientRepository();

        public MainVM()
        {

        }

        public List<Client> ClientsListValue => _clientRepository.PublicClients;
    }
}
