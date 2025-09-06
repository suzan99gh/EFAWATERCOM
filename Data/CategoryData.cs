using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efwatercom.Data
{
    public class CategoryData
    {
        public CategoryData(string billerName = "", string email = "", string loation = "")
        {
            BillerName = billerName;
   
            Location = loation;
            Email = email;
        }

    
        public string? BillerName { get; set; }
      
        public string? Email{ get; set; }
        public string? Location { get; set; }
    }
}