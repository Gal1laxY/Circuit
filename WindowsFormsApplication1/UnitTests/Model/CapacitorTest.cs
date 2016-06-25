using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using NUnit.Framework;

namespace UnitTests.Model
{
    [TestFixture]
    class CapacitorTest
    {
        /// <summary>
        /// Тестирование присваивания значения конденсатору.
        /// </summary>
        /// <param name="capacitance"></param>
        [Test]
        [TestCase(5, TestName = "Тестирование Capacitance при присваивание 5.")]
        [TestCase(88, TestName = "Тестирование Capacitance при присваивание 88.")]
        [TestCase(5000, TestName = "Тестирование Capacitance при присваивание 5000.")]
        [TestCase(99999, TestName = "Тестирование Capacitance при присваивание 99999.")]
        [TestCase(int.MaxValue, TestName = "Тестирование Capacitance при присваивание int.MaxValue.")]

        public void Capacitor_Test(int capacitance)
        {
            var capacitor = new Capacitor();
            capacitor.Capacitance = capacitance;

        }
        /// <summary>
        /// Тестирование присваивания значения конденсатору некорректных значений.
        /// </summary>
        /// <param name="capacitance"></param>
        [Test]
        [TestCase(0, TestName = "Тестирование Capacitance при присваивание 0.")]
        [TestCase(-10, TestName = "Тестирование Capacitance при присваивание -10.")]
        [TestCase(-50, TestName = "Тестирование Capacitance при присваивание -50.")]
        [TestCase(-979, TestName = "Тестирование Capacitance при присваивание -979.")]
        [TestCase(int.MinValue, TestName = "Тестирование Capacitance при присваивание int.MinValue.")]

        public void Capacitor_NegativeTest(int capacitance)
        {
            var capacitor = new Capacitor();
            Assert.Throws(typeof(ArgumentException), () => { capacitor.Capacitance = capacitance; });
        }
    }
}
