
namespace Task4
{
    internal class DoctorMod
    {
        
        public void AddQuestion()
        {
            Console.Write("How Many You Want To Add The Question: ");
            int numberTheQuestion = Convert.ToInt32(Console.ReadLine());
            for (int index = 1; index <= numberTheQuestion; index++)
            {
                Console.Write("\t\t1.true or false\n\t\t2.choice one\n\t\t3.multiple choice\n\t================\nenter the type of the question: ");
                int typeQuestion = Convert.ToInt32(Console.ReadLine());
                if (typeQuestion == 1)
                {
                    Console.Write("Enter The Question Level: ");
                    string questionLevel = Console.ReadLine();
                    Console.Write("Enter The Question Mark: ");
                    int qustionMark = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter The Question: ");
                    string bodyTheQuestion = Console.ReadLine();
                    Console.Write("Enter The Answer (True/False): ");
                    string inputUser = Console.ReadLine();
                    Enum.TryParse(inputUser, ignoreCase: true, out Answer answer);
                    QuestionType qLevel = (QuestionType)typeQuestion;
                    QTrueOrFalse question = new QTrueOrFalse(questionLevel, qustionMark, qLevel, bodyTheQuestion, answer);
                    question.AddQuestion(question);
                }
                else if (typeQuestion == 2)
                {
                    Console.Write("Enter The Question Level: ");
                    string questionLevel = Console.ReadLine();
                    Console.Write("Enter The Question Mark: ");
                    int qustionMark = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter The Question: ");
                    string bodyTheQuestion = Console.ReadLine();
                    string[]? choicesOne = new string[4];
                    for (int numchioce = 0; numchioce < choicesOne.Length; numchioce++)
                    {
                        Console.Write($"enter the choice number {numchioce + 1}: ");
                        choicesOne[numchioce] = Console.ReadLine();
                    }
                    Console.Write("Enter The Answer: ");
                    string choiceAnswer = Console.ReadLine();
                    QuestionType qLevel = (QuestionType)typeQuestion;
                    QChoiceOne question = new QChoiceOne(questionLevel, qustionMark, qLevel, bodyTheQuestion, choicesOne, choiceAnswer);
                    question.AddQuestion(question);
                }

                else if(typeQuestion == 3)
                {
                    Console.Write("Enter The Question Level: ");
                    string questionLevel = Console.ReadLine();
                    Console.Write("Enter The Question Mark: ");
                    int qustionMark = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter The Question: ");
                    string bodyTheQuestion = Console.ReadLine();
                    string[]? multiChoices = new string[4];
                    for (int numMulti = 0; numMulti < multiChoices.Length; numMulti++ )
                    {
                        Console.Write($"enter the choice number {numMulti + 1}: ");
                        multiChoices[numMulti] = Console.ReadLine();
                    }
                    Console.Write("enter the answer: ");
                    string answer = Console.ReadLine();
                    QuestionType qLevel = (QuestionType)typeQuestion;
                    QMultipleChoice question = new QMultipleChoice(questionLevel, qustionMark, qLevel, bodyTheQuestion, multiChoices, answer);
                    question.AddQuestion(question);                    
                }

                else Console.WriteLine("invalid choice");
                Console.WriteLine("==========================\n");
            }
        }
        

        


    }
}
