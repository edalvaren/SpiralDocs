using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace SpiralDocs.Models
{
    public class SpiralUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [DataType(DataType.Password)]
        [Required]

        [StringLength(16, MinimumLength =8)]
        public string Pword { get; set; }
        public string Email { get; set; }

        [Range(1,5)]
        public byte? Accesslevel { get; set; }
        public int Id { get; set; }

        public string JobTitle { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
