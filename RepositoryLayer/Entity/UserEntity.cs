using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace RepositoryLayer.Entity
{
    public class UserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Roles { get; set; }

        public ICollection<BookEntity> Books { get; } = new List<BookEntity>();
        public ICollection<CartEntity> Carts { get; } = new List<CartEntity>();
        public ICollection<CustomerDetailsEntity> CustomerDetails { get; } = new List<CustomerDetailsEntity>();



    }
}
