using System.Linq;
using Day01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Day01Tests
    {
        [DataTestMethod]
        [DataRow(2, 514579)]
        [DataRow(3, 241861950)]
        [DataRow(1, 2020)]
        public void FindEntriesThatAddUpTo2020Test(int numbersToSum, int expextedProduct)
        {
            var expenseReport = new int[]
            {
                1721,
                299,
                1456,
                675,
                2020,
                366,
                979,
            };

            var wantedExpenses = ExpenseReportChecker.FindEntriesThatAddUpTo(expenseReport, numbersToSum, 2020);

            Assert.AreEqual(numbersToSum, wantedExpenses.Count);
            Assert.AreEqual(2020, wantedExpenses.Sum());
            Assert.AreEqual(expextedProduct, ExpenseReportChecker.GetKeyProduct(wantedExpenses));
        }
    }
}
