using ExaminationSystem.Classes.Helpers;
using ExaminationSystem.Classes.Questions;
using System.Diagnostics;

namespace ExaminationSystem.Classes.Exams
{
    internal class PracticalExam : Exam
    {
        // cons
        public PracticalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        { }
        public PracticalExam(int timeOfExam, int numberOfQuestions, Question[] questions) : base(timeOfExam, numberOfQuestions, questions)
        { }

        // meths
        public override void ShowExam()
        {
            IsFinished = false;
            Sw = Stopwatch.StartNew();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"\nQuestion {i + 1} - ");
                Console.WriteLine(Questions[i]);
                int answerId = Helper.GetNumberInRange("Enter Answer Id: ", 1, Questions[i].AnswerList.Length);
                Questions[i].StudentAnswer = Questions[i].AnswerList[answerId - 1];
                Console.WriteLine();
                Helper.SingleSeparator();
            }
            Sw.Stop();
            IsFinished = true;
        }
        public override void ShowExamResults()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"Question {i + 1}: ");
                Questions[i].ShowAnswerResult();
                Helper.SingleSeparator();
            }
            Console.WriteLine($"Total Time: {Sw.Elapsed:hh\\:mm\\:ss} ");
        }
        public override void CreateQuestions(string header = "")
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine(header);
            Helper.DoubleSeparator();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Write($"\nQuestion {i + 1} - ");
                MCQQuestion mCQQuestion = new MCQQuestion();
                Questions[i] = mCQQuestion.CreateQuestion();

                Console.WriteLine();
                if (i < NumberOfQuestions - 1)
                    Helper.SingleSeparator();
            }
        }
    }
}
