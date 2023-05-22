using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library_Final_Project.Models
{
    public class Book
    {
        public int Id { get; set; }

        public int BookCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public BookCategory BookCategory { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
