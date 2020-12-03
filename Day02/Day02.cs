using System;
using System.IO;
using System.Linq;
using Day02;
using MoreLinq;

var input = File.ReadAllLines("input.txt")
    .ToList();

Console.WriteLine("Finding password that do fit rules for Part1...");
var validPasswords = PasswordCheckerV1.FindValidPasswords(input);
Console.WriteLine($"Found {validPasswords.Count} valid passwords:");
validPasswords.ForEach(password => Console.WriteLine(password));

Console.WriteLine();

Console.WriteLine("Finding password that do fit rules for Part2...");
validPasswords = PasswordCheckerV2.FindValidPasswords(input);
Console.WriteLine($"Found {validPasswords.Count} valid passwords:");
validPasswords.ForEach(password => Console.WriteLine(password));