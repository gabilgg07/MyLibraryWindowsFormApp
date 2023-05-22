using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Library_Final_Project.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
