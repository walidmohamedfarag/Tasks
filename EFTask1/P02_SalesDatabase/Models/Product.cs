using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
