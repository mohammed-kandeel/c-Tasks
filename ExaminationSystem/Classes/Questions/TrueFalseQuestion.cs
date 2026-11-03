using ExaminationSystem.Classes.Helpers;

namespace ExaminationSystem.Classes.Questions
{
    internal class TrueFalseQuestion : Question
    {
        // cons
        public TrueFalseQuestion() : base("True or False:", "", new Answer(0, "Not Answered"), 0, new Answer[0])
        {
        }
        public TrueFalseQuestion(string body, Answer rightAnswer, int mark, Answer[] answerList) : base("True or False:", body, rightAnswer, mark, answerList)
        {
        }

        // meths
        public override Question CreateQuestion()
        {
            //question body
            string questionBody = Helper.GetString("Enter the question: ");

            //marks
            int marks = Helper.GetNumberInRange("Enter the question marks: ", 1, int.MaxValue);

            //answers
            Answer[] answerList =
            [
                new Answer(1, "True"),
                new Answer(2, "False")
            ];

            // create question
            int correctAnswerId = Helper.GetNumberInRange("Enter the correct answer id (1 for True ,2 for False): ", 1, 2);
            Answer correctAnswer = answerList[correctAnswerId - 1];
            return new TrueFalseQuestion(questionBody, correctAnswer, marks, answerList);
        }
    }
}
