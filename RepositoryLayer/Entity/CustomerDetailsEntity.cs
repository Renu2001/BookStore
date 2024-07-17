using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{
    public class CustomerDetailsEntity
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }

        [ForeignKey("UserEntity")]
        [Column("User_Id")]
        public int UserEntityId { get; set; }
        public UserEntity Users { get; set; }

    }
}
