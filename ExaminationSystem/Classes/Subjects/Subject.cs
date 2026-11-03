using ExaminationSystem.Classes.Exams;
using ExaminationSystem.Classes.Helpers;

namespace ExaminationSystem.Classes.Subject
{
    internal class Subject
    {
        // props
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam Exam { get; set; }

        // cons
        public Subject()
        {
            SubjectId = string.Empty;
            SubjectName = string.Empty;
            Exam = null!;
        }
        public Subject(string subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            Exam = null!;
        }
        public Subject(string subjectId, string subjectName, Exam exam) : this(subjectId, subjectName)
        {
            Exam = exam;
        }

        // meths
        public void CreateExam()
        {
            int examType = Helper.GetNumberInRange("Enter the type of exam (1 for Practical, 2 for Final): ", 1, 2);

            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine(ToString());
            Helper.DoubleSeparator();

            int numberOfQuestions = Helper.GetNumberInRange("Enter the number of questions: ", 1, int.MaxValue);
            int timeOfExam = Helper.GetNumberInRange("Enter the exam time (30 to 180 minutes): ", 30, 180);

            if (examType == 1)
                Exam = CreatePracticalExam(timeOfExam, numberOfQuestions);
            else
                Exam = CreateFinalExam(timeOfExam, numberOfQuestions);

            Exam.CreateQuestions(ToString());
        }
        private PracticalExam CreatePracticalExam(int timeOfExam, int numberOfQuestions)
        {
            return new PracticalExam(timeOfExam, numberOfQuestions);
        }
        private FinalExam CreateFinalExam(int timeOfExam, int numberOfQuestions)
        {
            return new FinalExam(timeOfExam, numberOfQuestions);
        }
        public void ShowExam()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine(ToString());
            Helper.DoubleSeparator();

            if (Exam is not null)
            {
                Exam.ShowExam();
                Exam.ShowExamResults();
            }
            else
            {
                Console.WriteLine("No exam created for this subject.");
            }
        }
        public void ShowExamResults()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine(ToString());
            Helper.DoubleSeparator();
            if (Exam is not null)
            {
                Exam.ShowExamResults();
            }
            else
            {
                Console.WriteLine("No exam created for this subject.");
            }
        }
        public override string ToString()
        {
            string text = $"Subject: {SubjectId} - {SubjectName}";
            if (Exam is not null)
            {
                text += $"\nExam: {Exam.GetType().Name} ({Exam.NumberOfQuestions} questions, ";
                if (Exam.TotalMarks > 0)
                    text += $"{Exam.TotalMarks} marks,";
                text += $" {Exam.TimeOfExam} minutes)";
            }
            return text;
        }
    }
}
