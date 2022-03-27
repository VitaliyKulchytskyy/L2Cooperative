using System;

namespace CooperativeLab
{
    class PartC_Block3 : Block
    {
        private const byte m_variant = 13;

        public override void ProcessData()
        {
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
