using System;

namespace CooperativeLab
{
    class PartB_Block3 : Block
    {
        private const byte m_variant = 11;

        public override void ProcessData()
        {
        }

        public override byte GetBlockVariant() => m_variant;
    }
}
