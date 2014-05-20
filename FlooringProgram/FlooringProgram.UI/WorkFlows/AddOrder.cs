using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;
using Microsoft.Win32;

namespace FlooringProgram.UI.WorkFlows
{
    public class AddOrder
    {
        //set up the managers and give them a name
        private ProductManager _myProductManager;
        private TaxRateManager _myTaxManager;
        private OrderManager _myOrderManager;
        private string orderDate;

        //a constructor which sets the managers equal to the factory and what it does
        public AddOrder(ProductManager pManager, TaxRateManager tManager, OrderManager oManager)
        {
            _myProductManager = pManager;

            _myTaxManager = tManager;

            _myOrderManager = oManager;
        }
       
        //Execute method which runs in the menu
        public void Execute()
        {
            GetUserOrderInfo();
            
            
        }

        /// <summary>
        /// Gets the user Order info
        /// </summary>
        public void GetUserOrderInfo()
        {
            Order newOrder = new Order();

            // 1. Ask user for customer name
            newOrder.CustomerName = GetCustomerName();

            // 2. Ask user for product type
            var chosenProduct = GetProduct();
            newOrder.ProductType = chosenProduct.ProductType;

            // 3. Ask user for area of flooring
            newOrder.Area = GetArea();

            // 3. Ask user for state for taxes

            var chosenTaxRate = GetState();
            newOrder.State = chosenTaxRate.State;
            newOrder.TaxRate = chosenTaxRate.TaxPercent/100;


            //Get user date

            orderDate = GetOrderDate();


            // 5. Ask Order Manager to calculate and save (pass order, product, and tax rate to order manager)
            _myOrderManager.AddOrder(newOrder, chosenProduct, chosenTaxRate, orderDate);

            DisplayData(newOrder);
        }

        private string GetOrderDate()//string not object
        {
            string orderDate;
            
            //Gets the userdate, returns it, while the date entered is not null or blank
            do
            {
                Console.Write("Enter the order date in this format: 00(Date)00(Month)0000(Year) ");
                orderDate = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(orderDate));

            return orderDate;
        }

        public TaxRate GetState()
        {
            //call the TaxRate object "chosenTaxRate"
            TaxRate chosenTaxRate;

            //set the variable "allRates" equal to the taxmanager where it gets all the rates
            var allRates = _myTaxManager.GetAllTaxRates();
            string choice;
            
            do
            {
                //Prints out a list of states in the TaxRate document
                Console.WriteLine("Available States");
                Console.WriteLine("------------------");
                foreach (var p in allRates)
                    Console.WriteLine(p.State);

                Console.Write("\nEnter State: ");
                choice = Console.ReadLine();

                //the tax rate is equal to the state that they type in
                chosenTaxRate = allRates.FirstOrDefault(r => r.State == choice);
                
            } while (chosenTaxRate== null);

            //return the tax rate out of the method
            return chosenTaxRate;
        }

        public decimal GetArea()
        {
            //set up a variable to = false
            bool valid = false;

            //set up the userArea to be a decimal
            decimal userArea = 0;
            do
            {
                //Ask the user to enter the area as long as they enter a decimal
                Console.Write("Enter the Area: ");
                valid = decimal.TryParse(Console.ReadLine(), out userArea);

            } while (!valid);

            //return the area out of the method
            return userArea;
        }

        public Product GetProduct()
        {
            //set the Product object to be called "chosenProduct"
            Product chosenProduct;

            //the list of Products available are stored here
            var allProducts = _myProductManager.GetAllProducts();

            //Do the loop while they don't enter a valid ProductType
            do
            {
                //prints out a list of Products available 
                Console.WriteLine("Available Products");
                Console.WriteLine("------------------");
                foreach(var p in allProducts)
                    Console.WriteLine(p.ProductType);

                Console.Write("\nEnter product type: ");
                string choice = Console.ReadLine();

                //set the chosenProduct to equal the first Productype where it is equal to what they type in
                chosenProduct = allProducts.FirstOrDefault(p => p.ProductType == choice);
            } while (chosenProduct == null);

            return chosenProduct;
        }

        public string GetCustomerName()
        {
            string name;

            //get the customer name while what they enter is not null or a white space
            do
            {
                Console.Write("Enter the customer name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            return name;
        }

        public void DisplayData(Order newOrder)
        {
            //pass in the created order and display it to the user
            Console.WriteLine("Name: {0}", newOrder.CustomerName);
            Console.WriteLine("State: {0}", newOrder.State);
            Console.WriteLine("Tax Rate: {0:P}", newOrder.TaxRate);
            Console.WriteLine("Product Type: {0}", newOrder.ProductType);
            Console.WriteLine("Area: {0}", newOrder.Area);
            Console.WriteLine("Cost per square ft: {0:C}", newOrder.CostPerSquareFoot);
            Console.WriteLine("Labor cost per square ft: {0:C}", newOrder.LaborCostPerSquareFoot);
            Console.WriteLine("Material cost: {0:C}", newOrder.MaterialCost);
            Console.WriteLine("Labor cost: {0:C}", newOrder.LaborCost);
            Console.WriteLine("Tax: {0:C}", newOrder.Tax);
            Console.WriteLine("TOTAL COST: {0:C}", newOrder.Total);
            Console.WriteLine();

            //Get confirmation from the user that they want to save the file
            string result = GetConfirmation();

            //if they do want to save teh file, then reference the order manager and add the order to the file
            if (result == "Y")
                _myOrderManager.AddNewOrder(newOrder, orderDate);
            

        }

        private string GetConfirmation()
        {
            string userConfirmation;
           
            //get confirmation from the user until they enter "Y" or "N"
            do
            {
                Console.Write("Would you like to save this order? (Y/N) ");
                userConfirmation = Console.ReadLine();
                if (userConfirmation == "N")

                    break;
               
            } while (userConfirmation != "Y");

            //return their answer out of the main method
            return userConfirmation;

        }

    }
}
