
namespace Task3
{
    internal class Course
    {
        public Course(int courseId, string titel, Instructor instructor)
        {
            CourseId = courseId;
            Titel = titel;
            Instructor = instructor;
        }

        public int CourseId { get; set; }
        public string Titel { get; set; }
        public Instructor Instructor { get; set; }
        public string PrintDetailsOfCourse() => $"course id: {CourseId}\ncourse titel: {Titel}\ninstructor: {Instructor.Name}\n";

    }
}
