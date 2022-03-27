using System;

namespace CooperativeLab
{
    class PartB_Block1 : Block
    {
        private const byte m_variant = 5;
        static int[] EraseArrayFrom(int k, int t)
        {
            int[] newArray;
            if(t + k <= Program.GArray.Length)
            {
                newArray = new int[Program.GArray.Length - t];
                for(int i = 0; i < k; i++) newArray[i] = Program.GArray[i];
                for(int i = k + t; i < Program.GArray.Length; i++)
                    newArray[i - (k + t) + k] = Program.GArray[i];
            }
            else
            {
                newArray = new int[k];
                for(int i = 0; i < k; i++)
                    newArray[i] = Program.GArray[i];
            }
            return newArray;
        }
        public override void ProcessData()
        {
            if (Program.GArray.Length <= 1)
                throw new Exception("NotEnoughValuesException");

            byte K = 0, T = 0;
            
            Program.QuestionHandler(" - З якого елменту K розпочати", ref  K, (byte)Program.GArray.Length);
            Program.QuestionHandler(" - Скiльки елементiв T видалити", ref T);
            
            Program.GArray = EraseArrayFrom(K, T);
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
