using System;
using System.Collections.Generic;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;


namespace FlooringProgram.UI.WorkFlows
{
    public class DisplayOrder
    {
        private OrderManager _myOrderManager;

        //pass in what type of repository this is going to use
        public DisplayOrder(OrderManager manager)
        {
            _myOrderManager = manager;
        }

        //The main method that is going to run in the menu
        public void Execute()
        {
            DisplayOrders();
        }

        private void DisplayOrders()
        {
            Console.Clear();

            //orders is a list that is being returned from the SearchOrders()
            var orders = SearchOrders();

            //write each field to the console
            Console.WriteLine("\nOrder#    Name   State   Tax Rate   P.Type Area      Tax    Total ");
            foreach (var x in orders)
            {
                

                Console.WriteLine("{0,4} {1,10} {2,3} {3,12:P} {4,7} {5,8} {6,09:C} {7,08:C}", x.OrderNumber, x.CustomerName, x.State, x.TaxRate, x.ProductType, x.Area, x.Tax, x.Total);
            }
        }

        //return a list of Order
        public List<Order> SearchOrders()
        {
            Console.Write("Enter order date in the format of 00(month)00(day)0000(year): ");
            string userDate = Console.ReadLine();

            //return a loaded list of orders
            return _myOrderManager.LoadOrders(userDate);           
        }

        
    }
}
