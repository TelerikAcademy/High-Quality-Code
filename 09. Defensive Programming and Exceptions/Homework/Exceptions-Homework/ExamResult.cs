using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new Exception();
        }
        if (minGrade < 0)
        {
            throw new Exception();
        }
        if (maxGrade <= minGrade)
        {
            throw new Exception();
        }
        if (comments == null || comments == "")
        {
            throw new Exception();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
