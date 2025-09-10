using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public int CustomerCridetCardNumber { get; set; }
        public string CustomerName { get; set; }
        public string Email {  get; set; }
    }
}
