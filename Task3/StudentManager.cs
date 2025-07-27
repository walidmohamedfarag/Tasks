
namespace Task3
{
    internal class StudentManager
    {
        List<Student> Students = new();
        List<Course> Courses = new();
        List<Instructor> Instructors = new();
        public bool AddStudent(Student student)
        {
            Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int id) //find the student by id ...if student found return tha id if not return random student 
        {
            Random randomIndex = new();
            for(int index = 0; index < Students.Count; index++)
            {
                if(id == Students[index].StudentId)
                    return Students[index];
            }
            return Students[randomIndex.Next(0, Students.Count - 1)];
        }
        public Course FindCourse(int courseId) //find the course by id ...if course found return tha id if not return random course
        {
            Random randomIndex = new();
            for (int index = 0; index < Courses.Count; index++)
            {
                if (courseId == Courses[index].CourseId)
                    return Courses[index];
            }
            return Courses[randomIndex.Next(0, Courses.Count - 1)];
        }
        public Instructor FindInstructor(int instructorId)
        {
            Random randomIndex = new();
            for (int index = 0; index < Instructors.Count; index++)
            {
                if (instructorId == Instructors[index].InstructorId)
                    return Instructors[index];
            }
            return Instructors[randomIndex.Next(0, Instructors.Count - 1)];
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student.StudentId == studentId && course.CourseId == courseId)
            {
                student.Enroll(course);
                return true;
            }
            return false;
        } //enroll student in specific course by id of student and id of course

        public void ViewAllStudent()
        { 
            for(int index = 0; index < Students.Count; index++)
                Console.Write($"{Students[index].PrintDetailsOfStudent()}\n");
        }
        public void ViewAllCourse()
        {
            for (int index = 0; index < Courses.Count; index++)
                Console.Write($"{Courses[index].PrintDetailsOfCourse()}\n");
        }
        public void ViewAllInstructor()
        {
            for (int index = 0; index < Instructors.Count; index++)
                Console.Write($"{Instructors[index].PrintDetailsOfInstructor()}\n");
        }
        public List<Student> UpdateStudentInformation(int id,Student student) //update of student if is found ...if is not found add the student
        {
            for(int index = 0; index < Students.Count; index++)
            {
                if (Students[index].StudentId == id)
                {
                    Students[index].StudentId = student.StudentId;
                    Students[index].Name = student.Name;
                    Students[index].Age = student.Age;
                    return Students;
                }
            }
            AddStudent(student);
            return Students;
        }
        public bool DeleteStudent(int id)
        {
            for(int index = 0; index < Students.Count; index++)
            {
                if (Students[index].StudentId == id)
                    Students.RemoveAt(index);
                return true;
            }
            return false;
        }
        public bool StudentEnrolledInCourse(int idstudent,int idcourse) // check if student enrolled in course or not
        {
            for(int index = 0; index < Students.Count; index++)
            {
                for(int indexofcourse = 0; indexofcourse < Students[index].Courses.Count; indexofcourse++)
                {
                    if (Students[index].StudentId == idstudent && Students[index].Courses[indexofcourse].CourseId == idcourse)
                        return true;
                }
            }
            return false;
        }
        public string FindInstructorOfCorse(string titel) // return instructor name by course name
        {
            string instructorName = "instructor is not found";
            for(int index = 0; index < Courses.Count; index++)
            {
                if (Courses[index].Titel == titel)
                    return instructorName = Courses[index].Instructor.Name;
            }
            return instructorName;
        }
    }
}
