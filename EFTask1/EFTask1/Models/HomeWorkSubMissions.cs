using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Models
{
    enum ContentType
    {
        Application = 1,
        Pdf = 2,
        Zip = 3
    }
    internal class HomeWorkSubMissions
    {
        [Key]
        public int HomeworkId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public DateTime SubmissionTime { get; set; }

        [Unicode(false)]
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public Courses Course { get; set; }

    }
}
