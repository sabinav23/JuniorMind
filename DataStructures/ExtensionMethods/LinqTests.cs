using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Xunit;
using static Xunit.Assert;

namespace ExtensionMethods
{
     public struct ProductStruct
    {
        public string Name;
        public int Quantity;
    }

    public class LinqTests
    {
        [Fact]
        public void ProductStock()
        {
            string name = "tv";
            Stock s = new Stock(name, 15);

            var notificationsCount = 0;
            Action<int, string> callback = (q, n) => notificationsCount++;
            
            s.UpdateStock(7, callback);
            s.UpdateStock(5, callback);
            
            Assert.Equal(2, notificationsCount);
        }

        [Fact]
        public void VowelsAndCons()
        {
            string str = "wow ce imi place sa fac linq!";
            (int first, int second) = LinqMethods.VowelsAndCons(str);
            var a = first;
            var b = second;
            True(first == 9);
            True(second == 13);
        }

        [Fact]
        public void Distinct()
        {
            string str = "wow ce imi place sa fac linq wow super!";
            True(LinqMethods.FirstUniqueCharacter(str).Equals('m'));
        }

        [Fact]
        public void MaxApp()
        {
            string str = "aabbcccccddd!";
            True(LinqMethods.MaxAppearances(str).Equals('c'));
        }
        
        [Fact]
        public void Palindom()
        {
            string str = "aabaac";
            List<string> palindroms = LinqMethods.Palindrom(str);
            string[] pal = palindroms.ToArray();
            True(palindroms[0].Equals("a"));
            True(palindroms[1].Equals("a"));
            True(palindroms[2].Equals("b"));
            True(palindroms[3].Equals("a"));
            True(palindroms[4].Equals("a"));
            True(palindroms[5].Equals("c"));
            True(palindroms[6].Equals("aa"));
            True(palindroms[7].Equals("aa"));
            True(palindroms[8].Equals("aba"));
            True(palindroms[9].Equals("aabaa"));
        }
        [Fact]
        public void Sum()
        {
            int[] numbers = {1, 5, 7, 8, 9, 15, 25};
            int result = 25;
            var num = LinqMethods.Sum(numbers, result);

            var sum1 = new List<int>();
            sum1.Add(1);
            var sum2= new List<int>();
            sum2.Add(5);

            var en = num.GetEnumerator();

            True(en.MoveNext());
            Equal(sum1, en.Current);
            True(en.MoveNext());
            Equal(sum2, en.Current);
        }

        [Fact]
        public void PlusMinus()
        {
            int result = 4;
            int n = 3;
            var sums = LinqMethods.PlusMinus(n, result);

            var sum1 = sums.GetEnumerator();

            sum1.MoveNext();

            Equal("-1+2+3", sum1.Current);
        }
        
        [Fact]
        public void Tripl()
        {
            int[] arr = { 8, 5, 6, 3, 4, 10 };

            var trip = LinqMethods.Triplet(arr);

            var en = trip.GetEnumerator();

            Equal(4, trip.Count());
        }
        

        [Fact]
        public void Features()
        {
            var feature1 = new Feature();
            var feature2 = new Feature();
            var feature3 = new Feature();
            var feature4 = new Feature();
            var feature5 = new Feature();
            var feature6 = new Feature();
            var feature7 = new Feature();

            feature1.Id = 1;
            feature2.Id = 2;
            feature3.Id = 3;
            feature4.Id = 4;
            feature5.Id = 5;
            feature6.Id = 4;
            feature7.Id = 5;

            var fl1 = new List<Feature>();
            fl1.Add(feature1);
            fl1.Add(feature2);
            fl1.Add(feature3);
            fl1.Add(feature4);
            fl1.Add(feature5);

            var fl2 = new List<Feature>();
            fl2.Add(feature1);
            fl2.Add(feature7);

            var fl3 = new List<Feature>();
            fl3.Add(feature1);
            fl3.Add(feature2);

            var fl4 = new List<Feature>();
            fl4.Add(feature6);
            fl4.Add(feature7);

            var fl5 = new List<Feature>();
            fl5.Add(feature7);
            fl5.Add(feature6);
            fl5.Add(feature1);


            var product1 = new Product();
            var product2 = new Product();
            var product3 = new Product();
            var product4 = new Product();
            var product5 = new Product();

            product1.Features = fl2;
            product2.Features = fl3;
            product3.Features = fl4;
            product4.Features = fl1;
            product5.Features = fl5;

            var products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);

            var prod = LinqMethods.Feature(products, fl1);


            var en = prod.GetEnumerator();

            True(en.MoveNext());
            Equal(product1, en.Current);
            True(en.MoveNext());
            Equal(product2, en.Current);
            True(en.MoveNext());
            Equal(product4, en.Current);
            True(en.MoveNext());
            Equal(product5, en.Current);
            False(en.MoveNext());
        }

        [Fact]
        public void AllFeatures()
        {
            var feature1 = new Feature();
            var feature2 = new Feature();
            var feature3 = new Feature();
            var feature4 = new Feature();
            var feature5 = new Feature();
            var feature6 = new Feature();
            var feature7 = new Feature();

            feature1.Id = 1;
            feature2.Id = 2;
            feature3.Id = 3;
            feature4.Id = 4;
            feature5.Id = 5;
            feature6.Id = 4;
            feature7.Id = 5;

            var fl1 = new List<Feature>();
            fl1.Add(feature1);
            fl1.Add(feature2);
            fl1.Add(feature3);
            fl1.Add(feature4);
            fl1.Add(feature5);

            var fl2 = new List<Feature>();
            fl2.Add(feature1);
            fl2.Add(feature1);
            fl2.Add(feature1);


            var fl3 = new List<Feature>();
            fl3.Add(feature1);
            fl3.Add(feature2);

            var fl4 = new List<Feature>();
            fl4.Add(feature6);
            fl4.Add(feature7);

            var fl5 = new List<Feature>();
            fl5.Add(feature1);
            fl5.Add(feature2);
            fl5.Add(feature3);
            fl5.Add(feature4);
            fl5.Add(feature5);
            fl5.Add(feature2);
            fl5.Add(feature5);


            var product1 = new Product();
            var product2 = new Product();
            var product3 = new Product();
            var product4 = new Product();
            var product5 = new Product();

            product1.Features = fl2;
            product2.Features = fl3;
            product3.Features = fl4;
            product4.Features = fl1;
            product5.Features = fl5;

            var products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);

            var num  = fl1.Count;
            var prod = LinqMethods.AllFeatures(products, fl1);


            var en = prod.GetEnumerator();

            True(en.MoveNext());
            Equal(product4, en.Current);
            True(en.MoveNext());
            Equal(product5, en.Current);
            False(en.MoveNext());
        }

        [Fact]
        public void NoFeature()
        {
            var feature1 = new Feature();
            var feature2 = new Feature();
            var feature3 = new Feature();
            var feature4 = new Feature();
            var feature5 = new Feature();
            var feature6 = new Feature();
            var feature7 = new Feature();

            feature1.Id = 1;
            feature2.Id = 2;
            feature3.Id = 3;
            feature4.Id = 4;
            feature5.Id = 5;
            feature6.Id = 4;
            feature7.Id = 5;

            var fl1 = new List<Feature>();
            fl1.Add(feature1);
            fl1.Add(feature2);
            fl1.Add(feature3);
            fl1.Add(feature4);
            fl1.Add(feature5);

            var fl2 = new List<Feature>();
            fl2.Add(feature1);
            fl2.Add(feature1);
            fl2.Add(feature1);


            var fl3 = new List<Feature>();
            fl3.Add(feature1);
            fl3.Add(feature2);

            var fl4 = new List<Feature>();
            fl4.Add(feature6);
            fl4.Add(feature7);

            var fl5 = new List<Feature>();
            fl5.Add(feature1);
            fl5.Add(feature2);
            fl5.Add(feature3);
            fl5.Add(feature4);
            fl5.Add(feature5);
            fl5.Add(feature2);
            fl5.Add(feature5);


            var product1 = new Product();
            var product2 = new Product();
            var product3 = new Product();
            var product4 = new Product();
            var product5 = new Product();

            product1.Features = fl2;
            product2.Features = fl3;
            product3.Features = fl4;
            product4.Features = fl1;
            product5.Features = fl5;

            var products = new List<Product>();
            products.Add(product1);
            products.Add(product2);
            products.Add(product3);
            products.Add(product4);
            products.Add(product5);

            var prod = LinqMethods.HasNoFeature(products, fl1);
            var en = prod.GetEnumerator();

            True(en.MoveNext());
            Equal(product3, en.Current);
            False(en.MoveNext());
        }

        [Fact]
        public void MaxQuantity()
        {
            var ps1 = new ProductStruct();
            ps1.Name = "Televizor";
            ps1.Quantity = 100;
            var ps2 = new ProductStruct();
            ps2.Name = "Carte";
            ps2.Quantity = 500;
            var ps3 = new ProductStruct();
            ps3.Name = "Floare";
            ps3.Quantity = 10;
            var ps4 = new ProductStruct();
            ps4.Name = "Televizor";
            ps4.Quantity = 50;
            var ps5 = new ProductStruct();
            ps5.Name = "Floare";
            ps5.Quantity = 50;

            var l1 = new List<ProductStruct>();
            l1.Add(ps1);
            l1.Add(ps5);
            var l2 = new List<ProductStruct>();
            l1.Add(ps2);
            l1.Add(ps3);
            l1.Add(ps4);

            var ps6 = new ProductStruct();
            ps6.Name = "Televizor";
            ps6.Quantity = 150;
            var ps7 = new ProductStruct();
            ps7.Name = "Carte";
            ps7.Quantity = 500;
            var ps8 = new ProductStruct();
            ps8.Name = "Floare";
            ps8.Quantity = 60;

            var prod = LinqMethods.MaxQuantity(l1, l2);
            var en = prod.GetEnumerator();

            True(en.MoveNext());
            Equal(ps6, en.Current);
            True(en.MoveNext());
            Equal(ps8, en.Current);
            True(en.MoveNext());
            Equal(ps7, en.Current);
            False(en.MoveNext());
        }

        [Fact]
        public void MaxScore()
        {
            var tr1 = new TestResult();
            tr1.Id = "1";
            tr1.FamilyId = "10";
            tr1.Score = 100;
            var tr2 = new TestResult();
            tr2.Id = "2";
            tr2.FamilyId = "20";
            tr2.Score = 200;
            var tr3 = new TestResult();
            tr3.Id = "3";
            tr3.FamilyId = "30";
            tr3.Score = 300;
            var tr4 = new TestResult();
            tr4.Id = "4";
            tr4.FamilyId = "40";
            tr4.Score = 400;
            var tr5 = new TestResult();
            tr5.Id = "5";
            tr5.FamilyId = "50";
            tr5.Score = 500;
            var tr6 = new TestResult();
            tr6.Id = "1";
            tr6.FamilyId = "10";
            tr6.Score = 900;

            var l1 = new List<TestResult>();
            l1.Add(tr1);
            l1.Add(tr2);
            l1.Add(tr3);
            l1.Add(tr4);
            l1.Add(tr5);
            l1.Add(tr6);
            
            var prod = LinqMethods.MaxScore(l1);
            var en = prod.GetEnumerator();

            True(en.MoveNext());
            Equal(tr6.Score, en.Current.Score);
            True(en.MoveNext());
            Equal(tr2, en.Current);
            True(en.MoveNext());
            Equal(tr3, en.Current);
            True(en.MoveNext());
            Equal(tr4, en.Current);
            True(en.MoveNext());
            Equal(tr5, en.Current);
            False(en.MoveNext());
        }

        [Fact]
        public void MaxOccurrence()
        {
            var text = "Ana mere pere Ana pere mere Ana pere da mere nu  wow Ana cool mere Ana ";

            var wo1 = new WordOccurrance();
            wo1.Name = "Ana";
            wo1.Count = 5;
            var wo2 = new WordOccurrance();
            wo2.Name = "mere";
            wo2.Count = 4;
            var wo3 = new WordOccurrance();
            wo3.Name = "pere";
            wo3.Count = 3;

            var top = LinqMethods.MaxOccurrence(text);
            var en = top.GetEnumerator();


            True(en.MoveNext());
            Equal(wo1.Name, en.Current.Name);
            Equal(wo1.Count, en.Current.Count);
            True(en.MoveNext());
            Equal(wo2.Name, en.Current.Name);
            Equal(wo2.Count, en.Current.Count);
            True(en.MoveNext());
            Equal(wo3.Name, en.Current.Name);
            Equal(wo3.Count, en.Current.Count);
            False(en.MoveNext());
        }

        [Fact]
        public void Sudoku()
        {
            List<List<int>> board = new List<List<int>>();
            board.Add(new List<int> { 6, 8, 2, 1 ,9 ,4, 3, 5, 7 });
            board.Add(new List<int> { 7, 3, 1, 5, 6, 8, 9, 2, 4 });
            board.Add(new List<int> { 4, 9, 5, 7, 2, 3, 8, 6, 1 });
            board.Add(new List<int> { 8, 2, 7, 9, 3, 5, 1, 4, 6 });
            board.Add(new List<int> { 5, 1, 9, 6, 4, 7, 2, 8, 3 });
            board.Add(new List<int> { 3, 6, 4, 2, 8, 1, 5, 7, 9 });
            board.Add(new List<int> { 9, 5, 6, 4, 1, 2, 7, 3, 8 });
            board.Add(new List<int> { 2, 4, 8, 3, 7, 9, 6, 1, 5 });
            board.Add(new List<int> { 1, 7, 3, 8, 5, 6, 4, 9, 2 });

            True(LinqMethods.SudokuValidator(board));
        }

        [Fact]
        public void PolishForm()
        {
            var expression = "5 1 2 + 4 * + 3 -";

            var result = LinqMethods.PolishForm(expression);

            var en = result.GetEnumerator();

            double r = 14;

            True(en.MoveNext());
            Equal(r, en.Current);
            False(en.MoveNext());
        }
    }
}
