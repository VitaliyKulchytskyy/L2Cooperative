namespace CooperativeLab
{
    class PartC : Part
    {
        private const string m_author = "Сухобрус Антон";

        public PartC(Block[] Block) : base(Block) { }
        public override string GetAuthor() => m_author;
    }
}
