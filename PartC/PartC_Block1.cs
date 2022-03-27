using System;

namespace CooperativeLab
{
    class PartC_Block1 : Block
    {
        private const byte m_variant = 1;

        public override void ProcessData()
        {
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
