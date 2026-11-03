namespace ExaminationSystem.Classes.Helpers;
public static class Helper
{
    public static int GetNumber(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        return number;
    }
    public static int GetNumberInRange(string prompt, int min, int max)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number >= min && number <= max)
                {
                    break;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        return number;
    }
    public static string GetString(string prompt)
    {
        string text;
        while (true)
        {
            Console.Write(prompt);
            text = Console.ReadLine()!;
            if (!string.IsNullOrWhiteSpace(text))
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a valid string.");
        }
        return text;
    }
    public static void DoubleSeparator()
    {
        Console.WriteLine("========================================");
    }
    public static void SingleSeparator()
    {
        Console.WriteLine("----------------------------------------");
    }
    public static void PressAnyKeyToContinue()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
