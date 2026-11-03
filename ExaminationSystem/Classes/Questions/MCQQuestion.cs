using ExaminationSystem.Classes.Helpers;

namespace ExaminationSystem.Classes.Questions
{
    internal  class MCQQuestion : Question
    {
        // cons
        public MCQQuestion() : base("Choose The Correct Answer", "", new Answer(0, "Not Answered"), 0, new Answer[0])
        {
        }
        public MCQQuestion(string body, Answer rightAnswer, int mark, Answer[] answerList) : base("Choose The Correct Answer", body, rightAnswer, mark, answerList)
        {
        }

        public override MCQQuestion CreateQuestion()
        {
            //question body
            string questionBody = Helper.GetString("Enter the question: ");

            //marks
            int marks = Helper.GetNumberInRange("Enter the question marks: ", 1, int.MaxValue);

            //answers
            Answer[] answerList = new Answer[4];
            for (int j = 0; j < 4; j++)
            {
                answerList[j] = new Answer(j + 1, Helper.GetString($"Enter answer {j + 1}: "));
            }

            // create question
            int correctAnswerId = Helper.GetNumberInRange("Enter the correct answer id (1-4): ", 1, 4);
            Answer correctAnswer = answerList[correctAnswerId - 1];
            return new MCQQuestion(questionBody, correctAnswer, marks, answerList);
        }
    }
}
