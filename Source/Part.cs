namespace CooperativeLab
{
    abstract class Part
    {
        public Block[] Block { get; }
        public Part(Block[] Block)
        {
            this.Block = Block;
        }
        public abstract string GetAuthor();
    }
}
