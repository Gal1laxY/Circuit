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
/// Индуктивность
/// </summary>
    public class Induct : ICircuit
    {
        public string Name
        {
            get
            {
                return "Катушка индуктивности";
            }
        }
        /// <summary>
        /// Номинал индуктивности.
        /// </summary>
        private int _inductance;
        /// <summary>
        /// Свойство индуктивности.
        /// </summary>
        public int Inductance
        {
            get
            {
                return _inductance;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Введено неккоректное значение!");
                _inductance = value;
            }
        }
        /// <summary>
        /// Метод рассчета комплексного споротивления элемента.
        /// </summary>
        /// <param name="w"> Номинал частоты.</param>
        /// <returns>Возращает значение индуктора.</returns>
        public Complex CalculateValue(double w)
        {
            return new Complex(0, 2*Math.PI*w * Inductance);
        }
    }
}