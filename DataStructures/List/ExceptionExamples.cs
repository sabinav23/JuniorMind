
using System;
using System.Collections.Generic;
using System.Text;

namespace IntArrayProject
{
    class ExceptionExamples
    {
        int[] arr = new int[5] { 1, 2, 3, 4, -15 };
        string[] nume = new string[5] { "Mos", "Craciun", "Iepurasul", "Spiridusul", null };

        public int CountSumOfElements()
        {
            int count = 0;
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    count += arr[i];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                count = -1;
            }

            return count;
        }

        public int CountSumOfElementsMultimpleCatch()
        {
            int count = 0;
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    count /= i - 5;
                }

                return count = 10;
                
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }

            return count = 200;
        }

        public string FormWord()
        {
            string cuvant = "";
            try
            {
                for (int i = 0; i < 6; i++)
                {
                    cuvant = nume[i].Substring(2);
                }
            }
            catch (NullReferenceException e)
            {
                cuvant = e.Message;
            }

            return cuvant;
        }
        public string GetFirstLetterOfAWord(string cuvant)
        {
            if (cuvant == null)
            {
                throw new ArgumentNullException();
            }
            return cuvant.Substring(0, 1);
        }
    }
}
