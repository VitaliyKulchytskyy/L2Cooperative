using System;

namespace CooperativeLab
{
    class PartA_Block1 : Block
    {
        private const byte m_variant = 10;

        private byte IndexOfTheFistMinElement()
        {
            int min = Program.GArray[0];
            byte index = 0;

            for (byte i = 0; i < Program.GArray.Length; i++)
            {
                if (Program.GArray[i] < min)
                {
                    min = Program.GArray[i];
                    index = i;
                }
            }

            return index;
        }

        private byte IndexOfTheLastMaxElement()
        {
            int max = Program.GArray[0];
            byte index = 0;

            for (byte i = 0; i < Program.GArray.Length; i++)
            {
                if (Program.GArray[i] >= max)
                {
                    max = Program.GArray[i];
                    index = i;
                }
            }

            return index;
        }

        public override void ProcessData()    
        {
            if (Program.GArray.Length <= 1)
                throw new Exception("NotEnoughValuesException");

            byte min = IndexOfTheFistMinElement();
            byte max = IndexOfTheLastMaxElement();
            byte fBorder = Math.Min(min, max);
            byte lBorder = Math.Max(min, max);

            if (Program.GArray[fBorder] == Program.GArray[lBorder])
                throw new Exception("BadResizeException");

            for (byte i = fBorder; i <= lBorder; i++)
                Program.GArray[i - fBorder] = Program.GArray[i];
            Array.Resize(ref Program.GArray, lBorder - fBorder + 1);
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
