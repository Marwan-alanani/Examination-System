using System.Diagnostics;
using System.Timers;
using Timer = System.Timers.Timer;

namespace G04___OOP_Exam;

class Program
{
    static void Main()
    {
        Subject s = new Subject(1, "Math");
        char choice;
        bool success = true;
        while (true)
        {
            do
            {
                if (!success) Console.WriteLine("Invalid input. Try again.");
                Console.Write("Do you want to start the exam? (y/n): ");
                choice = Console.ReadKey().KeyChar;
                Console.WriteLine();
                success = choice is 'y' or 'n';
            } while (!success);

            if (choice == 'y')
            {
                Console.Clear();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                s.Exam.StartExam();
                Console.WriteLine($"Time elapsed: {sw.Elapsed}");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Waiting for 3 seconds...");
               Thread.Sleep(3000); 
               Console.Clear();
               Console.WriteLine("What about now ?");
            }
        }
    }
}