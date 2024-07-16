using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string bookName {  get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int price {  get; set; }
        [Required]
        public int discountPrice { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string bookImage { get; set; }

        [ForeignKey("UserEntity")]
        [Column("admin_Id")]
        public int UserEntityId {  get; set; }
        public UserEntity? User { get; set; }


    }
}
