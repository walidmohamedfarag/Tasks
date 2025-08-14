

namespace Task4
{
    enum ExamType
    {
        Final = 1,
        Mid = 2,
        Qui = 3 
    }
    record StoreAnswer(QuestionType questiontype,string answer,int mark);
    internal class Exam
    {
        DateTime DateTime { get; set; }
        Dictionary<ExamType,List<QuestionBank>> CreatExam()
        {
            Random random = new Random();
            Dictionary<ExamType, List<QuestionBank>> examQuestion = new();
            List<QuestionBank> questions = new();
            List<QuestionBank> banks = QuestionBank.Questions.ToList();
            Console.Write("enter the type of exam: ");
            string typeexam = Console.ReadLine();
            Enum.TryParse(typeexam, ignoreCase: true, out ExamType examType);
            Console.Write("enter the number of question: ");
            int numberQuestionOfExam = Convert.ToInt32(Console.ReadLine());
            for(int index = 0; index < numberQuestionOfExam; index++)
            {
                int randomQuestion = random.Next(0, banks.Count);
                questions.Add(banks[randomQuestion]);
                banks.RemoveAt(randomQuestion);
            }
            examQuestion[examType] = questions;
            return examQuestion;

        }



        Dictionary<string, StoreAnswer> studentAnswer = new();


        public void StartExam()
        {
            var examQuestions = CreatExam();
            Console.WriteLine("\t\t========== Exam ==========");
            foreach (var item in examQuestions)
            {
                Console.Write($"exam time: {DateTime.Now} | exam type: {item.Key}\n\t\t=========\n");
                foreach (var itemValue in item.Value)
                {
                    Console.Write($"question type: {itemValue.QuestionType} | question level: {itemValue.QuestionLevel}\n");
                    Console.WriteLine($"question: {itemValue.QuestionBody}");
                    if (itemValue.QuestionType == QuestionType.TrueOrFalse || item.Key == ExamType.Qui)
                    {
                        Console.Write("answer (true/false): ");
                        string answer = Console.ReadLine();
                        if (!QTrueOrFalse.CheckAnswer(itemValue.QuestionBody, answer))
                            Console.WriteLine($"the right answer: {QTrueOrFalse.doctorChoices[itemValue.QuestionBody]}");
                        studentAnswer[itemValue.QuestionBody] = new StoreAnswer(itemValue.QuestionType, answer, itemValue.QuestionMark);

                    }
                    else if (itemValue.QuestionType == QuestionType.ChoiceOne)
                    {
                        int count = 0;
                        foreach (var choice in QChoiceOne.doctoChoices[itemValue.QuestionBody].choices)
                            Console.Write($"choice {++count}: {choice}\n");
                        Console.Write("enter the answer: ");
                        string answer = Console.ReadLine();
                        if (!QChoiceOne.CheckAnswer(itemValue.QuestionBody, answer))
                            Console.WriteLine($"the right answer: {QChoiceOne.doctoChoices[itemValue.QuestionBody].answer}");
                        studentAnswer[itemValue.QuestionBody] = new StoreAnswer(itemValue.QuestionType, answer, itemValue.QuestionMark);
                    }
                    else
                    {

                        int count = 0;
                        foreach (var choice in QMultipleChoice.doctoChoices[itemValue.QuestionBody].choices)
                            Console.Write($"choice {++count}: {choice}\n");
                        Console.Write("enter the answer: ");
                        string answer = Console.ReadLine();
                        if (!QMultipleChoice.CheckAnswer(itemValue.QuestionBody, answer))
                            Console.WriteLine($"the right answer: {QMultipleChoice.doctoChoices[itemValue.QuestionBody].answer}");
                        studentAnswer[itemValue.QuestionBody] = new StoreAnswer(itemValue.QuestionType, answer, itemValue.QuestionMark);
                    }
                    Console.WriteLine("--------------------------------\n");
                }

            }

        }
        public int GetTheMark { get => GetMark(); }
        int GetMark()
        {
            int mark = 0;
            foreach (var item in studentAnswer)
            {
                if (item.Value.questiontype == QuestionType.TrueOrFalse)
                {
                    if (QTrueOrFalse.CheckAnswer(item.Key, item.Value.answer))
                        mark += item.Value.mark;
                }
                else if (item.Value.questiontype == QuestionType.ChoiceOne)
                {
                    if (QChoiceOne.CheckAnswer(item.Key, item.Value.answer))
                        mark += item.Value.mark;
                }
                else
                {
                    if (QMultipleChoice.CheckAnswer(item.Key, item.Value.answer))
                        mark += item.Value.mark;
                }
            }

            return mark;
        }




    }
}
