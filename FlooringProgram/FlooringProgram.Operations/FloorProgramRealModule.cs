using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringPogram.Data.Loaders;
using FlooringProgram.Models.Interfaces;
using Ninject.Modules;


namespace FlooringProgram.Operations
{
    /// <summary>
    /// Create a module that loads real data 
    /// </summary>
    public class FloorProgramRealModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITaxRateRepository>().To<TaxLoader>();
            Bind<IProductRepository>().To<ProductLoader>();
            Bind<IOrderRepository>().To<OrderRepository>();
        }
    }
}
