using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLabs.Models.Interfaces
{
    public interface IUnitConverter
    {
        decimal Convert(decimal fromValue);
    }
}
