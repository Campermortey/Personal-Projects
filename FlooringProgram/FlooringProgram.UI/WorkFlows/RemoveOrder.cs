using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;

namespace FlooringProgram.UI.WorkFlows
{
    public class RemoveOrder
    {
        private OrderManager _myOrderManager;
        
        List<Order> allOrders = new List<Order>();
        private string orderDate;
        private int orderNumber;
        private IOrderRepository _repository;
        
        

        public RemoveOrder(OrderManager manager)
        {
            _myOrderManager = manager;

        }

        public void Execute()
        {
            DisplayHeader();

            //set the order date equal to the orderdate method
            orderDate = GetOrderDate();

            //stores the loaded list in allOrders so it stays in memory. Don't want to lose pointer
            allOrders = _myOrderManager.LoadOrders(orderDate);

            //display orders
            DisplayOrders();

            //set the order number to the getordernumber method
            orderNumber = GetOrderNumber();

            //remove the selected order
            RemoveSelectedOrder(allOrders, orderNumber);
        }




        private void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");
        }

        private void DisplayOrders()
        {
            Console.WriteLine("\nOrder#    Name   State   Tax Rate   P.Type Area      Tax    Total ");
            foreach (var x in allOrders)
            {
                Console.WriteLine("{0,4} {1,10} {2,3} {3}% {4,7} {5,8} {6,09:C} {7,08:C}", x.OrderNumber, x.CustomerName, x.State, x.TaxRate, x.ProductType, x.Area, x.Tax, x.Total);
            }
        }

        private string GetOrderDate()
        {
            string userInput;
            do
            {
                //Ask the user to enter an order date
                Console.Write("Please enter the date of the order to remove 00(month)00(day)0000(year) ");
                userInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        private int GetOrderNumber()
        {
            int userInput;
            do
            {
                Console.Write("What is the Order Number? ");
                userInput = int.Parse(Console.ReadLine());
            } while (userInput == null);
            //ask the user what the order number they want to search by

            return userInput;
        }

        //Removes the order
        private void RemoveSelectedOrder(List<Order> allOrders, int orderNumber)
        {
            //stores in order where the first order number is equal to the order number they type in
            var order = allOrders.Where(o => o.OrderNumber == orderNumber).First();

            //in the list remove order entered
            allOrders.Remove(order);

            //use the ordermanager to save the order
            _myOrderManager.SaveRemovedOrder(allOrders, orderDate);
        }
    }
}
