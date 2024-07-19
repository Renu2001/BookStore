using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class CartEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsPurchased { get; set; } = false;

        [ForeignKey("BookEntity")]
        [Column("book_Id")]
        public int BookId { get; set; }
        public BookEntity BookEntity { get; set; }

        [ForeignKey("UserEntity")]
        [Column("User_Id")]
        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }

        [Required]
        public int TotalPrice {  get; set; }

        [JsonIgnore]
        public ICollection<OrderEntity> Orders { get; set; }

    }
}
