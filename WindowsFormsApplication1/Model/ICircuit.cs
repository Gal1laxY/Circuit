using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Model
{
    
        
    public interface ICircuit
    {
        Complex CalculateValue(double w);
        string Name { get; } //public
    }
}
