using System;
using System.Linq;
using System.Collections.Generic;

class LinqExercise02
{
    public static void SolutionSQL()
    {
        var arr1 = new[] { 1, 3, 5, 7, 9 };

        Console.Write("\nLINQ : Find the number and its square of an array which is more than 20 : ");
        Console.Write("\n------------------------------------------------------------------------\n");

        var query = from int number in arr1
                    let sqrtNum = number * number
                    where sqrtNum > 20
                    select new { number, sqrtNum };

        foreach (var a in query)
            Console.WriteLine(a);

        Console.ReadLine();
    }

    public static void SolutionMethod()
    {
        var arr1 = new[] { 1, 3, 5, 7, 9 };

        Console.Write("\nLINQ : Find the number and its square of an array which is more than 20 : ");
        Console.Write("\n------------------------------------------------------------------------\n");

        var query = arr1.Where(x => x * x > 20).Select(x => new { number = x, sqrtNum = x * x });

        foreach (var a in query)
            Console.WriteLine(a);

        Console.ReadLine();
    }
}