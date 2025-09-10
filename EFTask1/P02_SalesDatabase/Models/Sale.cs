using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models
{
    internal class Sale
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public int StoreId { get; set; }
        public Store store { get; set; }
    }
}
