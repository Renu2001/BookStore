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
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string BookName {  get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price {  get; set; }
        [Required]
        public int DiscountPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string BookImage { get; set; }

        [ForeignKey("UserEntity")]
        [Column("admin_Id")]
        public int UserEntityId {  get; set; }
        public UserEntity? Users { get; set; }

        [JsonIgnore]
        public ICollection<CartEntity> Carts { get; } 


    }
}
