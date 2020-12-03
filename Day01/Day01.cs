using System;
using System.IO;
using System.Linq;
using Day01;

var input = File.ReadAllLines("input.txt")
    .Select(int.Parse)
    .ToList();

Console.WriteLine("Search for two numbers...");
var wantedExpenses = ExpenseReportChecker.FindEntriesThatAddUpTo(input, 2, 2020);

Console.WriteLine($"The numbers {string.Join(", ", wantedExpenses)} sum to 2020. " +
    $"Their product is {ExpenseReportChecker.GetKeyProduct(wantedExpenses)}");

Console.WriteLine("Search for three numbers...");
wantedExpenses = ExpenseReportChecker.FindEntriesThatAddUpTo(input, 3, 2020);

Console.WriteLine($"The numbers {string.Join(", ", wantedExpenses)} sum to 2020. " +
    $"Their product is {ExpenseReportChecker.GetKeyProduct(wantedExpenses)}");