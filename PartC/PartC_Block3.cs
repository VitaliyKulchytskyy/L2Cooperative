using System;

namespace CooperativeLab
{
    class PartC_Block3 : Block
    {
        private const byte m_variant = 13;

        
        private byte RowMaxDigit()
        {
            int max = Program.GJArray[0][0];
            byte index = 0;

            for(byte i = 0; i < Program.GJArray.Length; i++)
            {
                for(byte j = 0; j < Program.GJArray[i].Length; j++)
                {
                    if(max <= Program.GJArray[i][j])
                    {
                        max = Program.GJArray[i][j];
                        index = i;
                    }
                }
            }

            return index;
        }

        public override void ProcessData()
        {
            if (Program.GJArray.Length == 0 || Program.GJArray[0].Length == 0)
                throw new Exception("NotEnoughValuesException");

            byte minRow = RowMaxDigit();
            Array.Resize(ref Program.GJArray, Program.GJArray.Length + 1);

            for (int i = Program.GJArray.Length - 2; i >= minRow; i--)
                Program.GJArray[i + 1] = Program.GJArray[i];

            int[] emptyRow = new int[Program.GJArray[0].Length];
            Array.Clear(emptyRow, 0, emptyRow.Length);

            Program.GJArray[minRow] = emptyRow;
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
