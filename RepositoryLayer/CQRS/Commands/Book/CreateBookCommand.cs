using MediatR;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.CQRS.Commands.Book
{
    public class CreateBookCommand : IRequest<BookEntity>
    {
        public string BookName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountPrice { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
        public string BookImage { get; set; }

        public int Admin_Id { get; set; }

        public CreateBookCommand(string bookName, string description, int price, int discountPrice, int quantity, string author, string bookImage, int admin_Id)
        {
            this.BookName = bookName;
            this.Description = description;
            this.Price = price;
            this.DiscountPrice = discountPrice;
            this.Quantity = quantity;
            this.Author = author;
            this.BookImage = bookImage;
            this.Admin_Id = admin_Id;
        }

       
    }
}
