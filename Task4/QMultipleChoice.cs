
namespace Task4
{
    

    internal class QMultipleChoice : QuestionBank
    {
        string[]? choices = new string[4];
        string Answer { get; set; }
        Store _Store;
        public static Dictionary<string,Store> doctoChoices = new();
        public QMultipleChoice(string? QuestionLevel, int QuestionMark, QuestionType QuestionType, string? QuestionBody, string[] choices, string answer)
            : base(QuestionLevel, QuestionMark, QuestionType, QuestionBody)
        {
            this.choices = choices;
            Answer = answer;
        }
        public override List<QuestionBank> AddQuestion(QuestionBank question)
        {
            Questions.Add(question);
            StoreChoiceAndAnswer();
            return  Questions;
        }
        private Dictionary<string, Store> StoreChoiceAndAnswer()
        {
            _Store = new Store(Answer, choices);
            doctoChoices[QuestionBody] = _Store;
            return doctoChoices;
        }
        public static bool CheckAnswer(string question, string answer) => doctoChoices[question].answer == answer;
        
       
    }
}
