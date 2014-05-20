using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringPogram.Data.Loaders
{
    /// <summary>
    /// Order repository that deals with loading from file, saving to file, and adding Orders
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        
        
        private const string HeaderRow =
            "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";

        /// <summary>
        /// Loads orders from the text file to memory
        /// </summary>
        /// <param name="userDate"></param>
        /// <returns>A list of Order</returns>
        public List<Order> LoadOrders(string userDate)
        {
            //the search file is equal to the method CreateFileName which aks the user for the Date to enter
            string searchFile = CreateFileName(userDate);

            //if the file exists, read all lines, convert CSV to Order List then return the list
            if (File.Exists(searchFile))
            {
                string[] ordersAsStrings = File.ReadAllLines(searchFile);
                List<Order> output = ConvertCSVToOrder(ordersAsStrings);

                return output;
            }

            //returns a new list of Order
            return new List<Order>();
        }

        private List<Order> ConvertCSVToOrder(string[] ordersAsStrings)
        {
            //create a new Order List
            List<Order> output = new List<Order>();

            //starting at position 1 (header is 0), loop through the List
            for (int i = 1; i < ordersAsStrings.Length; i++)
            {
                if (!string.IsNullOrEmpty(ordersAsStrings[i]))
                {
                    //set up a new array that splits the row based on ","
                    string[] newRow = ordersAsStrings[i].Split(',');

                    //set position to new row
                    Order order = new Order();

                    //set the order fields equal to what is stored in the array position
                    //converts if needed the type 

                    order.OrderNumber = int.Parse(newRow[0]);
                    order.CustomerName = newRow[1];
                    order.State = newRow[2];
                    order.TaxRate = Convert.ToDecimal(newRow[3]);
                    order.ProductType = newRow[4];
                    order.Area = Convert.ToDecimal(newRow[5]);
                    order.CostPerSquareFoot = Convert.ToDecimal(newRow[6]);
                    order.LaborCostPerSquareFoot = Convert.ToDecimal(newRow[7]);
                    order.MaterialCost = Convert.ToDecimal(newRow[8]);
                    order.LaborCost = Convert.ToDecimal(newRow[9]);
                    order.Tax = Convert.ToDecimal(newRow[10]);
                    order.Total = Convert.ToDecimal(newRow[11]);

                    //save the order to output
                    output.Add(order);

                }
            }

            return output;
        }

        /// <summary>
        /// Saves the file to a .txt
        /// </summary>
        /// <param name="orderList">Passes in a List of Order</param>
        /// <param name="userDate">Passes in the UserDate</param>
        public void SaveFile(List<Order> orderList, string userDate)
        {
            string fileName = CreateFileName(userDate);

            var output = new List<string>();

            //adds the Header Row at the top
            output.Add(HeaderRow);
            
            //loops through the orderlist and adds each order to the list
            foreach (var order in orderList)
            {
                output.Add(ConvertOrderToCSV(order));
                
            }

            //writes everything to the FileDirectory
            File.WriteAllLines(fileName, output);
            
            Console.WriteLine("This is the directory it was written to: ");
            Console.WriteLine(System.Environment.CurrentDirectory);
        }

        private string ConvertOrderToCSV(Order order)
        {
            
            //converting to a string to the proper format by putting a "," after each field
            return order.OrderNumber + "," + order.CustomerName + "," + order.State + ","
                                + order.TaxRate + "," + order.ProductType + "," + order.Area + "," +
                                order.CostPerSquareFoot
                                + "," + order.LaborCostPerSquareFoot + "," + order.MaterialCost + "," +
                                order.LaborCost
                                + "," + order.Tax + "," + order.Total;
        }

        public void AddOrderToFile(Order order, string userDate)
        {
            //gets the filename
            string fileName = CreateFileName(userDate);
            string rowData;

            //if the file exists, append the Order to the file
            if (File.Exists(fileName))
            {
                rowData = ConvertOrderToCSV(order);
                var writer = File.AppendText(fileName);
                writer.WriteLine(rowData);
                writer.Close();  //close the file
            }
            else
            {
                rowData = ConvertOrderToCSV(order);
                var writer = File.AppendText(fileName);
                writer.WriteLine(HeaderRow);  //if it doesn't exist, you need to add the header row
                writer.WriteLine(rowData);
                writer.Close();
            }
        }

        /// <summary>
        /// Creates a file name based on what they enter
        /// </summary>
        /// <param name="userDate"></param>
        /// <returns>The FileName</returns>
        private string CreateFileName(string userDate)
        {
            return @"Data\Orders" + "_" + userDate + ".txt";
        }
    }
}
