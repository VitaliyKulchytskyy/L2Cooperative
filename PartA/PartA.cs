namespace CooperativeLab
{
    class PartA : Part
    {
        private const string m_author = "Кульчицький Вiталiй";

        public PartA(Block[] Block) : base(Block) { }      
        public override string GetAuthor() => m_author;
    }
}
