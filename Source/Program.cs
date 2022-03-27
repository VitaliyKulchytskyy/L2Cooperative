using System;

namespace CooperativeLab
{
    partial class Program
    {
        enum QuestionType
        {
            SetBlock,
            ChangeArray,
            DoMethod,
            PrintArray,
            Exit,
            ChooseStatement            
        }
        const byte QuestionTypeLength = 6;
        const byte BlockAmount = 2;
        public static int[] GArray;
        public static int[][] GJArray;

        static void QuestionHandler(string printQuestion, ref byte result, byte lBorder = 0)
        {            
            do {
                Console.Write(printQuestion + ((lBorder != 0) ? $" [0..{lBorder}]: " : ": "));
                try
                {
                    byte convertAnswer = byte.Parse(Console.ReadLine());                    
                    if(lBorder != 0)
                        if (!(convertAnswer >= 0 && convertAnswer <= lBorder))
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
                catch(Exception QuestionException)
                {
                    switch(QuestionException.Message)
                    {
                        case "WrongAnswer":
                            Console.WriteLine($"[!] Введiть значення з дiапазону [0..{lBorder}].");
                            break;
                    }
                }
            } while (true);
        }      

        static void Main(string[] args)
        {
            Block[] blocksOfA = { new PartA_Block1(), new PartA_Block3() };
            Block[] blocksOfB = { new PartB_Block1(), new PartB_Block3() };
            Block[] blocksOfC = { new PartC_Block1(), new PartC_Block3() };
            Part[] parts = { new PartA(blocksOfA), new PartB(blocksOfB), new PartC(blocksOfC) };

            byte variant = 0, block = 0, rowLength = 0, columnLength = 0, fillMethod = 0;
            Func<int, int> getBlockNumber = x => ((x == 0) ? 1 : 3);
            QuestionType command = QuestionType.SetBlock;

            do
            {            
                switch(command)
                {
                    case QuestionType.SetBlock:
                        Console.WriteLine("[Блок]\n[0] - 1 блок;\n[1] - 3 блок.");
                        QuestionHandler(" - Введiть номер блоку", ref block, BlockAmount - 1);
                        goto case QuestionType.ChangeArray; // fall through

                    case QuestionType.ChangeArray:
                        Console.WriteLine("\n[Заповнення масива]\n[0] - власноруч;\n[1] - випадковими значеннями.");
                        QuestionHandler(" - Оберiть метод заповнення масива", ref fillMethod, 1);
                        QuestionHandler(" - Введiть кiлькiсть елементiв рядка", ref rowLength);

                        if (block == 0)
                        {                            
                            GArray = (fillMethod == 0) ? FillArrayFromKeyboard(rowLength)
                                : FillArrayWithRandowValues(rowLength);
                        }
                        else
                        {
                            QuestionHandler(" - Введiть кiлькiсть стовпчикiв", ref columnLength);
                            GJArray = (fillMethod == 0) ? FillJArrayFromKeyboard(rowLength, columnLength)
                                : FillJArrayWithRandowValues(rowLength, columnLength);
                        }

                        goto case QuestionType.ChooseStatement;

                    case QuestionType.DoMethod:
                        Func<int, int, int> getVariant = (varNum, blockNum) => parts[blockNum].Block[varNum].GetBlockVariant();
                        Console.WriteLine($"\n[Варiант (блок №{getBlockNumber(block)})]");

                        for (byte partIndex = 0; partIndex < parts.Length; partIndex++)
                            Console.WriteLine($"[{partIndex}] - варiант №{getVariant(block, partIndex)} студента {parts[partIndex].GetAuthor()}");
                        QuestionHandler(" - Введiть номер варiанта", ref variant, (byte)(parts.Length - 1));

                        try
                        {                            
                            parts[variant].Block[block].ProcessData();
                        } 
                        catch(Exception ProcessDataException)
                        {
                            switch (ProcessDataException.Message)
                            {
                                case "BadResizeException":
                                    Console.WriteLine($"[!] Даний варiант (B{getBlockNumber(block)}-V{getVariant(variant, block)}) не може опрацювати масив.\n[?] Спробуйте вести iншi значення до масива.");
                                    break;
                                case "NotEnoughValuesException":
                                    Console.WriteLine($"[!] Для виконання варiанта (B{getBlockNumber(block)}-V{getVariant(block, variant)}) передано недостатньо значень в масив.\n[?] Спробуйте вести ще декiлька значень до масива.");
                                    break;
                            }
                            goto case QuestionType.ChooseStatement;
                        }
                        goto case QuestionType.ChooseStatement;

                    case QuestionType.PrintArray:
                        if(block == 0)
                            parts[variant].Block[block].PrintArray();
                        else
                            parts[variant].Block[block].PrintJArray();
                        goto case QuestionType.ChooseStatement;

                    case QuestionType.ChooseStatement:
                        byte statement = 0;
                        Console.WriteLine("\n[Наступна дiя]\n[0] - змiнити блок;\n[1] - змiнити масив;\n[2] - обрати варiант;\n[3] - вивести поточний стан масива;\n[4] - закiнчити роботу.");
                        QuestionHandler(" - Введiть наступну дiю", ref statement, QuestionTypeLength - 2);

                        if(statement == (byte)QuestionType.Exit)
                            Environment.Exit(0);
                        Console.WriteLine();

                        command = (QuestionType)statement;                           
                        break;
                }
            } while (true);
        }
    }
}