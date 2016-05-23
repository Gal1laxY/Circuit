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
    /// Конденсатор.
    /// </summary>
    public class Capacitor : ICircuit
    {
        public string Name
        {
            get
            {
                return "Конденсатор";
            }
        }
        /// <summary>
        /// Номинал конденсатора.
        /// </summary>
        private int _capacitance;
        /// <summary>
        /// Свойство электроемкости.
        /// </summary>
        public int Capacitance
        {
            get
            {
                return _capacitance;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Введено неккоректное значение!");
                _capacitance = value;
            }
        }
        /// <summary>
        /// Метод рассчета комплексного споротивления элемента.
        /// </summary>
        /// <param name="w"> Номинал частоты.</param>
        /// <returns> Возвращает значение конденсатора.</returns>
        public Complex CalculateValue(double w)
        {
            return new Complex(0, 1 / w/2/Math.PI / Capacitance);
        }
    }
}
