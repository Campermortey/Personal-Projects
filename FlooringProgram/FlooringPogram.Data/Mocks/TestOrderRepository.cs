using System.Collections.Generic;
using FlooringProgram.Models;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringPogram.Data.Mocks
{
    public class TestOrderRepository : IOrderRepository
    {
        public List<Order> LoadOrders(string userDate)
        {
            //Create a new test list of Order to test with
            return new List<Order>()
            {
                new Order {Area=100M, CostPerSquareFoot = 5M, CustomerName="ABC Corp", LaborCost=2M, 
                    LaborCostPerSquareFoot = 200M, MaterialCost = 500M, OrderNumber = 1, ProductType = "Wood",
                    State="OH", TaxRate=.1M, Tax=70M, Total=770M}
            };
        }

        //it doesn't do this because in Test mode we don't want to save
        public void SaveFile(List<Order> orderList, string userDate)
        {
            
        }

        public void AddOrderToFile(Order order, string userDate)
        {
        
        }
    }
}
