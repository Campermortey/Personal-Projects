using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Operations
{
    /// <summary>
    /// Order manager decides if it is going to use the fake repository or real one
    /// You reference order manager to use the other functions. 
    /// Order manager decides what is appropriate
    /// </summary>
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository repositoryToUse)
        {
            _orderRepository = repositoryToUse;
        }

        public void AddOrder(Order newOrder, Product chosenProduct, TaxRate taxRateForCustomerState, string orderDate)
        {
           
            //Calculates the fields necessary to store in the Order
            newOrder.CostPerSquareFoot = chosenProduct.CostPerSquareFoot;
            newOrder.MaterialCost = newOrder.CostPerSquareFoot*newOrder.Area;
            newOrder.LaborCost = newOrder.Area * chosenProduct.LaborCostPerSquareFoot;
            newOrder.Tax = (newOrder.LaborCost + newOrder.MaterialCost) * taxRateForCustomerState.TaxPercent;
            newOrder.Total = newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax;
            newOrder.LaborCostPerSquareFoot = chosenProduct.LaborCostPerSquareFoot;
            
        }

        public void Calculator(Order newOrder)
        {
            //second newOrder Edit Functions
            //just passes in Order and calculates the rest. 
            //Needs to have the specific Tax percent and relevant costs correct previously


            newOrder.MaterialCost = newOrder.CostPerSquareFoot * newOrder.Area;
            newOrder.LaborCost = newOrder.Area * newOrder.LaborCostPerSquareFoot;
            newOrder.Tax = (newOrder.LaborCost + newOrder.MaterialCost) * newOrder.TaxRate;
            newOrder.Total = newOrder.LaborCost + newOrder.MaterialCost + newOrder.Tax;


        }

        //adds the order to the orderRepository
        public void AddNewOrder(Order order, string orderDate)
        {
            var allOrders = _orderRepository.LoadOrders(orderDate);
            order.OrderNumber = GetNextOrderNumber(allOrders);
            allOrders.Add(order);
            _orderRepository.AddOrderToFile(order, orderDate);
        }

        //gets the next order number
        private int GetNextOrderNumber(List<Order> allOrders)
        {
            if (allOrders.Any())
                return allOrders.Max(x => x.OrderNumber) + 1;

            return 1;
        }

        //returns the loadorders from the Order Repository (real data)
        public List<Order> LoadOrders(string orderDate)
        {
            return _orderRepository.LoadOrders(orderDate);
        }

        //Saves edited order
        public void SaveEditedOrder(List<Order> allOrders, Order order, int orderNumber, string orderDate)
        {

            order.OrderNumber = orderNumber;

            //creating a new Order object called update where order number is equal to the order number the user entered
            Order Update = allOrders.FirstOrDefault(x => x.OrderNumber == orderNumber);

            //in the new Order object you set the values equal to the order info passed in
            Update.CustomerName = order.CustomerName;
            Update.ProductType = order.ProductType;
            Update.Area = order.Area;
            Update.State = order.State;

            //use the order repository to save the file
            _orderRepository.SaveFile(allOrders, orderDate);
        }

        public void SaveRemovedOrder(List<Order> allOrders, string orderDate)
        {
            _orderRepository.SaveFile(allOrders, orderDate);
        }
    }
}
