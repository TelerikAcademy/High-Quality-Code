using System;
using System.Diagnostics;
using System.Linq;

class AssertionsDemo
{
    private static bool PerformAction()
    {
        Console.WriteLine("Action performed.");
        return true;
    }

    static void Main()
    {
        Debug.Assert(PerformAction(), "Could not perform action");

        StudentGradesCalculator calc = new StudentGradesCalculator(new int[] { 6, 5, 5, 4, 6, 6, 5, 6 });
        Console.WriteLine(calc.GetAverageStudentGrade());

        calc = new StudentGradesCalculator(new int[] { });
        Console.WriteLine(calc.GetAverageStudentGrade());
    }
}
