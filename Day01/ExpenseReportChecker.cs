using System.Collections.Generic;
using System.Linq;

namespace Day01
{
    public static class ExpenseReportChecker
    {
        public static IReadOnlyList<int> FindEntriesThatAddUpTo(IEnumerable<int> expenseReport, int numberOfEntries, int sum)
        {
            var current = new List<int>();
            var result = new List<int>();

            FindEntries(expenseReport, numberOfEntries, sum, current, result);

            return result;
        }


        private static void FindEntries(IEnumerable<int> leftExpenses, int numberOfSubsLeft, int sum, List<int> current, List<int> result)
        {
            for (int i = 0; i < leftExpenses.Count(); i++)
            {
                current.Add(leftExpenses.ElementAt(i));
                if (numberOfSubsLeft > 1)
                {
                    FindEntries(leftExpenses.Skip(i + 1), numberOfSubsLeft - 1, sum, current, result);
                }
                else if (current.Sum() == sum)
                {
                    result.AddRange(current);
                }
                else if (current.Any())
                {
                    current.RemoveAt(current.Count - 1);
                }
            }

            RemoveLast(current);
        }

        public static IReadOnlyList<int> FindEntriesThatAddUpTo_B(IEnumerable<int> expenseReport, int numberOfEntries, int sum)
        {
            var current = new List<int>();

            var res = FindEntries_B(expenseReport, numberOfEntries, numberOfEntries, sum, current);

            return res;
        }

        private static IReadOnlyList<int> FindEntries_B(IEnumerable<int> leftExpenses, int numberOfSubsLeft, int totalNumberOfEntries, int sum, List<int> current)
        {
            for (int i = 0; i < leftExpenses.Count(); i++)
            {
                int item = leftExpenses.ElementAt(i);
                current.Add(item);
                if (numberOfSubsLeft > 1)
                {
                    var res = FindEntries_B(leftExpenses.Skip(i + 1), numberOfSubsLeft - 1, totalNumberOfEntries, sum, current);

                    if (res.Count == totalNumberOfEntries)
                    {
                        return res;
                    }
                }
                else if (current.Sum() == sum)
                {
                    return current;
                }
                else if (current.Any())
                {
                    current.RemoveAt(current.Count - 1);
                }
            }

            current.RemoveAt(current.Count - 1);
            return current;
        }


        public static int GetKeyProduct(IEnumerable<int> expenses)
        {
            return expenses.Aggregate(1, (total, next) => total * next);
        }

        private static void RemoveLast(List<int> list)
        {
            if (list.Count == 1)
            {
                list.Clear();
            }
            else if (list.Count > 1)
            {
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}