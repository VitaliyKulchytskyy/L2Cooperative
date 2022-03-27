using System;

namespace CooperativeLab
{
    abstract class Block
    {
        public void PrintArray()
        {
            Console.Write("[Array]\n");
            foreach (int i in Program.GArray)
                Console.Write(i + "\t");
            Console.WriteLine();
        }

        public void PrintJArray()
        {
            Console.Write("[Jagged array]\n");
            for(byte i = 0; i < Program.GJArray.Length; i++)
            {
                for (byte j = 0; j < Program.GJArray[i].Length; j++)
                    Console.Write(Program.GJArray[i][j] + "\t");
                Console.WriteLine();   
            }
        }

        public abstract void ProcessData();
        public abstract byte GetBlockVariant();
    }
}
