using System;
using System.Drawing;

namespace Numbers_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Ley's do some math!");
            try 
            { 
             StartSequence();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred. Please check your input.");
                Console.WriteLine($"Exception message: {ex.Message}");
            }
            finally
            {
             Console.WriteLine($"Program is complete.");
            }
        }

        static void StartSequence() 
        {
            try
            {
                Console.WriteLine("Please enter a number greater than zero");
                int size = Convert.ToInt32(Console.ReadLine());

                int[] array = Populate(size);
                int sum = GetSum(array);
                int product = GetProduct(array, sum);
                Console.WriteLine($"Please enter random number to divide your product {product}");
                var result = GetQuotient(product);

                //result 
                Console.WriteLine($"Your array is size: {size}");

                Console.Write($"The numbers in the array are ");
                for (int i = 0; i < array.Length; i++)
                {
                    if (i != 0)
                    {
                        Console.Write(",");
                    }
                    Console.Write(array[i]);
                }

                Console.WriteLine();
                Console.WriteLine($"The sum of ther array is {sum}");

                Console.WriteLine($"{sum} * {product / sum} = {product}");
                Console.WriteLine($"{product} / {(decimal)(product / sum)} = {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static int[] Populate(int size)
        {
            int[] array = new int[size];
            int count = 0;
            while (size > count)
            {
                Console.WriteLine($"Please enter  number:{count + 1} of {size}");
                int num = Convert.ToInt32(Console.ReadLine());
                array[count] = num;
                count++;
            }
            return array;
        }
        static int GetSum(int[] array)
        {
            int sum = array.Sum();
            if (sum < 20)
            {
                throw new Exception($"Value of {sum} is too low");
            }
            return sum;
        }

         static int GetProduct(int[] array,int sum)
        {
            try
            {
           
            Console.WriteLine($"Please enter random number between 1 and {array.Length}");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int product = sum * array[num1 - 1];
            return product;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("The entered number is too large or too small.");
                throw ex;
            }

        }
        static decimal GetQuotient(int product)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            try
            { 
            
            decimal result = decimal.Divide(product, num);
            
            return result;

            }
            catch (DivideByZeroException)
            {
                Console.WriteLine($"Cannot divide {product} by zero.");
                return 0;
            }
        }
       
      
    }
}