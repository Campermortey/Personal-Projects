using System.Collections.Generic;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Models.Interfaces
{
    /// <summary>
    /// Create an interface with the following methods that must be inherited when called
    /// </summary>
    public interface IOrderRepository
    {
        List<Order> LoadOrders(string userDate);
        void SaveFile(List<Order> orderList, string userDate);
        void AddOrderToFile(Order order, string userDate);

        
    }
}
