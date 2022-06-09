using Antlr4.Runtime;

namespace Zirconium
{
    public class ZirconiumErrorStrategy: DefaultErrorStrategy
    {
        public override void Recover(Parser recognizer, RecognitionException e)
        {
            switch (e.Context)
            {
                case ZirconiumParser.UsingStatementContext:
                    break;
                default:
                    base.Recover(recognizer, e);
                    break;
            }
            
        }
    }
}