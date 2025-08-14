

namespace Task4
{
    public record Store(string answer, string[] choices);
    enum QuestionType
    {
        TrueOrFalse = 1,
        ChoiceOne = 2,
        MultipleChoice = 3
    }

    internal abstract class QuestionBank
    {
        public string? QuestionLevel { get; private set; }
        public int QuestionMark { get; private set; }
        public QuestionType QuestionType { get; private set; }
        public string? QuestionBody { get; private set; }
        public static List<QuestionBank> Questions = new();
        protected QuestionBank(string? QuestionLevel, int QuestionMark, QuestionType QuestionType, string? QuestionBody)
        {
            this.QuestionLevel = QuestionLevel;
            this.QuestionMark = QuestionMark;
            this.QuestionType = QuestionType;
            this.QuestionBody = QuestionBody;
        }
        public abstract List<QuestionBank> AddQuestion(QuestionBank question);
        




    }
}
