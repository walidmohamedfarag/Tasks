

namespace Task4
{
    enum Answer
    {
        True,
        False
    }
    internal class QTrueOrFalse : QuestionBank
    {
        public static Dictionary<string, string> doctorChoices= new Dictionary<string, string>();
        public Answer Qanswer { get; set; }
        public QTrueOrFalse(string? QuestionLevel, int QuestionMark, QuestionType QuestionType, string? QuestionBody,Answer answer)
            : base(QuestionLevel, QuestionMark, QuestionType, QuestionBody)
        {
            Qanswer = answer;
        }
        
        public override List<QuestionBank> AddQuestion(QuestionBank question)
        {
            Questions.Add(question);
            doctorChoices[question.QuestionBody] = Qanswer.ToString();
            return Questions;
        }

        public static bool CheckAnswer(string question, string anwser) => doctorChoices[question].ToLower() == anwser.ToLower();
        
    }
}
