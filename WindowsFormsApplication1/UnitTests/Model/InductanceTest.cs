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
    class InductanceTest
    {
        /// <summary>
        /// Тестирование присваивания значения катушке индуктивности.
        /// </summary>
        /// <param name="inductance"></param>
        [Test]
        [TestCase(2, TestName = "Тестирование Inductance при присваивание 5.")]
        [TestCase(44, TestName = "Тестирование Inductance при присваивание 44.")]
        [TestCase(9000, TestName = "Тестирование Inductance при присваивание 9000.")]
        [TestCase(11111, TestName = "Тестирование Inductance при присваивание 11111.")]
        [TestCase(int.MaxValue, TestName = "Тестирование Inductance при присваивание int.MaxValue.")]

        public void Inductance_Test(int inductance)
        {
            var induct = new Induct();
            induct.Inductance = inductance;
        }
        /// <summary>
        /// Тестирование присваивания значения катушки индуктивности некорректное значение.
        /// </summary>
        /// <param name="inductance"></param>
        [Test]
        [TestCase(0, TestName = "Тестирование Inductance при присваивание 0.")]
        [TestCase(-70, TestName = "Тестирование Inductance при присваивание -70.")]
        [TestCase(-200, TestName = "Тестирование Inductance при присваивание -200.")]
        [TestCase(-99999, TestName = "Тестирование Inductance при присваивание -99999.")]
        [TestCase(int.MinValue, TestName = "Тестирование Inductance при присваивание int.MinValue.")]

        public void Inductance_Negativetest(int inductance)
        {
            var induct = new Induct();
            Assert.Throws(typeof(ArgumentException), () => { induct.Inductance = inductance; });
        }

    }
}
