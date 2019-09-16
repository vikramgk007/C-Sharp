using System;
    public class Program
    {
        public static void Main(string[] args)
        {
        //Initializing 'play' variable to repeat the program 
        Console.WriteLine("Lab 2 Implementation\n");
        string play;
        //do-while statement to repeat the loop until the 'play' variable is 'Y' or 'y'
        do
        {
            //Initializing the variable 'nums' as string first
            string nums;
            //Initializing variables to find max, min and assigning the odd, even & their counts to zero initially
            //int? and null is used to assign the values as null
            double? max = null, min = null, even = 0, even_count = 0, odd = 0, odd_count = 0;
            do
            {
                //Console.Write is used to print the characters in the same line
                Console.Write("Enter an integer: ");
                //Reading the value of nums
                nums = Console.ReadLine();
                //Checks and executes the loop if nums string is not null or empty
                if (!string.IsNullOrEmpty(nums))
                {
                    //Initializing a new variable num
                    int num;
                    //Converting the string nums to integer using Int.Parse & assigning it to num
                    num = int.Parse(nums);
                    //Checks whether max is less than num and assign it to num & loops it so that we will get the maximum number
                    if (max < num || max == null)
                        max = num;
                    //Checks whether min is less than num and assign it to num & loops it so that we will get the minimum number
                    if (min > num || min == null)
                        min = num;
                    //Divides the num by 2 & checks whether the reminder is 0, so that the num will be even
                    if (num % 2 == 0)
                    {
                        //Adds the num to even everytime the loop process so that it gets the total sum of even numbers
                        even = even + num;
                        //Increase the even_count to 1 from 0
                        even_count++;
                    }
                    //If the reminder is not 0, then the num is odd
                    else
                    {
                        //Adds the num to odd everytime the loop process so that it gets the total sum of odd numbers
                        odd = odd + num;
                        //Increase the odd_count to 1 from 0
                        odd_count++;
                    }
                }
                //do-while the string nums is not null or Empty
            } while (!string.IsNullOrEmpty(nums));
            //If the even_count and odd_count both is zero means, then you did not enter any integer
            if(even_count==0 && odd_count==0)
            {
                Console.WriteLine("\nYou did not enter any integer");
                //This line will make the compiler to search for the label play_again: and it goes to the line directly
                goto play_again;
            }
            //Adds an empty line - Console.WriteLine goes to a new line/next line
            Console.WriteLine("");
            //Goes to next line and prints the maximum and minimum integer
            Console.WriteLine("The maximum integer you entered is: " + max);
            Console.WriteLine("The minimum integer you entered is: " + min);
            //Adds an empty line - Console.WriteLine goes to a new line/next line
            Console.WriteLine("");
            //Goes to next line and prints the number of odd integer(s) and its sum
            Console.WriteLine("The number of odd integer(s) you entered is: " + odd_count);
            Console.WriteLine("The sum of all odd integer(s) you entered is: " + odd);
            //Checks whether the odd_count is not equals to 0 to avoid exception (divided by 0)
            if (odd_count != 0)
            {
                //Prints the average of all odd integer(s) by computing odd/odd_count
                Console.WriteLine("The average of all odd integer(s) you entered is: " + (odd / odd_count));
            }
            else
            {
                //Prints the average of odd integer is 0 since the odd_count is 0
                Console.WriteLine("The average of all odd integer(s) you entered is: " + odd_count);
            }
            //Adds an empty line - Console.WriteLine goes to a new line/next line
            Console.WriteLine("");
            //Goes to next line and prints the number of even integer(s) and its sum
            Console.WriteLine("The number of even integer(s) you entered is: " + even_count);
            Console.WriteLine("The sum of all even integer(s) you entered is: " + even);
            //Checks whether the even_count is not equals to 0 to avoid exception (divided by 0)
            if (even_count != 0)
            {
                //Prints the average of all even integer(s) by computing odd/odd_count
                Console.WriteLine("The average of all even integer(s) you entered is: " + (even / even_count));
            }
            else
            {
                //Prints the average of even integer is 0 since the even_count is 0
                Console.WriteLine("The average of all even integer(s) you entered is: " + even_count);
            }
            //Console.Write prints the entered text in the same line rather than going to new line
            //'play_again' label is created to invoke a goto and call it anytime inside the program
            play_again: Console.Write("\nPlay again (Y) ? ");
            //Reads the string 'play' from user input
            play = Console.ReadLine();
            //if 'play' equals "N" or "n" then it will goto label end
            if(play == "N" || play == "n")
            {
                goto end;
            }
            //Adds an empty line - Console.WriteLine goes to a new line/next line
            Console.WriteLine("");
            //do-while the string play is equals to Y or y
        } while (play == "y" || play == "Y");
    //'end' label is created to invoke a goto and call it anytime inside the program
    end: Console.WriteLine("");
        Console.WriteLine("Thank You for play. Press Enter to finish. Press any key to continue . . .");
        //Waits for the user to give an input before closing the window suddenly
        Console.ReadLine();
    }
    }
