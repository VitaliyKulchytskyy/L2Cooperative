using System;

namespace CooperativeLab
{
    class PartB_Block1 : Block
    {
        private const byte m_variant = 5;

        public override void ProcessData()
        {
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
