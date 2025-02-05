using System.Text;

namespace G04___OOP_Exam;

public abstract class Question
{
   protected  abstract string Header { get; }
   public string Body
   {
      get ;
      private set ;
   }
   private int mark;
   public Answer RightAnswer { get; private set; }
   protected Answer[] AnswersList ;
   protected void GetBody()
   {
      Console.Write("Enter body of the question: ");
      Body = Console.ReadLine();
   }

   public Answer Ask()
   {
      bool success = true;
      int answerIdx;
      do
      {
         if (!success)
         {
            Console.WriteLine("Invalid input. Try again.");
         }
         Console.Write(this);
         Console.Write("Enter your answer: ");
         success = int.TryParse(Console.ReadLine(), out answerIdx);
      } while (!success || answerIdx < 1 || answerIdx > this.AnswersList.Length);
      Answer answer  = this.AnswersList[answerIdx-1];
      return answer;
   }

   private void PrintChoices()
   {
      for(int i = 0; i < AnswersList.Length; i++)
      {
         Console.Write($"{i+1}.{AnswersList[i]}\t"); 
      }

      Console.WriteLine();
   }
   protected void GetRightAnswer()
   {
      int answerIdx;
      bool success = true;
      do
      {
         if (!success)
         {
            Console.WriteLine("Invalid input. Try again.");
         }
         PrintChoices();
         Console.Write("Enter right answer: ");
         success = int.TryParse(Console.ReadLine(), out answerIdx);
      }while(!success || answerIdx < 1 || answerIdx > AnswersList.Length);
      RightAnswer = AnswersList[answerIdx - 1];
   }
   
   
   protected void GetMark()
   {
      bool success = true;
      do
      {
         if (!success)
         {
            Console.WriteLine("Invalid input. Try again.");
         }
         Console.Write("Enter mark of the question: ");
         success = int.TryParse(Console.ReadLine(), out mark);
      }while(!success || mark < 1 );
   }
   public override string ToString()
   {
      StringBuilder content= new StringBuilder( $"{Header}   Marks: {mark}\n{Body}\n");
      for (int i=0;i<AnswersList.Length;i++) content.Append( $"{i+1}.{AnswersList[i]}\t");
      content.Append( "\n");
      content.Append( "--------------------------------------------\n");
      return content.ToString();
   }

   public int GradeAnswer( Answer userAnswer)
   {
      return (userAnswer == RightAnswer) ?   mark : 0 ;
   }
}

public class McQuestion : Question
{
   protected  override string Header { get => "Choose one of the following choices: "; }

   public McQuestion()
   {
      AnswersList = new Answer[3];
      GetBody();
      GetAnswers();
      GetRightAnswer();
      GetMark();
   }


   private void GetAnswers()
   {
      for (var i = 0; i < AnswersList.Length; i++)
      {
         Console.Write($"Enter {i+1} choice: ");
         AnswersList[i] = new Answer( Console.ReadLine());
      }
   }
}


public class TrueOrFalseQuestion : Question
{
   protected override string Header{get => "True or False Question";}
   
   public TrueOrFalseQuestion()
   {
      AnswersList = [ new Answer("True") , new Answer("False")] ;
      GetBody();
      GetRightAnswer();
      GetMark();
   }
   
}
