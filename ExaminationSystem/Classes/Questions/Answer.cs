namespace ExaminationSystem.Classes.Questions;

internal class Answer : IComparable<Answer>
{
    //props
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }

    //cons
    public Answer(int answerId, string answerText)
    {
        AnswerId = answerId;
        AnswerText = answerText;
    }

    //meths
    public int CompareTo(Answer? other)
    {
        if (other == null) return 1;
        return this.AnswerId.CompareTo(other.AnswerId);
    }
    public override string ToString()
    {
        return $"{AnswerId}: {AnswerText}";
    }
}
