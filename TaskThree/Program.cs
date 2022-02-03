/*
 *Darren Fisher
 *MIS 3033
 *hw 2 task 3
 */


/* To Do:
 *
 You will be creating an application to help our sales associates sell our main products, cogs and 
gears.  Cogs have a whole sale price of $79.99 and gears have a whole sale price 
of $250.00.  When our sales associates are selling to our customers on the floor, we have a 
standard 15% markup on our wholesale price for our sales price.  However, if the customer 
purchases more than 10 of either item or a combined quantity of 16 items we only markup the 
items by 12.5%.  On top of this, the sales tax for all sales is 8.9%.
Create a console application that will prompt the sales associate for the number of 
cogs, the number of gears  as well as their Customer ID for a sales order.  Once the user has 
input all of the data needed, create a new instance of the Receipt (or a new Receipt object), call 
the PrintReceipt method on the object and then store it in some sort of collection.  Then you 
should ask if there is another order that needs to be placed and repeat the process of order entry.
After all orders are entered, give the user options to either print all receipts based off of a 
CustomerID, print all receipts for the day, or print the receipt for the sale that had the highest 
total.  Keep prompting the user to see if they would like to perform another function until they 
indicate that they do not.
 *
 */

using System;
using System.Collections.Generic;

namespace TaskThree
{

    class Receipt
    {
        
        public int CustomerID;
        public int CogQuantity;
        public int GearQuantity;
        public DateTime SaleDate;

        private double SalesTaxPercent = .089;
        private double CogPrice = 79.99;
        private double GearPrice = 250;

        // null constructor
        public Receipt()
        {

        }

        // main constructor
        public Receipt(int customerID, int numCogs, int numGears)
        {
            CustomerID = customerID;
            CogQuantity = numCogs;
            GearQuantity = numGears;
            SaleDate = DateTime.Now;

        }

        /*
        The CalculateTotal method will tabulate the final total for the sale.  To do this, 
        you will need to call the CalculateNetAmount method and the CalculateTaxAmount method to 
        get the net amount and the tax amount.  You will then add the tax amount from the net amount 
        and return that value.
         */
        public double CalculateTotal()
        {
            double totalAmount = 0;
            totalAmount = CalculateNetAmount() + CalculateTaxAmount();

            return totalAmount;
        }

        /*
        The PrintReceipt method will write to the console all the details about the sale in 
        an easy to read format.  Not all on just one line, must include what the value represents (e.g. not 
        just 5 but # of Cogs : 5).  Format all values appropriately. 
         */
        public void PrintReceipt()
        {

            Console.WriteLine("Customer ID: " + CustomerID);
            Console.WriteLine("Cogs Quantity: " + CogQuantity);
            Console.WriteLine("Gears Quantity: " + GearQuantity);
            Console.WriteLine("Sale Date: " + SaleDate);
            Console.WriteLine("Sales Tax Percent: " + SalesTaxPercent);
            Console.WriteLine("Cogs Price" + CogPrice);
            Console.WriteLine("Gears Price : " + GearPrice);
        }

        /*
         The CalculateTaxAmount method will tabulate the total tax for the 
         sale.  To do this, you will need to call the CalculateNetAmount and then multiple by your class 
         (instance) variable, SalesTaxPercent.  You will then return the total tax for the sale (Note: this 
         should be a positive value).
         */
        private double CalculateTaxAmount()
        {
            double taxAmount = 0; 
            taxAmount = CalculateNetAmount() * SalesTaxPercent; 

            return taxAmount;
        }


        /*
         The CalculateNetAmount method will tabulate the net price of the 
        sale.  You will need to figure out what markup percent we need to add to our base unit prices for 
        the Cog and Gears based upon the number purchased.  Once you do this, the formula for to 
        calculate the netAmount is:
        netAmount = CogQuantity * Cog Price with markup + GearQuantity * Gear Price with 
        markup
        You will then return the net amount for the sale from the method.
         */
        private double CalculateNetAmount()
        {
            double netAmount = 0;

            //12.5%. If quantity is > 10 or if the sum of q is = 16 
            if (CogQuantity > 10 || GearQuantity > 10 || (CogQuantity + GearQuantity) == 16)
            {
                netAmount = CogQuantity * CogPrice * (CogPrice * .125) + GearQuantity * GearPrice * (GearPrice * .125);
            }
            // 15%
            else
            {
                netAmount = CogQuantity * CogPrice * (CogPrice * .15) + GearQuantity * GearPrice * (GearPrice * .15);
            }
            return netAmount;
        }
    }

    class program
    {

        public static void Main()
        {
            // constructor
            List<Receipt> receiptList = new List<Receipt>();

            // ask user for # cogs
            Console.WriteLine("Enter the amount of cogs you want to buy");
            int numCogs = Convert.ToInt32(Console.ReadLine());

            // ask user for # gears
            Console.WriteLine("Enter the amount of gears you want to buy");
            int numGears = Convert.ToInt32(Console.ReadLine());

            // ask user for id 
            Console.WriteLine("Enter your Customer ID for this sale order");
            int customerID = Convert.ToInt32(Console.ReadLine());

            Receipt receiptOne = new Receipt(customerID, numCogs, numGears);
            receiptList.Add(receiptOne);
           

            Console.WriteLine(receiptOne);
        }
    }
}

