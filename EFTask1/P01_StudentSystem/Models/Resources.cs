
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    public enum ResourceType
    {
        Video = 1,
        Presentation = 2,
        Document = 3,
        Other = 4
    }
    internal class Resources
    {
 
        [Key]
        public int ResourceId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        [Unicode(false)]
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}
