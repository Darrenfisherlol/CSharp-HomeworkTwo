

/*
 * Darren Fisher
 * MIS 3033
 * HW 2 
 */

/*
 Task 1
Create a console application. Your console application should contain two parallel arrays, as well 
as an error if they enter or spell the item name incorrectly.
Array #1: should contain items apples, oranges, bananas, grapes, blueberries
Array #2: should contain prices for each item. Apples are 0.99, oranges are 0.50, bananas are 
0.50, grapes are 2.99, blueberries are 1.99.
Your application can
1) show all the items to users;
2) prompt the user to enter the item they desire, then returns the item and the price of the item. 
Format the price as currency.
*/

using System;

namespace taskOne
{
    class Program
    {
        // 2 arrays that hold the items for purchase and price
        static double[] price = { .99, .5, .5, 2.99, 1.99 };
        static string[] fruits = { "apples", "oranges", "bananas", "grapes", "blueberries" };

        static void Main(string[] args)
        {

            Console.WriteLine("You can purchase:\n");
            foreach (var x in fruits)
            {
                Console.WriteLine(x);
            }

            userWantedItem();

            Console.ReadLine();
        }

        static void userWantedItem()
        {

            Console.WriteLine("Enter \"stop\" to stop the program.\n");

            Console.WriteLine("Enter one of the items desired\n");

            string userInput = "";
            bool correctInput = false;

            while (userInput != "stop")
            {
                userInput = Console.ReadLine().ToLower();

                // iterate through the fruits list
                for (int x = 0; x < fruits.Length; x++)
                {
                    // if the user inputs a string that is correct spelling
                    if (userInput == fruits[x])
                    {
                        correctInput = true;

                        Console.WriteLine("The price of " + fruits[x] + " is: " + price[x].ToString("C2"));

                    }

                }

                // if the user wants to stop entering fruits and getting the cost
                if (userInput.ToLower() == "stop")
                {
                    Console.WriteLine("Done Shopping? Have a good day!");

                }

                // if the user entered a string that is not "stop" or a correct spelling in our list
                if ((userInput.ToLower() != "stop") && (!correctInput))
                {
                    Console.WriteLine("Warning! You entered a fruit that is not in our list.");

                }

                // resets correct input so if the user enters another word, its not accidently marked as true
                correctInput = false;
            }
        }
    }
}