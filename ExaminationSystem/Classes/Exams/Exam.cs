using ExaminationSystem.Classes.Questions;
using System.Diagnostics;

namespace ExaminationSystem.Classes.Exams
{
    internal abstract class Exam
    {
        //props
        public Question[] Questions { get; set; }
        public int TimeOfExam { get; init; }
        public int NumberOfQuestions { get; init; }
        public Stopwatch Sw { get; set; }
        public int TotalMarks { get => Questions.Sum(q => q?.Mark ?? 0); }
        public int StudentMarks
        {
            get
            {
                return Questions.Sum(q => q.StudentAnswer?.AnswerId == q.RightAnswer?.AnswerId ? q.Mark : 0);
            }
        }
        public bool IsFinished { get; protected set; }

        // cons
        protected Exam(int timeOfExam, int numberOfQuestions)
        {
            TimeOfExam = timeOfExam;
            NumberOfQuestions = numberOfQuestions;
            Sw = new Stopwatch();
            Questions = new Question[NumberOfQuestions];
            IsFinished = false;
        }
        protected Exam(int timeOfExam, int numberOfQuestions, Question[] questions) : this(timeOfExam, numberOfQuestions)
        {
            Questions = questions;
        }

        //meths
        public abstract void ShowExam();
        public abstract void ShowExamResults();
        public abstract void CreateQuestions(string header = "");
    }
}
