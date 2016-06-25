using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Numerics;
using NUnit.Framework;

namespace UnitTests.Model
{
    [TestFixture]
    class ResistorTest
    {
        /// <summary>
        /// Тестирование присваивания значения резистору.
        /// </summary>
        /// <param name="resistance"></param>
        [Test]
        [TestCase(1, TestName = "Тестирование Resistance при присваивание 1.")]
        [TestCase(100, TestName = "Тестирование Resistance при присваивание 100.")]
        [TestCase(1000, TestName = "Тестирование Resistance при присваивание 1000.")]
        [TestCase(9999, TestName = "Тестирование Resistance при присваивание 9999.")]
        [TestCase(int.MaxValue, TestName = "Тестирование Resistance при присваивание int.MaxValue.")]

        public void Resistor_Test(int resistance)
        {
            var resistor = new Resistor();
            resistor.Resistance = resistance;
        }
        /// <summary>
        /// Тестирование присваивания значения резистору некорректных значений.
        /// </summary>
        /// <param name="resistance"></param>

        [Test]
        [TestCase(0, TestName = "Тестирование Resistance при присваивание 0.")]
        [TestCase(-1, TestName = "Тестирование Resistance при присваивание -1.")]
        [TestCase(-10, TestName = "Тестирование Resistance при присваивание -10.")]
        [TestCase(-999, TestName = "Тестирование Resistance при присваивание -999.")]
        [TestCase(int.MinValue, TestName = "Тестирование Resistance при присваивание int.MinValue.")]

        public void Resistor_NegativeTest(int resistance)
        {
            var resistor = new Resistor();
            Assert.Throws(typeof(ArgumentException), () => { resistor.Resistance = resistance; });
        }
        
    }
}
