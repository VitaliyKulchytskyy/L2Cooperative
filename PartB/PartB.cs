namespace CooperativeLab
{
    class PartB : Part
    {
        private const string m_author = "Линник Ярослав";

        public PartB(Block[] Block) : base(Block) { }
        public override string GetAuthor() => m_author;
    }
}
