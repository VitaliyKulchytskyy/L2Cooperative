using System;

namespace CooperativeLab
{
    partial class Program
    {
        public static int[] GArray;     // Global Array
        public static int[][] GJArray;  // Global Jagged Array
        
        private static int[] FillArrayWithRandomValues(byte elemNum)
        {
            Random rndValue = new Random();           
            int[] array = new int[elemNum];

            for (byte i = 0; i < array.Length; i++)
                array[i] = rndValue.Next(-99, 99);

            return array;
        }

        private static int[] FillArrayFromKeyboard(byte elemNum)
        {
            int[] array = new int[elemNum];
            byte i = 0;

            while (i < array.Length)
            {
                try
                {
                    Console.Write($"[{i}/{elemNum - 1}]: ");
                    array[i] = int.Parse(Console.ReadLine());
                    i++;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("[!] Помилка введення.");
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine($"[!] Ви вийшли за межi дiапазону [{int.MinValue}..{int.MaxValue}] (включно).");
                }
            }
            return array;
        }

        private static int[][] FillJArrayWithRandomValues(byte rowNum, byte columnNum)
        {
            Random rndValue = new Random();
            int[][] array = new int[rowNum][];

            for (byte i = 0; i < array.Length; i++)
            {
                array[i] = new int[columnNum];
                for (byte j = 0; j < array[i].Length; j++)
                    array[i][j] = rndValue.Next(-99, 99);
            }

            return array;
        }

        private static int[][] FillJArrayFromKeyboard(byte rowNum, byte columnNum)
        {
            int[][] array = new int[rowNum][];

            for(byte i = 0; i < array.Length; i++)
            {                 
                Console.WriteLine($" - [Ряд: {i}/{rowNum - 1}]");
                array[i] = FillArrayFromKeyboard(columnNum);
            }

            return array;
        }
    }
}
