using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data.Mocks;
using FlooringProgram.Models.Interfaces;
using Ninject.Modules;

namespace FlooringProgram.Operations
{
    public class FlooringProgramTestModule : NinjectModule
    {
        /// <summary>
        /// Create a module that loads fake data
        /// </summary>
        public override void Load()
        {
            Bind<ITaxRateRepository>().To<TaxRateRepositoryMock>();
            Bind<IProductRepository>().To<ProductRepositoryMock>();
            Bind<IOrderRepository>().To<TestOrderRepository>();
        }
    }
}
