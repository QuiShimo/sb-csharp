using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_Homework11.Entity
{
    internal class Client
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string phoneNumber;
        private string pasportSerial;
        private string pasportNumber;

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string MiddleName { get { return middleName; } set { middleName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }
        public string PasportSerial { get { return pasportSerial; } set { pasportSerial = value; } }
        public string PassportNumber { get { return pasportNumber; } set { pasportNumber = value;} }

        public Client(string fName, string mName, string lName, string phNumber, string pSerial, string pNumber)
        {
            firstName = fName;
            middleName = mName;
            lastName = lName;
            phoneNumber = phNumber;
            pasportSerial = pSerial;
            pasportNumber = pNumber;
        }

        public override string ToString()
        {
            return $"{firstName}#{middleName}#{lastName}#{phoneNumber}#{pasportSerial}#{pasportNumber}";
        }
    }
}
