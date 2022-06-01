using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_Homework11.Models.Entities
{
    internal class Client
    {
        public Client(string lName, string fName, string mName, string phNumber, string pSerial, string pNumber)
        {
            LastName = lName;
            FirstName = fName;
            MiddleName = mName;
            PhoneNumber = phNumber;
            PasportSerial = pSerial;
            PasportNumber = pNumber;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string PasportSerial { get; set; }
        public string PasportNumber { get; set; }
    }
}
