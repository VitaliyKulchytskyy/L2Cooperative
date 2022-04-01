using System;

namespace CooperativeLab
{
    partial class Program
    {
        private enum QuestionType
        {
            SetBlock = 0,
            ChangeArray = 1,
            DoMethod    = 2,
            PrintArray  = 3,
            Exit = 4,
            ChooseStatement = 5            
        }

        private const byte QuestionTypeLength = 6;
        private const byte BlockAmount = 2;
        
        public static void QuestionHandler(string printQuestion, ref byte result, byte lBorder = 0)
        {            
            do {
                string separator = (lBorder != 0) ? $" [0..{lBorder}]: " : ": ";
                Console.Write(printQuestion + separator);
                try
                {
                    byte convertAnswer = byte.Parse(Console.ReadLine());                    
                    if(lBorder != 0)
                        if (!(convertAnswer <= lBorder))
                            throw new Exception("WrongAnswer");
                    result = convertAnswer;
                    return;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("[!] Помилка введення.");
                }     
                catch (System.OverflowException)
                {
                    Console.WriteLine($"[!] Ви вийшли за межi дiапазону [{byte.MinValue}..{byte.MaxValue}] (включно).");
                }
                catch(Exception questionException)
                {
                    switch(questionException.Message)
                    {
                        case "WrongAnswer":
                            Console.WriteLine($"[!] Введiть значення з дiапазону [0..{lBorder}].");
                            break;
                    }
                }
            } while (true);
        }
        
        private static void PrintArray()
        {
            Console.Write("[Array]\n");
            foreach (int i in Program.GArray)
                Console.Write(i + "\t");
            Console.WriteLine();
        }

        private static void PrintJArray()
        {
            Console.Write("[Jagged array]\n");
            for(byte i = 0; i < Program.GJArray.Length; i++)
            {
                for (byte j = 0; j < Program.GJArray[i].Length; j++)
                    Console.Write(Program.GJArray[i][j] + "\t");
                Console.WriteLine();   
            }
        }

        private static void SetBlock(ref byte blockId)
        {
            Console.WriteLine("[Блок]\n[0] - 1 блок;\n[1] - 3 блок.");
            QuestionHandler(" - Введiть номер блоку", ref blockId, BlockAmount - 1); 
        }

        private static void FillArrayHandler(byte block)
        {
            Console.WriteLine("\n[Заповнення масива]\n[0] - власноруч;\n[1] - випадковими значеннями.");

            byte fillMethod = 0;
            QuestionHandler(" - Оберiть метод заповнення масива", ref fillMethod, 1);

            byte rowLength = 0;
            if (block == 0)
            {             
                QuestionHandler(" - Введiть кiлькiсть елементiв рядка", ref rowLength);
                GArray = (fillMethod == 0) ? FillArrayFromKeyboard(rowLength)
                    : FillArrayWithRandomValues(rowLength);
            }
            else
            {
                QuestionHandler(" - Введiть кiлькiсть рядкiв", ref rowLength);
                byte columnLength = 0;
                QuestionHandler(" - Введiть кiлькiсть стовпчикiв", ref columnLength);
                GJArray = (fillMethod == 0) ? FillJArrayFromKeyboard(rowLength, columnLength)
                    : FillJArrayWithRandomValues(rowLength, columnLength);
            }
        }

        private static byte GetBlock(byte block) => (byte)((block == 0) ? 1 : 3);
        
        private static void SetVariant(ref byte variant, byte block, in Part[] parts)
        {
            Console.WriteLine($"\n[Варiант (блок №{GetBlock(block)})]");

            for (byte partIndex = 0; partIndex < parts.Length; partIndex++)
                Console.WriteLine($"[{partIndex}] - варiант №{parts[partIndex].Block[block].GetBlockVariant()} студента {parts[partIndex].GetAuthor()}");
            QuestionHandler(" - Введiть номер варiанта", ref variant, (byte)(parts.Length - 1)); 
        }
        
        private static void ProcessDataHandler(byte variant, byte block, in Part[] parts)
        {
            try
            {                            
                parts[variant].Block[block].ProcessData();
            } 
            catch(Exception processDataException)
            {
                switch (processDataException.Message)
                {
                    case "BadResizeException":
                        Console.WriteLine($"[!] Даний варiант (B{GetBlock(block)}-V{parts[variant].Block[block].GetBlockVariant()}) не може опрацювати масив.\n[?] Спробуйте вести iншi значення до масива.");
                        break;
                    case "NotEnoughValuesException":
                        Console.WriteLine($"[!] Для виконання варiанта (B{GetBlock(block)}-V{parts[variant].Block[block].GetBlockVariant()}) передано недостатньо значень в масив.\n[?] Спробуйте вести ще декiлька значень до масива.");
                        break;
                }
                return;
            }
        }

        private static void PrintArrayHandler(byte variant, byte block, in Part[] parts)
        {
            if(block == 0)
                PrintArray();
            else
                PrintJArray();
        }

        private static QuestionType GetNextCommand()
        {
            Console.WriteLine("\n[Наступна дiя]\n[0] - змiнити блок;\n[1] - змiнити масив;\n[2] - обрати варiант;\n[3] - вивести поточний стан масива;\n[4] - завершити роботу.");
            byte statement = 0;
            QuestionHandler(" - Введiть наступну дiю", ref statement, QuestionTypeLength - 2);

            if(statement == (byte)QuestionType.Exit)
                Environment.Exit(0);
            Console.WriteLine();

            return (QuestionType)statement;
        }
    }
}