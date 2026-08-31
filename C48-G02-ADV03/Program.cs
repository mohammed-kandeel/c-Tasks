namespace C48_G02_ADV03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1 List
            //List<int> grades = new([85, 92, 78, 95, 88, 70, 100, 65]);

            ////// 2
            //Console.WriteLine($"Collection: {string.Join(" ,", grades)}");
            //Console.WriteLine($"Count: {grades.Count}");
            //Console.WriteLine($"First Grade: {grades[0]}");
            //Console.WriteLine($"Last Grade: {grades[^1]}");
            //Console.WriteLine();

            ////// 3
            //grades.Sort();
            //Console.WriteLine($"Sorted Grades: {string.Join(" ,", grades)}");
            //Console.WriteLine();

            ////// 4
            //Console.WriteLine($"first grade above (90) => {grades.Find(n => n > 90)}");
            //Console.WriteLine();


            ////// 5
            //Console.WriteLine($"Failing Grades => {string.Join(" ,", grades.FindAll(n => n < 75))}");
            //Console.WriteLine();

            ////// 6
            //grades.RemoveAll(n => n < 75);
            //Console.WriteLine($"Remove All Failing Grades => {string.Join(" ,", grades)}");
            //Console.WriteLine();

            ////// 7
            //Console.WriteLine($"Is Any grade equals 100 => {grades.Exists(n => n == 100)}");
            //Console.WriteLine();

            ////// 8
            //List<string> stringGrades = new();
            //foreach (var grad in grades)
            //{
            //    stringGrades.Add($"Grade: {grad}");
            //}
            //Console.WriteLine($"stringGrades:\n{string.Join("\n", stringGrades)}");
            #endregion

            #region Q2 SortedDictionary

            //SortedDictionary<int, string> leaderboard = new()
            //{
            //    {500, "Ahmed"},
            //    {200, "Sara"},
            //    {800, "Ali"},
            //    {350, "Mona"}
            //};

            ////2
            //foreach (KeyValuePair<int, string> pair in leaderboard)
            //{
            //    Console.WriteLine($"Score: {pair.Key}, Player: {pair.Value}");
            //}
            //Console.WriteLine();

            ////3
            //Console.WriteLine($"Firest Key: {leaderboard.First().Key} , Last Key: {leaderboard.Last().Key}");
            //Console.WriteLine();

            ////4
            //Console.WriteLine($"IS (500) exists : {leaderboard.ContainsKey(500)}");
            //Console.WriteLine();

            ////5
            //bool isExist = leaderboard.TryGetValue(999, out string value);
            //Console.WriteLine($"Score: 999, Player: {(isExist ? value : "No Pleyer Found")}");
            //Console.WriteLine();

            ////6
            //leaderboard.Remove(200);

            //Console.WriteLine("Uptaded List: ");
            //foreach (KeyValuePair<int, string> pair in leaderboard)
            //{
            //    Console.WriteLine($"Score: {pair.Key}, Player: {pair.Value}");
            //}
            //Console.WriteLine();
            #endregion

            #region Q3 Dictionary

            //Dictionary<string, string> phoneBooks = new()
            //{
            //    ["Ali"] = "0123",
            //    ["Sara"] = "456",
            //    ["Omar"] = "789",
            //    ["Aya"] = "741"
            //};
            ////2 add
            //phoneBooks["Mohamed"] = "963";

            ////3
            //try
            //{
            //    phoneBooks.Add("Aya", "852");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}
            //Console.WriteLine();

            ////4
            //bool isAdded = phoneBooks.TryAdd("Sara", "852");
            //Console.WriteLine($"Is Contact Added succefuly: {isAdded}");
            //Console.WriteLine();

            ////5
            //bool isExist = phoneBooks.ContainsKey("ali");
            //Console.WriteLine($"Search For 'ali' Contact if exist: {isExist}");
            //Console.WriteLine();

            ////6
            //bool isExist2 = phoneBooks.TryGetValue("ali", out string searchValue);
            //Console.WriteLine($"Get 'ali' Contact: {(isExist2 ? searchValue : "Not Found")}");
            //Console.WriteLine();

            ////7
            //Console.WriteLine("Keys: " + string.Join(", ", phoneBooks.Keys));
            //Console.WriteLine("Values: " + string.Join(", ", phoneBooks.Values));


            #endregion

            #region Q4 HashSet

            //HashSet<string> emails = new(StringComparer.OrdinalIgnoreCase)
            //{
            //    "ahmed@test.com",
            //    "AHMED@test.com",
            //    "sara@test.com",
            //    "Sara@Test.Com"
            //};

            ////3
            //Console.WriteLine($"count: {emails.Count}");
            //Console.WriteLine("2 becouse we but condition that Ignore Case so HashSet see \"ahmed@test.com\" and \"AHMED@test.com\" as one email and also \"sara@test.com\" and \"Sara@Test.Com\"");
            //Console.WriteLine("and HashSet only store unique values so he sostor only \"ahmed@test.com\" and \"sara@test.com\"");
            //Console.WriteLine();

            ////4
            //HashSet<int> setA = [1, 2, 3, 4, 5];
            //HashSet<int> setB = [4, 5, 6, 7, 8];

            ////5
            //setA.UnionWith(setB);
            //Console.WriteLine($"UnionWith =>  {string.Join(" ,", setA)}");

            //setA.IntersectWith(setB);
            //Console.WriteLine($"IntersectWith =>  {string.Join(" ,", setA)}");

            //setA.ExceptWith(setB);
            //Console.WriteLine($"ExceptWith =>  {string.Join(" ,", setA)}");

            ////6
            //setB = [ 1, 2];
            //bool result = setB.IsSubsetOf(setA);
            //Console.WriteLine("{1, 2}" + $" is a subset of Set A: {result}");

            #endregion

            #region Q5 Queue

            //Queue<string> queue = new Queue<string>(["Report.pdf", "Invoice.pdf", "Letter.docx", "Resume.pdf"]);
            //queue.Enqueue("Photo.jpg");

            ////1
            //Console.WriteLine($"Content: {string.Join(", ", queue)}  \ncount: {queue.Count}");
            //Console.WriteLine();

            ////2
            //Console.WriteLine(queue.Peek());
            //Console.WriteLine();

            ////3
            //while (queue.Count>0)
            //{
            //    Console.WriteLine($"Printing: [{queue.Dequeue()}]");
            //}
            //Console.WriteLine();

            ////4 
            //bool isEmpety = queue.TryDequeue(out string value);
            //Console.WriteLine($"it will return false and out value will be defualt (null)");
            #endregion

            #region Q6 Stack

            //Stack<string> history = new Stack<string>();

            ////1
            //history.Push("google.com");
            //history.Push("github.com");
            //history.Push("stackoverflow.com");
            //history.Push("youtube.com");
            //history.Push("claude.ai");

            ////2
            //Console.WriteLine($"Top Of Stack: {history.Peek()} ");
            //Console.WriteLine();

            ////3
            //Console.WriteLine($"back: {history.Pop()}");
            //Console.WriteLine($"back: {history.Pop()}");
            //Console.WriteLine($"back: {history.Pop()}");
            //Console.WriteLine();

            ////4
            //Console.WriteLine($"Curent Page: {history.Peek()}");
            //Console.WriteLine();

            ////5
            //string value;
            //bool isEmpety;
            //isEmpety = history.TryPop(out value);
            //isEmpety = history.TryPop(out value);
            //isEmpety = history.TryPop(out value);
            //Console.WriteLine("it Will saflley remove item and if the stack is empety TryPop Will return false and out value null(defualte for string)");

            #endregion
        }
    }
}
