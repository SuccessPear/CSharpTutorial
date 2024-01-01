using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise;
class LinqExercise01
{
    public static void SolutionSQL()
    {
        string str;

        Console.Write("\nLINQ : Display the characters and frequency of character from giving string : ");
        Console.Write("\n----------------------------------------------------------------------------\n");
        str = "media platform - solution group";
        Console.Write("\n");

        var query = from x in str
                    group x by x into y
                    orderby y.Key
                    select y;
        Console.Write("The frequency of the characters are :\n");
        foreach (var arrEle in query)
        {
            Console.WriteLine("Character " + arrEle.Key + ": " + arrEle.Count() + " times");
        }
    }

    public static void SolutionMethod()
    {
        string str;

        Console.Write("\nLINQ : Display the characters and frequency of character from giving string : ");
        Console.Write("\n----------------------------------------------------------------------------\n");
        str = "media platform - solution group";
        Console.Write("\n");

        var query = str.GroupBy(x => x)
               .OrderBy(y => y.Key)
               .Select(y => y);
        Console.Write("The frequency of the characters are :\n");
        foreach (var arrEle in query)
        {
            Console.WriteLine("Character " + arrEle.Key + ": " + arrEle.Count() + " times");
        }
    }
}