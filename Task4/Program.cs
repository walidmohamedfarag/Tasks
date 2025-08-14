namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DoctorMod doctor = new();
            doctor.AddQuestion();
            Exam exam = new();
            exam.StartExam();

            Console.WriteLine("================");
            Console.WriteLine($"mark of exam: {exam.GetTheMark}");
            
        }
    }
}
