using System.Collections.Generic;
using Zirconium.AST;

namespace Zirconium
{
    public class CompilationPassInfo
    {
        private List<CompilationError> errors = new List<CompilationError>();
        private List<CompilationWarning> warnings = new List<CompilationWarning>();
        public IReadOnlyList<CompilationError> Errors => errors;
        public IReadOnlyList<CompilationWarning> Warnings => warnings;

        public void AddError(string message, AbstractNode sourceNode)
        {
            errors.Add(new CompilationError(message,sourceNode));
        }

        public void AddError(string message, string file, int line, int column, int endLine, int endColumn)
        {
            errors.Add(new CompilationError(message,file,line,column,endLine,endColumn));
        }

        public void AddWarning(string message, AbstractNode sourceNode)
        {
            warnings.Add(new CompilationWarning(message,sourceNode));
        }
        
        public void AddWarning(string message, string file, int line, int column, int endLine, int endColumn)
        {
            warnings.Add(new CompilationWarning(message,file,line,column,endLine,endColumn));
        }
        
    }
}