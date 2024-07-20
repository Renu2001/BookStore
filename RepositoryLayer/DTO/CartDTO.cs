using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DTO
{
    public class CartDTO
    {
        public List<CartEntity> Carts { get; set; }
        public double TotalPrice { get; set; }
    }
}
