using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library_Final_Project.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateTime TakingTime { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ReturnTime { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public Client Client { get; set; }

        public Book Book { get; set; }
    }
}
