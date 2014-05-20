using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Operations
{
    public class ProductManager
    {
        private IProductRepository _myProductRepository;

        //passes in the Product repository which specifies which kind of function it is going to provide
        //test or prod mode
        public ProductManager(IProductRepository myProductRepository)
        {
            _myProductRepository = myProductRepository;
        }

        //returns a list of Products
        public List<Product> GetAllProducts()
        {
            return _myProductRepository.GetAllProducts();
        }

        
    }
}
