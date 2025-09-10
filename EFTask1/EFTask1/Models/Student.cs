using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    internal class Student
    {
       
        [Key]
        public int StudentId { get; set; }
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; }
        [MaxLength(10)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }
        public List<HomeWorkSubMissions> homeWorkSubMissions { get; set; }
    }
}
