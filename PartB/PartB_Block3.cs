using System;

namespace CooperativeLab
{
    class PartB_Block3 : Block
    {
        private const byte m_variant = 11;

        
        private int[] FindPairedIndexRowsOfjArray()
        {
            //int[] arrayForPairedIndex = new int[GJArray.Length / 2 + GJArray.Length % 2];
            /*for (int i = 0; i < GJArray.Length; i++)
                if (i % 2 == 0) arrayForPairedIndex[i / 2] = i;
            return arrayForPairedIndex;*/
            int[] arrayForPairedIndex = new int[Program.GJArray.Length / 2];
            for (int i = 0; i < Program.GJArray.Length; i++)
                if (i % 2 == 1) arrayForPairedIndex[i / 2] = i;
            return arrayForPairedIndex;
        }
        private void AddRowAfterPairedIndex()
        {
            int[] arrayForPairedIndex = FindPairedIndexRowsOfjArray();
            Array.Resize(ref Program.GJArray, Program.GJArray.Length + arrayForPairedIndex.Length);
            int[] emptyRow = new int[Program.GJArray[0].Length];
            Array.Clear(emptyRow, 0, emptyRow.Length);
            
            for (int i = 0; i < arrayForPairedIndex.Length; i++) 
            {
                int idx = arrayForPairedIndex[i];
                for (int j = Program.GJArray.Length - 2; j > idx + i; j--)
                    SwapRow(ref Program.GJArray[j + 1], ref Program.GJArray[j]);
                //Program.GJArray[idx + 1 + i] = new int[Program.GJArray[idx].Length];
                Program.GJArray[idx + 1 + i] = emptyRow;
            }
        }
        private void SwapRow(ref int[] a, ref int[] b)
        {
            int[] tmp = a; a = b; b = tmp;
        }
        public override void ProcessData()
        {
            if (Program.GJArray[0].Length <= 1)
                throw new Exception("NotEnoughValuesException");
            
            
            AddRowAfterPairedIndex();
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
