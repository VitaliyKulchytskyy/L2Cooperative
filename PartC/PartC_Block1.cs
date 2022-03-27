using System;
using System.Runtime.InteropServices;

namespace CooperativeLab
{
    class PartC_Block1 : Block
    {
        private const byte m_variant = 1;

        private int FindFirstPairDigitInRow()
        {
            
            for (int i = 0; i < Program.GArray.Length; i++) // made for searching of Pair digit itself in hole array
            {
                if (Program.GArray[i]%2==0) // when it should be found
                {
                    return i;
                }
                
            }

            return -1;
            

           

            //return index; // the end

        }


        public override void ProcessData()
        {
            if (Program.GArray.Length == 0)
                throw new Exception("NotEnoughValuesException");// end of exception
            
            int pairElement = FindFirstPairDigitInRow(); // pair element 
            Console.WriteLine(pairElement);
            if (pairElement == -1)
                throw new Exception("BadResizeException"); // ISSUE
                
            

            for (int i = pairElement + 1; i < Program.GArray.Length; i++) //when to resize 
            {
                Program.GArray[i - 1] = Program.GArray[i]; // how to resize
            }

            
            Array.Resize(ref Program.GArray, Program.GArray.Length-1); // resize itself
            
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
