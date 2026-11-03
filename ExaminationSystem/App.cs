using ExaminationSystem.Classes.Helpers;
using ExaminationSystem.Classes.Subject;

namespace ExaminationSystem
{
    internal class App
    {
        // props
        public List<Subject> SubjectList { get; set; }

        // cons
        public App()
        {
            SubjectList = new List<Subject>();
        }

        // meths
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Helper.DoubleSeparator();
                Console.WriteLine("Welcome to the Examination System");
                Helper.DoubleSeparator();

                Console.WriteLine("1. Create Subject");
                Console.WriteLine("2. Show Subjects");
                Console.WriteLine("3. Create Exam");
                Console.WriteLine("4. Show Exam");
                Console.WriteLine("5. Show Exam Results");
                Console.WriteLine("0. Exit");

                int choice = Helper.GetNumberInRange("Enter your choice: ", 0, 5);

                switch (choice)
                {
                    case 1:
                        CreateSubject();
                        Helper.PressAnyKeyToContinue();
                        break;

                    case 2:
                        ShowSubjects();
                        Helper.PressAnyKeyToContinue();
                        break;

                    case 3:
                        CreateExam();
                        Helper.PressAnyKeyToContinue();
                        break;

                    case 4:
                        ShowExam();
                        Helper.PressAnyKeyToContinue();
                        break;

                    case 5:
                        ShowExamResults();
                        Helper.PressAnyKeyToContinue();
                        break;

                    case 0:
                        return;
                }
            }
        }
        public void CreateSubject()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine("Create Subject");
            Helper.DoubleSeparator();


            string subjectId;
            while (true)
            {
                subjectId = Helper.GetString("Enter Subject ID: ");

                if (SubjectList.Any(s => s.SubjectId == subjectId))
                {
                    Console.WriteLine("Subject ID already exists. Please enter a unique Subject ID.");
                    continue;
                }
                break;
            }

            string subjectName = Helper.GetString("Enter Subject Name: ");
            Subject subject = new Subject(subjectId, subjectName);

            SubjectList.Add(subject);

            Helper.SingleSeparator();
            Console.WriteLine("Subject created successfully!");
        }
        public void ShowSubjects()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine("Subjects List");
            Helper.DoubleSeparator();

            if (SubjectList.Count == 0)
                Console.WriteLine("No subjects available.");
            else
            {
                for (int i = 0; i < SubjectList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {SubjectList[i].SubjectName} (ID: {SubjectList[i].SubjectId})");
                }
            }
            Helper.SingleSeparator();
        }
        public void CreateExam()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine("Create Exam");
            Helper.DoubleSeparator();

            if (SubjectList.Count == 0)
            {
                Console.WriteLine("No subjects available. Please create a subject first.");
                return;
            }

            for (int i = 0; i < SubjectList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SubjectList[i].SubjectName} (ID: {SubjectList[i].SubjectId})");
            }

            Helper.SingleSeparator();
            int subjectIndex = Helper.GetNumberInRange("Enter the subject number to create an exam for or 0 to go back: ", 0, SubjectList.Count);

            if (subjectIndex == 0)
            {
                return;
            }

            Helper.SingleSeparator();

            if(SubjectList[subjectIndex - 1].Exam != null)
            {
                Console.WriteLine("An exam already exists for this subject. Do you want to overwrite it? (1 for yes, 0 for no)");
                if (Helper.GetNumberInRange("", 0, 1) == 0)
                {
                    return;
                }
            }

            SubjectList[subjectIndex - 1].CreateExam();
            
            Helper.SingleSeparator();
            Console.WriteLine("Exam created successfully!");
        }
        public void ShowExam()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine("Show Exam");
            Helper.DoubleSeparator();

            if (SubjectList.Count == 0)
            {
                Console.WriteLine("No subjects available.");
                return;
            }

            for (int i = 0; i < SubjectList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SubjectList[i].SubjectName} (ID: {SubjectList[i].SubjectId})");
            }

            Helper.SingleSeparator();
            int subjectIndex = Helper.GetNumberInRange("Enter the subject number to show its exam or 0 to go back: ", 0, SubjectList.Count);

            if (subjectIndex == 0)
            {
                return;
            }

            Helper.SingleSeparator();
            if(SubjectList[subjectIndex - 1].Exam == null)
            {
                Console.WriteLine("No exam available for this subject.");
                return;
            }


            string availableExam = SubjectList[subjectIndex - 1].Exam.GetType().Name.Replace("Exam", " Exam");
            Console.WriteLine($"The available exam is : {availableExam}\nDo you want to start the exam? (1 for yes, 0 for no)");
            if (Helper.GetNumberInRange("", 0, 1) == 1)
            {
                Console.WriteLine();
                SubjectList[subjectIndex - 1].ShowExam();
            }
        }
        public void ShowExamResults()
        {
            Console.Clear();
            Helper.DoubleSeparator();
            Console.WriteLine("Show Exam Results");
            Helper.DoubleSeparator();

            if (SubjectList.Count == 0)
            {
                Console.WriteLine("No subjects available.");
                return;
            }

            for (int i = 0; i < SubjectList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {SubjectList[i].SubjectName} (ID: {SubjectList[i].SubjectId})");
            }

            Helper.SingleSeparator();

            int subjectIndex = Helper.GetNumberInRange("Enter the subject number to show its exam results or 0 to go back: ", 0, SubjectList.Count);
            if (subjectIndex == 0)
            {
                return;
            }

            Helper.SingleSeparator();

            if (SubjectList[subjectIndex - 1].Exam == null || !SubjectList[subjectIndex - 1].Exam.IsFinished)
            {
                Console.WriteLine("No exam results available for this subject.");
                return;
            }

            SubjectList[subjectIndex - 1].ShowExamResults();
        }
    }
}
