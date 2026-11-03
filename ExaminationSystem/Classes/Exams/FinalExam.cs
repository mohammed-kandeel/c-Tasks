using ExaminationSystem.Classes.Helpers;
using ExaminationSystem.Classes.Questions;
using System.Diagnostics;

namespace ExaminationSystem.Classes.Exams
{
    internal class FinalExam : Exam
    {
        // cons
        public FinalExam(int timeOfExam, int numberOfQuestions) : base(timeOfExam, numberOfQuestions)
        { }
        public FinalExam(int timeOfExam, int numberOfQuestions, Question[] questions) : base(timeOfExam, numberOfQuestions, questions)
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
            Console.WriteLine($"Student Marks: {StudentMarks}/{TotalMarks}");
        }
        public override void CreateQuestions(string header = "")
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine(header);
            Helper.DoubleSeparator();

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                int QuestionType = Helper.GetNumberInRange("\nEnter Question Type (1 for MCQ, 2 for True/False): ", 1, 2);
                Console.Write($"\nQuestion {i + 1} - ");

                if (QuestionType == 1)
                {
                    MCQQuestion mCQQuestion = new MCQQuestion();
                    Questions[i] = mCQQuestion.CreateQuestion();
                }
                else
                {
                    TrueFalseQuestion trueFalseQuestion = new TrueFalseQuestion();
                    Questions[i] = trueFalseQuestion.CreateQuestion();
                }
                Console.WriteLine();
                if (i < NumberOfQuestions - 1)
                    Helper.SingleSeparator();
            }
        }
    }
}
