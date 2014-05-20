using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models.DTOs;

namespace FlooringProgram.Models.Interfaces
{
    /// <summary>
    /// Create a Product repository that must inherit GetAllProducts()
    /// </summary>
    public interface  IProductRepository
    {
        List<Product> GetAllProducts();
    }
}
