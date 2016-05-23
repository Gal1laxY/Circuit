using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Model;

namespace Model
{
    /// <summary>
    /// Резистор.
    /// </summary>
    public class Resistor : ICircuit
    {
        public string Name
        {
            get
            {
                return "Резистор";
            }
        }
        /// <summary>
        /// Номинал резистора.
        /// </summary>
        private int _resistance;
        /// <summary>
        /// Свойсства сопротивления.
        /// </summary>
        public int Resistance
        {
            get
            {
                return _resistance;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Введено неккоректное значение!");
                _resistance = value;
            }
        }
         /// <summary>
        /// Метод рассчета комплексного споротивления элемента.
         /// </summary>
        /// <param name="w">Номинал частоты.</param>
         /// <returns>Возвращает значение резисстора.</returns>
   
        public Complex CalculateValue(double w)
        {
            return Resistance;
        }
    }
}
