namespace Task3
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new();
            int numberToExsit = 0;
            do
            {
                Console.Write("\t======================\n\t\t1.Add Student\t\t\t2.Add Instructor\n" +
                              "\t\t3.Add Course\t\t\t4.Enroll Student in Course\n" +
                              "\t\t5.Show All Students\t\t6.Show All Courses\n" +
                              "\t\t7.Show All Instructors\t\t8.Find the student by id or name\n" +
                              "\t\t9.Fine the course by id\t\t10.Exit\n\t======================\n");
                Console.Write("enter the number to chioce the option: ");
                int enterNumber = Convert.ToInt32(Console.ReadLine());
                switch (enterNumber)
                {
                    case 1:
                        {
                            Console.Write("enter the name of student: ");
                            string nameOfStudent = Console.ReadLine();
                            Console.Write("enter the id of student: ");
                            int idOfStudent = Convert.ToInt32(Console.ReadLine());
                            Console.Write("enter the age of student: ");
                            int ageOfStudent = Convert.ToInt32(Console.ReadLine());
                            manager.AddStudent(new Student(nameOfStudent, idOfStudent, ageOfStudent));
                            break;
                        }
                    case 2:
                        {
                            Console.Write("enter the name of instructor: ");
                            string nameOfINstructor = Console.ReadLine();
                            Console.Write("enter the id of instructor: ");
                            int idOfInstructor = Convert.ToInt32(Console.ReadLine());
                            Console.Write("enter the specialization of instructor: ");
                            string specialization = Console.ReadLine();
                            manager.AddInstructor(new Instructor(idOfInstructor, nameOfINstructor, specialization));
                            break;
                        }
                    case 3:
                        {
                            Console.Write("enter the name of course: ");
                            string nameOfCourse = Console.ReadLine();
                            Console.Write("enter the id of course: ");
                            int idOfCourse = Convert.ToInt32(Console.ReadLine());

                            Console.Write("enter the name of instructor: ");
                            string nameOfINstructor = Console.ReadLine();
                            manager.AddCourse(new Course(idOfCourse, nameOfCourse, new Instructor(nameOfINstructor)));
                            break;
                        }
                    case 4:
                        {
                            Console.Write("enter the id of student you want to enroll the course: ");
                            int idToCourse = Convert.ToInt32(Console.ReadLine());
                            Console.Write("enter the id of course you want enrolled the student: ");
                            int idOfCourse = Convert.ToInt32(Console.ReadLine());
                            manager.EnrollStudentInCourse(idToCourse, idOfCourse);
                            break;
                        }
                    case 5:
                        {
                            manager.ViewAllStudent();
                            break;
                        }
                    case 6:
                        {
                            manager.ViewAllInstructor();
                            break;
                        }
                    case 7:
                        {
                            manager.ViewAllCourse();
                            break;
                        }
                    case 8:
                        {
                            Console.Write("enter the id of student you wanted it: ");
                            int idToFindTheStudent = Convert.ToInt32(Console.ReadLine());
                            manager.FindStudent(idToFindTheStudent);
                            break;
                        }
                    case 9:
                        {
                            Console.Write("enter the id of course you wanted it: ");
                            int idToFindTheCourse = Convert.ToInt32(Console.ReadLine());
                            manager.FindStudent(idToFindTheCourse);
                            break;
                        }
                    case 10:
                        {
                            numberToExsit = enterNumber;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("invalid operation");
                            break;
                        }

                }
            } while (numberToExsit != 10);
        }
    }
}
