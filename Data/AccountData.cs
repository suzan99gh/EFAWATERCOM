using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efwatercom.Data
{
    public class AccountData
    {
        public AccountData(string fullName = "",string phoneNumber = "", string email = "", string currentPassword = "", string address = "",string user ="", string newPassword ="",string photo = "")
        {
            FullName =    fullName;
            PhoneNumber = phoneNumber;
            Email = email;
            CurrentPassword = currentPassword;
            Address = address;
            User = user;
            NewPassword = newPassword; 
            Photo = photo;

        }


        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CurrentPassword { get; set; }

        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? User { get; set; }
        public string? NewPassword { get; set; }
        public string? Photo { get; set; }  
    }
}
