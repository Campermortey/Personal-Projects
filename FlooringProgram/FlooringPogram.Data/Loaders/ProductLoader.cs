using System.Collections.Generic;
using System.IO;
using FlooringProgram.Models.DTOs;
using FlooringProgram.Models.Interfaces;

namespace FlooringPogram.Data.Loaders
{
    public class ProductLoader : IProductRepository
    {
        /// <summary>
        /// Loads the Product text file from save to memory
        /// </summary>
        /// <returns>List of Product</returns>
        public List<Product> GetAllProducts()
        {
            string fileName = @"Data\Products.txt";

            //if it exists, create a List of Product converted from CSV to products
            if (File.Exists(fileName))
            {
                string[] productsAsStrings = File.ReadAllLines(fileName);
                List<Product> output = ConvertCSVToProducts(productsAsStrings);

                return output;
            }

            return new List<Product>();
        }

        private List<Product> ConvertCSVToProducts(string[] productsAsStrings)
        {
            //create a new Orders List
            List<Product> output = new List<Product>();

            for (int i = 1; i < productsAsStrings.Length; i++)
            {
                if (!string.IsNullOrEmpty(productsAsStrings[i]))
                {
                    //set up a new array that splits the row based on ","
                    string[] newRow = productsAsStrings[i].Split(',');

                    Product prod = new Product();

                    prod.ProductType = newRow[0];
                    prod.CostPerSquareFoot = decimal.Parse(newRow[1]);
                    prod.LaborCostPerSquareFoot = decimal.Parse(newRow[2]);

                    output.Add(prod);

                }
            }
            return output;
        }
        }
 }

