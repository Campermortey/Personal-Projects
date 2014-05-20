using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringPogram.Data.Mocks
{
    public class ProductRepositoryMock : IProductRepository
    {
        /// <summary>
        /// A repository with "test" data
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            //returns a new list of product 
            return new List<Product>()
            {
                //creates new products that can be tested
                new Product() {CostPerSquareFoot = 5.15M, LaborCostPerSquareFoot = 4.75M, ProductType = "Wood"},
                new Product() {CostPerSquareFoot = 6.12M, LaborCostPerSquareFoot = 5.00M, ProductType = "Laminate"},
                new Product() {CostPerSquareFoot = 2.14M, LaborCostPerSquareFoot = 6.12M, ProductType = "Tile"}
            };
        }
    }
}
