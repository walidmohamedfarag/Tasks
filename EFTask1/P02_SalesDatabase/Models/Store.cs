using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models
{
    internal class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
    }
}
