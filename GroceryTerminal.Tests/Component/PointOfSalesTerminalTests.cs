using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace GroceryTerminal.Tests.Component
{
    public class PointOfSalesTerminalTests
    {
        private PointOfSalesTerminal _terminal;

        [SetUp]
        public void Setup()
        {
            _terminal = new PointOfSalesTerminal();

            _terminal.AddProduct("A", 1.25M, 3, 3M);
            _terminal.AddProduct("B", 4.25M);
            _terminal.AddProduct("C", 1M, 6, 5M);
            _terminal.AddProduct("D", 0.75M);
        }

        [Test, TestCaseSource("TestScenarios")]
        public void GroceryTerminal_will_calculate_correct_total(TestData testScenario)
        {
            foreach (var product in testScenario.Products)
            {
                _terminal.ScanProduct(product);
            }

            _terminal.CalculatePrice().Should().Be(testScenario.ExpectedPrice);
        }

        private static IEnumerable<TestData> TestScenarios()
        {
            return new List<TestData>
            {
                new TestData { Products = new List<string> {"A", "B", "C", "D", "A", "B", "A" }, ExpectedPrice = 13.25M },
                new TestData { Products = new List<string> {"C", "C", "C", "C", "C", "C", "C" }, ExpectedPrice = 6M },
                new TestData { Products = new List<string> {"A", "B", "C", "D" }, ExpectedPrice = 7.25M }
            };
        }

        public class TestData
        {
            public IList<string> Products { get; set; }
            public decimal ExpectedPrice { get; set; }
        }
    }
}