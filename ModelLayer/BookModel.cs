using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class BookModel
    {
        public string bookName { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public int discountPrice { get; set; }
        public int quantity { get; set; }
        public string author { get; set; }
        public string bookImage { get; set; }
    }
}
