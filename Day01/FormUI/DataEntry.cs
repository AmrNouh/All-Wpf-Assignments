using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    internal class DataEntry
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string JobTile { get; set; }

        public DataEntry(string firstName, string lastName, string gender, string address, string phone, string mobile, string email, string jobTile)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Address = address;
            Phone = phone;
            Mobile = mobile;
            Email = email;
            JobTile = jobTile;
        }


    }
}
