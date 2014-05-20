using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;
using FlooringProgram.Operations;


namespace FlooringProgram.UI.WorkFlows
{
    public class EditOrder
    {
        //establish our managers
        private ProductManager _myProductManager;
        private TaxRateManager _myTaxManager;
        private OrderManager _myOrderManager;

        //the list that we will use to work with data loaded into memory
        List<Order> allOrders = new List<Order>();
        private string orderDate;
        private int orderNumber;

        //the order that we are creating to save our data
        Order newOrder = new Order();

        //the constructor that is used to pull in which repository we are going to work with
        public EditOrder(OrderManager oManager, ProductManager pManager, TaxRateManager tManager)
        {
            _myProductManager = pManager;
            _myTaxManager = tManager;
            _myOrderManager = oManager;
        }

        //Method we use to trigger from Main Menu
        public void Execute()
        {
            DisplayHeader();

            //the orderdate is equal to whatever date is returned from this method
            orderDate = GetOrderDate();

            //the list is storing the list returned from LoadOrders
            allOrders = _myOrderManager.LoadOrders(orderDate);

            //Display the orders with the list passed in
            DisplayOrders(allOrders);

            //The orderNumber is equal to whatever number they are prompted for
            orderNumber = GetOrderNumber();

            //store the new order
            newOrder = SelectandReviseOrder();

            //calculate the fields that need to be generated
            _myOrderManager.Calculator(newOrder);

            //save the order to the file
            _myOrderManager.SaveEditedOrder(allOrders, newOrder, orderNumber, orderDate);

        }


        private string GetOrderDate()
        {
            string userInput;
            do
            {
                //Ask the user to enter an order date
                Console.Write("What date do you want to search by 00(month)00(day)0000(year) ");
                userInput = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(userInput));

            return userInput;
        }

        /// <summary>
        /// Display the header
        /// </summary>
        private void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - -");
        }


        public void DisplayOrders(List<Order> allOrders)
        {
            //display all the orders in the file
            Console.WriteLine("\nOrder#    Name   State   Tax Rate   P.Type Area      Tax    Total ");
            foreach (var x in allOrders)
            {
                Console.WriteLine("{0,4} {1,10} {2,3} {3}% {4,7} {5,8} {6,09:C} {7,08:C}", x.OrderNumber, x.CustomerName, x.State, x.TaxRate, x.ProductType, x.Area, x.Tax, x.Total);
            }
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

        public Order SelectandReviseOrder()//need to return an order object
        {
            var order = allOrders.Where(o => o.OrderNumber == orderNumber).First();

            Console.Clear();
            string newValue;
            decimal newValue2;
            
            Console.WriteLine("To edit, enter a new value, otherwise leave blank");

            //ask the user for the customerName they want to enter. Stores it in newValue
            Console.Write("Customer Name ({0}): ", order.CustomerName);
            newValue = Console.ReadLine();

            //if it is not empty, store the new value to the order. If not, the old one is kept unchanged
            if (!string.IsNullOrEmpty(newValue))
            {
                order.CustomerName = newValue;
            }

            //ask the user for the state. Stores it in newValue
            Console.Write("State ({0}): ", order.State);
            newValue = Console.ReadLine();

            //if it is not empty, store the new value to the order. If not, the old one is kept unchanged
            if (!string.IsNullOrEmpty(newValue))
            {
                //the state is saved to the order
                order.State = newValue;
                var taxRate = _myTaxManager.GetTaxRateFor(newValue);//call the tax manager

                //set the taxrate equal to the tax perfecent
                order.TaxRate = taxRate.TaxPercent;
            }

            //ask the user for the Product Type they want to enter. Stores it in newValue
            Console.Write("Product Type ({0}): ", order.ProductType);
            newValue = Console.ReadLine();

            //if it is not empty, store the new value to the order. If not, the old one is kept unchanged
            if (!string.IsNullOrEmpty(newValue))
            {
                //set the ProductType to whatever they enter
                order.ProductType = newValue;

                //return the list of all the products and store it in "allProducts"
                var allProducts = _myProductManager.GetAllProducts();

                //store the result of where the Lambda expression finds where the product type is equal to what they type in
                var product = allProducts.FirstOrDefault(x => x.ProductType == newValue);

                //store the matching costs in the order
                order.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
                order.CostPerSquareFoot = product.CostPerSquareFoot;
            }

            //ask the user for the Area they want to enter. Stores it in newValue
            Console.Write("Area ({0}): ", order.Area);

            //convert it to a decimal
            newValue2 = decimal.Parse(Console.ReadLine());

            if (newValue2 != null)
            {
                //store it in the order
                order.Area = newValue2;
            }

            Console.ReadLine();

            //return the order created
            return order;

        }

    }
}

