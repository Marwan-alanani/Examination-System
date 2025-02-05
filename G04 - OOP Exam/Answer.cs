namespace G04___OOP_Exam;

public  class Answer
{
    private static int id ;
    private int answerId;
    private string answerText;
    public Answer(string answerText)
    {
       this.answerId = id;
       id += 1;
       this.answerText = answerText;
    }

    public override string ToString()
    {
        return answerText;
    }
}
