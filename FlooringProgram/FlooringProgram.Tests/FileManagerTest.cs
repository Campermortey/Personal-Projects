using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using NUnit.Framework;

namespace FlooringProgram.Tests
{
    [TestFixture]
    public class FileManagerTest
    {
        [Test]

        public void FileLoadFile()
        {
            OrderRepository manage = new OrderRepository();

            List<Order> actual = manage.LoadOrders("");

            Order orders = new Order();


            orders.CustomerName = "Wise";

            var actualOrder = from x in actual
                              where x.CustomerName == "Wise"
                              select x.CustomerName;

            Assert.AreEqual(actualOrder.First(), orders.CustomerName);
        }

        [Test]

        public void WriteToFile()
        {
            OrderRepository manage = new OrderRepository();
            List<Order> saveInput = new List<Order>();
            Order testOrders = new Order();

            testOrders.OrderNumber = 2;
            testOrders.CustomerName = "David";
            testOrders.State = "OH";
            testOrders.TaxRate = 6.25M;
            testOrders.ProductType = "Wood";
            testOrders.Area = 100.00M;
            testOrders.CostPerSquareFoot = 5.15M;
            testOrders.LaborCostPerSquareFoot = 4.75M;
            testOrders.MaterialCost = 515.00M;
            testOrders.LaborCost = 475.00M;
            testOrders.Tax = 61.88M;
            testOrders.Total = 1051.88M;


            saveInput.Add(testOrders);

            manage.SaveFile(saveInput, "");



        }
    }
}
