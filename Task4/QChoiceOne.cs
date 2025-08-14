

namespace Task4
{
   
    internal class QChoiceOne : QuestionBank
    {
        string[]? choices = new string[4];
        Store _StoreOne;
        public static Dictionary<string, Store> doctoChoices = new();
        string Answer { get; set; }
        public QChoiceOne(string? QuestionLevel, int QuestionMark, QuestionType QuestionType, string? QuestionBody, string[] choices,string answer)
            : base(QuestionLevel, QuestionMark, QuestionType, QuestionBody)
        {
            this.choices = choices;
            this.Answer = answer;
        }
        public override List<QuestionBank> AddQuestion(QuestionBank question)
        {
            Questions.Add(question);
            StoreChoiceAndAnswer();
            return Questions;
        }
        private Dictionary<string, Store> StoreChoiceAndAnswer()
        {
            _StoreOne = new(Answer, choices);
            doctoChoices[QuestionBody] = _StoreOne;
            return doctoChoices;
        }
        public static bool CheckAnswer(string question, string answer) => doctoChoices[question].answer == answer;
     
     
    }
}
