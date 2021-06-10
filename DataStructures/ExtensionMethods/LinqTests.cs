using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionMethods
{
    public class LinqTests
    {
        [Fact]
        public void BuyProducts()
        {
            var p1 = new Product("ciocolata", new Stock(50));
            var p2 = new Product("prajiturica", new Stock(20));

            p1.BuyProduct(45);
            Assert.True(p1.GetStock() == 5);
        }

        [Fact]
        public void VowelsAndCons()
        {
            string str = "wow ce imi place sa fac linq!";
            (int first, int second) = LinqMethods.VowelsAndCons(str);
            Assert.True(first == 9);
            Assert.True(second == 13);
        }

        [Fact]
        public void Distinct()
        {
            string str = "wow ce imi place sa fac linq wow super!";
            Assert.True(LinqMethods.FirstUniqueCharacter(str).Equals('m'));
        }

        [Fact]
        public void MaxApp()
        {
            string str = "aabbcccccddd!";
            Assert.True(LinqMethods.MaxAppearances(str).Equals('c'));
        }

        [Fact]
        public void Palindom()
        {
            string str = "aabaac";
            List<string> palindroms = LinqMethods.Palindrom(str);
            string[] pal = palindroms.ToArray();
            Assert.True(palindroms[0].Equals("a"));
            Assert.True(palindroms[1].Equals("a"));
            Assert.True(palindroms[2].Equals("b"));
            Assert.True(palindroms[3].Equals("a"));
            Assert.True(palindroms[4].Equals("a"));
            Assert.True(palindroms[5].Equals("c"));
            Assert.True(palindroms[6].Equals("aa"));
            Assert.True(palindroms[7].Equals("aa"));
            Assert.True(palindroms[8].Equals("aba"));
            Assert.True(palindroms[9].Equals("aabaa"));

        }
    }
}
