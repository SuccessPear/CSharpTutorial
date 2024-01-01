using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise;
class LinqExercise03
{
    public static void SolutionSQL()
    {
        int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

        Console.Write("The numbers in the array are : \n");
        Console.Write("  5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 \n\n");


        var query = from x in nums
                    group x by x into y
                    orderby y.Key
                    select y;

        foreach (var arrEle in query)
        {
            Console.WriteLine("Num: " + arrEle.Key + "\t" + "Frequency: " + arrEle.Count() + "\t" + "Product: " + arrEle.Sum());
        }
        Console.WriteLine();
    }

    public static void SolutionMethod()
    {
        int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };

        Console.Write("The numbers in the array are : \n");
        Console.Write("  5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 \n\n");


        var query = nums.GroupBy(x => x).OrderBy(x => x.Key).Select(x => x);

        foreach (var arrEle in query)
        {
            Console.WriteLine("Num: " + arrEle.Key + "\t" + "Frequency: " + arrEle.Count() + "\t" + "Product: " + arrEle.Sum());
        }
        Console.WriteLine();
    }
}