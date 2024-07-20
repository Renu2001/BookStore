using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserEntity")]
        [Column("User_Id")]
        public int UserEntityId { get; set; }
        public UserEntity User { get; set; }

        [ForeignKey("BookEntity")]
        [Column("Book_Id")]
        public int BookId { get; set; }
        public BookEntity Book { get; set; }

        [ForeignKey("CustomerDetailsEntity")]
        [Column("CustomersDetails_Id")]
        public int CustomersDetailsId { get; set; }
        public CustomerDetailsEntity CustomersDetails { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double TotalPrice { get; set; }
    }
}

