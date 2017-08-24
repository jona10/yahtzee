using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Yahtzee.Tests
{
    [TestFixture]
    public class OnesCalculatorTest
    {
        [Test]
        public void ReturnsZeroWhenNoDieDisplayOne()
        {
            var calculator = new OnesCalculator();
            var result = calculator.Calculate(new List<int> { 2, 2, 2, 2, 2, 2 });

            Assert.AreEqual(0, result);
        }
    }

    public class OnesCalculator
    {
        public OnesCalculator()
        {
        }

        public int Calculate(IEnumerable<int> dice)
        {
            throw new NotImplementedException();
        }
    }
}
