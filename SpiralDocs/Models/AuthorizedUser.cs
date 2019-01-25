using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SpiralDocs.Areas.Identity.Data; 

namespace SpiralDocs.Models  
{
    public class AuthorizedUser : SpiralDocsUser
    {
        public string UserID { get; set; }

        [DataType(DataType.Text)]
        public string Name { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
