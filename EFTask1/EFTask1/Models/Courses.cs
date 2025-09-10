using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    internal class Courses
    {
   
        [Key]
        public int CourseId { get; set; }
        [MaxLength(80)]
        [Unicode(true)]
        public string Name { get; set; }

        [Unicode(true)]
        public string? Description { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public List<HomeWorkSubMissions> homeWorkSubMissions { get; set; }
        public List<Resources> Resources { get; set; }
    }
}
