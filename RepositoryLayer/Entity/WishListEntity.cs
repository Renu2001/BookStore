using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class WishListEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("BookEntity")]
        [Column("book_Id")]
        public int BookId { get; set; }
        public BookEntity BookEntity { get; set; }

        [ForeignKey("UserEntity")]
        [Column("User_Id")]
        public int UserId { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
