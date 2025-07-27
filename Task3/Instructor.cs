
namespace Task3
{
    internal class Instructor
    {
        public Instructor(string name)
        {
            Name = name;
        }

        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PrintDetailsOfInstructor() => $"instructor id: {InstructorId}\nname: {Name}\nspecialization: {Specialization}\n";
    }
}
