namespace G04___OOP_Exam;
using System.Timers;

public abstract class Exam
{
    protected int UserMark ;
    protected int totalMark ;
    private Timer timeOfExam  ;
    protected int NumberOfQuestions;
    protected Question[] questions;
    protected Subject subject;
    protected Answer[] userAnswers;
    public abstract void GetQuestions();

    protected void GetTime()
    {
        bool success = true;
        double time;
        do
        {
            if(!success) Console.WriteLine("Invalid input. Try again.");
            Console.Write("Enter time of exam in minutes: "); 
            success = double.TryParse(Console.ReadLine(), out time);
        } while (!success  || time <= 0);

        timeOfExam = new Timer(time*60*1000);

    }

    private void TimeOfExamOnElapsed(object? sender, ElapsedEventArgs e)
    {
        Console.Clear();
        EndExam();
        Console.WriteLine("You ran out of time :(");
        Environment.Exit(0);
    }
    
    protected void GetNumberOfQuestions()
    {
           
        bool success = true;
        do
        {
            if(!success) Console.WriteLine("Invalid input. Try again.");
            Console.Write("Enter number of questions: "); 
            success = int.TryParse(Console.ReadLine(), out NumberOfQuestions);
        } while (!success  || NumberOfQuestions <= 0);
    }
    public void StartExam()
    {
        
        timeOfExam.Elapsed += TimeOfExamOnElapsed;
        timeOfExam.Enabled = true;
        timeOfExam.Start();
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            userAnswers[i] = questions[i].Ask();
            UserMark += questions[i].GradeAnswer(userAnswers[i]);
            totalMark += questions[i].Mark;
            Console.WriteLine("=====================================");
        } 
        Console.Clear();
        EndExam();
        
    }
        
    protected abstract void EndExam();

}

public sealed class PracticalExam : Exam
{
    public PracticalExam( Subject subject)
    {
        this.subject = subject;
        GetTime();
        GetNumberOfQuestions();
        questions = new McQuestion[NumberOfQuestions];
        userAnswers = new Answer[NumberOfQuestions];
        GetQuestions();
    }

    protected override void EndExam()
    {
        Console.Clear();
        
        for(int i=0;i<NumberOfQuestions;i++)
        {
            Console.WriteLine($"{i}.{questions[i].Body}");
            Console.WriteLine($"Right Answer:{questions[i].RightAnswer}");
        }
    }

    public override void GetQuestions()
    {
        for (int i = 0; i < NumberOfQuestions; i++)
        {
           questions[i] = new McQuestion(); 
           Console.Clear();
        }
    }
}    
public sealed class FinalExam : Exam
{
    public FinalExam( Subject subject)
    {
        this.subject = subject;
        GetTime();
        GetNumberOfQuestions();
        questions = new Question[NumberOfQuestions];
        userAnswers = new Answer[NumberOfQuestions];
        GetQuestions();
    }

    protected override void EndExam()
    {
        Console.Clear();
        Console.WriteLine("Your answers: ");
        for(int i=0;i<NumberOfQuestions;i++)
        {
            Console.WriteLine($"Q{i+1})\t{ questions[i].Body }: {userAnswers[i]}");
        }

        Console.WriteLine($"Your mark: { UserMark } out of {totalMark}");
    }

    public override void GetQuestions()
    {
        for (int i = 0; i < NumberOfQuestions; i++)
        {
            int type;
            bool success = true;
            do
            {
                if(!success) Console.WriteLine("Invalid Input");
                Console.WriteLine($"Enter type of question {i+1}: \n1.True or false\t\t2.Multiple Choice Question"); 
                success = int.TryParse(Console.ReadLine(), out type);
            } while (!success || type < 1 || type > 2);

            Console.Clear();
            if (type == 1)
            {
                questions[i] = new TrueOrFalseQuestion();
            }
            else questions[i] = new McQuestion();
            Console.Clear();
        }
    }
}    
