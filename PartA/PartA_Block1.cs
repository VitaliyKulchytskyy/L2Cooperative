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
            byte firstBorder = Math.Min(min, max);
            byte lastBorder  = Math.Max(min, max);

            if (Program.GArray[firstBorder] == Program.GArray[lastBorder])
                throw new Exception("BadResizeException");
            
            byte i = (byte) (firstBorder + 1), j = lastBorder;
            while (j < Program.GArray.Length)
                Program.GArray[i++] = Program.GArray[j++];
            
            Array.Resize(ref Program.GArray, firstBorder + 1 + (Program.GArray.Length - lastBorder));
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
