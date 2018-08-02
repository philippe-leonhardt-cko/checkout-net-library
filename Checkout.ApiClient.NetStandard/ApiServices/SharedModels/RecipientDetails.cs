using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout.ApiServices.SharedModels
{
    public class RecipientDetails
    {
        public string AccountNumber { get; set; }
        public string Dob { get; set; }
        public string PartialPostcode { get; set; }
        public string Surname { get; set; }
    }
}
