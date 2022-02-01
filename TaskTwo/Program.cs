

/*
 * Darren Fisher
 * MIS 3033
 * HW 2 
 */

/*
 Task 2

Redo task 1, however this time use a dictionary.  Your key value will be the fruit name and the 
value will be the price of the piece of fruit.


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
using System.Collections.Generic;

namespace hwTwoMacVersion
{
    class Program
    {
        // 2 arrays that hold the items for purchase and price
       
        private static Dictionary<string, double> listOfFruit = new Dictionary<string, double>
        {
            {"apples",.99},
            {"oranges",.5},
            {"bananas",.5},
            {"grapes",2.99},
            {"blueberries",1.99}
        };


        static void Main(string[] args)
        {

            Console.WriteLine("You can purchase:\n");
            foreach (var x in listOfFruit)
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
                
                // if the user inputs a string that is correct spelling
                if (listOfFruit.ContainsKey(userInput))
                {
                    correctInput = true;

                    Console.WriteLine("The price of " + listOfFruit[userInput] + " is: " + listOfFruit[userInput].ToString("C2"));

                }
                // if the user wants to stop entering fruits and getting the cost
                else if(userInput.ToLower() == "stop")
                {
                    Console.WriteLine("Done Shopping? Have a good day!");

                }
                // if the user entered a string that is not "stop" or a correct spelling in our list
                //else if ((userInput.ToLower() != "stop") && (correctInput = false))
                //{
                //    Console.WriteLine("Warning! You entered a fruit that is not in our list.");
                //}
                else
                {
                    Console.WriteLine("Warning! You entered a fruit that is not in our list.");

                }
            }


        }


    }
}