
using System.Text;

namespace Task3
{
    internal class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public int Age { get; set; }

        public List<Course> Courses = new();

       
        public Student(string name, int studentId, int age)
        {
            Name = name;
            StudentId = studentId;
            Age = age;
        }

        public bool Enroll(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public string PrintDetailsOfStudent() => $"name: {Name}\nstudent id: {StudentId}\nage: {Age}\n";
      

    }
}
