using System;

namespace Chapter11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var source = new[] {3, 2, 1, 4};

            Console.WriteLine(ArrayToString(InsertionSort1(source)));
            Console.WriteLine("------------------------------------------------------");

            var source2 = new[] {3, 2, 1, 4};
            Console.WriteLine(ArrayToString(InsertionSort2(source2)));

            Console.ReadKey();
        }

        private static string ArrayToString(int[] array)
        {
            return string.Join(",", array);
        }

        private static int[] InsertionSort1(int[] array)
        {
            for (var i = 1; i < array.Length - 1; i++)
            {
                for (var j = i; j > 0 && array[j - 1] > array[j]; j--)
                {
                    var t = array[j];
                    Console.WriteLine(
                        $"{ArrayToString(array)} .i={i},t ={t}, j={j},array[j-1]={array[j - 1]},array[j]={array[j]}");
                    array[j] = array[j - 1];
                    array[j - 1] = t;
                }
            }

            return array;
        }

        private static int[] InsertionSort2(int[] array)
        {
            for (var i = 1; i < array.Length - 1; i++)
            {
                var t = array[i];//还是不能理解为什么这里可以用i
                for (var j = i; j > 0 && array[j - 1] > array[j]; j--)
                {
                    Console.WriteLine(
                        $"{ArrayToString(array)} .i={i},t={t}, j={j},array[j-1]={array[j - 1]},array[j]={array[j]}");

                    array[j] = array[j - 1];
                    array[j - 1] = t;
                }
            }

            return array;
        }
    }
}