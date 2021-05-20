using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimeSheets.Models.Dto
{
    public class PersonCreateRequest
    {
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Email { get; set; }
         public string Company { get; set; }
         public int Age { get; set; }
    }
}
