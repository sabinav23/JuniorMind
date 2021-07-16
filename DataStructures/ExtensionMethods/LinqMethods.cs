using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace ExtensionMethods
{
    public static class LinqMethods
    {
        public static (int, int) VowelsAndCons(string str)
        {
            string vowels = "aeiou";

            var (vowelNr, consNr) = ExtensionMethod.Aggregate(str, (v:0, c:0), (tuple, l) =>
            {
                var (v, c) = tuple;
                if (Char.IsLetter(l))
                {
                    return vowels.Contains(l) ? (v + 1, c) : (v, c + 1);
                }
                return (v, c);
            });

            return (vowelNr, consNr);
        }

        public static char FirstUniqueCharacter(string str)
        {
            return  str.GroupBy(x => x)
                .Where(x => x.Count() == 1)
                .Select(x => x.Key)
                .First();
            
        }

        public static char MaxAppearances(string str)
        {
            return str.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .First().Key;
        }

        public static List<string> Palindrom(string str)
        {
            var palindroms = Enumerable.Range(0, str.Length -1)
                .SelectMany(j => Enumerable.Range(0, str.Length - j).
                    Select(k => str.Substring(k, j+1)))
            .Where(current => current.SequenceEqual(current.Reverse())).ToList();

            return palindroms;
        }
        public static IEnumerable<List<int>> Sum(int[] numbers, int nr)
        {
            var sums = Enumerable.Range(0, numbers.Length - 1)
                .SelectMany(j => Enumerable.Range(0, numbers.Length - j)
                .Select(k => Enumerable.Range(k, j+1).Select(i => numbers[i]).ToList()))
            .Where(current => current.Count > 0 && current.Sum() < nr);

            return sums;
        }
        
        
        public static IEnumerable<int[]> Triplet(int[] numbers)
        {
           var triples = Enumerable.Range(0, numbers.Length)
            .SelectMany(i => Enumerable.Range(0, numbers.Length)
            .SelectMany(j => Enumerable.Range(0, numbers.Length)
                .Where(k => numbers[i] * numbers[i] + numbers[j] * numbers[j] == numbers[k] * numbers[k])
                .Select(k => new int[] {numbers[i], numbers[j], numbers[k]})));

            return triples;
        }


        public static IEnumerable<string> PlusMinus(int n, int k)
        {
            return Enumerable.Range(0, n)
                .Aggregate(new[] {""},
                    (seed, value) => seed.SelectMany(s => { return new string[] {s + "+", s + "-"}; }).ToArray())
                .Where(sum => sum.Select((s, index) => s == '-' ? -(index + 1) : index + 1).Sum() == k)
                .Select(sum => string.Join("",sum.Select((s, index) => s == '-' ? $"-{index + 1}" : $"+{index + 1}" )));
        }

        public static IEnumerable<Product> Feature(List<Product> products, ICollection<Feature> features)
        {
            var prod = products.Where(p => features.Any(f => p.Features.Contains(f)));

             return prod;
        }

        public static IEnumerable<Product> AllFeatures(List<Product> products, ICollection<Feature> features)
        {
            var prod = products.Where(p => features.All(f => p.Features.Contains(f)));

            return prod;        
        }

        public static IEnumerable<Product> HasNoFeature(List<Product> products, ICollection<Feature> features)
        {
            var prod = products.Where(p => !features.Any(f => p.Features.Contains(f)));

            return prod;
        }

        public static IEnumerable<ProductStruct> MaxQuantity(List<ProductStruct> l1, List<ProductStruct> l2)
        {
            var prod = l1.Union(l2).GroupBy(p => new { p.Name })
                .Select(o => new ProductStruct()
                {
                    Name = o.Key.Name,
                    Quantity = o.Sum(q => q.Quantity)
                });

            return prod;
        }

        public static IEnumerable<TestResult> MaxScore(List<TestResult> l1)
        {
            var result = l1.GroupBy(f => new { f.FamilyId, f.Id })
                .Select(o => o.Aggregate((max, next) => next.Score > max.Score ? next : max));

            return result;
        }

        public static IEnumerable<WordOccurrance> MaxOccurrence(string text)
        {
            var topWords = text
                .Split(' ')
                .GroupBy(x => x)
                .Select(x => new WordOccurrance{
                    Name = x.Key,
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(3);

            return topWords;
        }

        public static bool SudokuValidator(List<List<int>> sudokuBoard)
        {

            var columns = GetColumns(sudokuBoard);
            var blocks = GetBlocks(sudokuBoard);

            return IsValid(sudokuBoard) && IsValid(columns) && IsValid(blocks);
        }
    

        public static bool IsValid(IEnumerable<IEnumerable<int>> lines)
        {
            return lines.Where(line => line.Where(value => value > 0 && value <= 9).Distinct().Count() == 9).Count() == lines.Count();
        }

        private static IEnumerable<IEnumerable<int>> GetColumns(List<List<int>> sudokuBoard) 
        {
            var columns = Enumerable.Range(0, 9)
                .Select(lineCount => Enumerable.Range(0, 9)
                .Select(columnCount => sudokuBoard[columnCount][lineCount]));

            return columns;
        }

        private static IEnumerable<IEnumerable<int>> GetBlocks(List<List<int>> sudokuBoard)
        {   
            var sudokuBlockSize = 3;
            var blocks = Enumerable.Range(0, 9)
                .Select(lineCount => Enumerable.Range(0, 9)
                .Select(columnCount => sudokuBoard[lineCount / sudokuBlockSize * sudokuBlockSize + columnCount / sudokuBlockSize][lineCount % sudokuBlockSize * sudokuBlockSize + columnCount % sudokuBlockSize]));

            return blocks;
        }

        public static IEnumerable<double> PolishForm(string expression)
        {
            var a = expression.Split(" ");

            var result = a.Aggregate(new List<double>().AsEnumerable(),
                (accumulator, value) => double.TryParse(value, out var k) ?
                    accumulator.Append(k) :
                    accumulator.SkipLast(2).Append(GetOperationResult(accumulator.TakeLast(2), value)));

            return result;
        }
        private static double GetOperationResult(IEnumerable<double> numbers, string value)
        {
            double x = 0;

            var firstNumber = numbers.ElementAt(0);
            var secondNumber = numbers.ElementAt(1);

            x = value switch
            {
                "+" => firstNumber + secondNumber,
                "-" => firstNumber - secondNumber,
                "*" => firstNumber * secondNumber,
                "/" => firstNumber / secondNumber,
                _ => x
            };

            return x;
        }
    }
}
