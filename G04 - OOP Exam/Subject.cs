namespace G04___OOP_Exam;

public class Subject
{
    public int SubjectId { get ; private set; }
    public string Name { get ;private set;  }
    public Exam @Exam;

    public Subject(int id, string name)
    {
       SubjectId = id;
       this.Name = name; 
       GetExam();
    }

    private void GetExam()
    {
            int type;
            bool success = true;
            do
            {
                if(!success) Console.WriteLine("Invalid Input");
                Console.WriteLine("Enter type of Exam: \n1.Final Exam\t2.Practical Exam"); 
                success = int.TryParse(Console.ReadLine(), out type);
            } while (!success || type < 1 || type > 2);
            

            if (type == 1)
            {
                Exam = new FinalExam( this);
            }
            else Exam = new PracticalExam(this);
    }
}