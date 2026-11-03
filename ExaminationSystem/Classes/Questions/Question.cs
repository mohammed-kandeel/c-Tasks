namespace ExaminationSystem.Classes.Questions;

internal abstract class Question
{
    //props
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }
    public Answer RightAnswer { get; set; }
    public Answer StudentAnswer { get; set; }
    public Answer[] AnswerList { get; set; }

    // cons
    public Question()
    {
        Header = "Question:";
        Body = "";
        Mark = 0;
        RightAnswer = new Answer(0, "Not Answered");
        StudentAnswer = new Answer(0, "Not Answered");
        AnswerList = new Answer[0];
    }
    public Question(string header, string body, Answer rightAnswer, int mark, Answer[] answerList)
    {
        Header = header;
        Body = body;
        Mark = mark;
        RightAnswer = rightAnswer;
        AnswerList = answerList;
        StudentAnswer = new Answer(0, "Not Answered");
    }

    // meths
    public abstract Question CreateQuestion();
    public void ShowAnswerResult()
    {
        Console.WriteLine($"{Body} ({Mark} degree{(Mark > 1 ? "s" : "")})\n" +
                          $"  Correct Answer: {RightAnswer.AnswerText}\n" +
                          $"  Student Answer: {StudentAnswer.AnswerText}");
    }
    public override string ToString()
    {
        return $"{Header}\n" +
               $" {Body} ({Mark} degree{(Mark > 1 ? "s" : "")})\n" +
               $"  {string.Join("\n  ", AnswerList)}";
    }
}
