using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SalaryCalculator;

namespace SalaryCalculator.Tests
{
    [TestClass]
    public class SalaryCalculatorServiceTests
    {
        private readonly SalaryCalculatorService _service = new SalaryCalculatorService();

        [TestMethod]
        public void TS01_Assistant_10h_TaxOn()
        {
            var result = _service.CalculateSalary(10, "ассистент", true);
            Assert.AreEqual(1500, result.Gross, 0.01);
            Assert.AreEqual(195, result.Tax, 0.01);
        }

        [TestMethod]
        public void TS02_Docent_20h_TaxOff()
        {
            var result = _service.CalculateSalary(20, "доцент", false);
            Assert.AreEqual(5000, result.Gross, 0.01);
            Assert.AreEqual(0, result.Tax, 0.01);
        }

        [TestMethod]
        public void TS03_Professor_5h_TaxOn()
        {
            var result = _service.CalculateSalary(5, "профессор", true);
            Assert.AreEqual(1750, result.Gross, 0.01);
            Assert.AreEqual(227.5, result.Tax, 0.01);
        }

        [TestMethod]
        public void TS04_ZeroHours()
        {
            var result = _service.CalculateSalary(0, "ассистент", true);
            Assert.AreEqual(0, result.Gross, 0.01);
            Assert.AreEqual(0, result.Tax, 0.01);
        }

        [TestMethod]
        public void TS05_Fractional_10_5h()
        {
            var result = _service.CalculateSalary(10.5, "доцент", true);
            Assert.AreEqual(2625, result.Gross, 0.01);
            Assert.AreEqual(341.25, result.Tax, 0.01);
        }

        [TestMethod]
        public void TS09_Assistant_1h_TaxOff()
        {
            var result = _service.CalculateSalary(1, "ассистент", false);
            Assert.AreEqual(150, result.Gross, 0.01);
            Assert.AreEqual(0, result.Tax, 0.01);
        }

        [TestMethod]
        public void TS10_Professor_8h_TaxOn()
        {
            var result = _service.CalculateSalary(8, "профессор", true);
            Assert.AreEqual(2800, result.Gross, 0.01);
            Assert.AreEqual(364, result.Tax, 0.01);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidPosition_Throws()
        {
            _service.CalculateSalary(10, "invalid", true);
        }

        [TestMethod]
        public void NegativeHours_AllowedInService()
        {
            var result = _service.CalculateSalary(-5, "ассистент", true);
            Assert.AreEqual(-750, result.Gross, 0.01);
            Assert.AreEqual(-97.5, result.Tax, 0.01);
        }
    }
}