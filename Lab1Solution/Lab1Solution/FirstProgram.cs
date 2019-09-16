using System;
public class FirstProgram
{
    public static void Main()
    {
        int num;
        do
        {
            num = int.Parse(Console.ReadLine());
        } while (num==int.Parse(""));
        Console.Write("The maximum integer you entered is " +num);
        Console.Write("\nThe minimum integer you entered is " +num);
        Console.Write("\nThe number of odd integer(s) you entered is " + num);
        Console.Write("\nThe number of even integer(s) you entered is " + num);
    }
}