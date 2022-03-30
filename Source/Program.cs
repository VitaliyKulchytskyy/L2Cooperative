namespace CooperativeLab
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Block[] blocksOfA = { new PartA_Block1(), new PartA_Block3() };
            Block[] blocksOfB = { new PartB_Block1(), new PartB_Block3() };
            Block[] blocksOfC = { new PartC_Block1(), new PartC_Block3() };
            Part[] parts = { new PartA(blocksOfA), new PartB(blocksOfB), new PartC(blocksOfC) };

            byte variant = 0, block = 0;
            QuestionType command = QuestionType.SetBlock;
            
            while(true) 
            {
                switch (command)
                {
                    case QuestionType.SetBlock:
                        SetBlock(ref block);
                        goto case QuestionType.ChangeArray; // fall through

                    case QuestionType.ChangeArray:
                        /*
                         * Заповнення відбуваєтья залежно від блоку:
                         * Якщо вказаний 0 блок, то заповнюємо GArray
                         * Інакше (1 блок) заповнюємо GJArray
                         */
                        FillArrayHandler(block);
                        goto case QuestionType.ChooseStatement;

                    case QuestionType.DoMethod:
                        SetVariant(ref variant, block, parts);
                        ProcessDataHandler(variant, block, parts);
                        goto case QuestionType.ChooseStatement;

                    case QuestionType.PrintArray:
                        PrintArrayHandler(variant, block, parts);
                        goto case QuestionType.ChooseStatement;

                    case QuestionType.ChooseStatement:
                        command = GetNextCommand();
                        break;
                }
            }
        }
    }
}