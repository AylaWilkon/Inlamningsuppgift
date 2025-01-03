using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.UserService.Model
{
    public class Address 
    {
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public string FullAddress => $"{StreetName} {City} {PostalCode}"; //Stränginterpolering
        //Egenskap som endast läses in, genereras endast när det begärs. Användbar vid strukturering.
    }
    
}
