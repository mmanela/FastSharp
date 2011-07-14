using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace FastSharpLib
{
    public class CompileState
    {
        public CompileState()
        {
            Errors = new List<string>();
        }

        public bool HasErrors { get; set; }
        public List<string> Errors { get; set; }
        public CompilerResults CompilerResults { get; set; }
    }
}