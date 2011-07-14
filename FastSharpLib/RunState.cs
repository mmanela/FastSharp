using System;

namespace FastSharpLib
{
    public class RunState
    {
        public RunState()
        {
            
        }

        public string Output { get; set; }
        public CompileState CompileState { get; set; }
        public Exception Exception { get; set; }

        public bool HasExecutionErrors { get; set; }
        public bool HasCompileErrors { get; set; }
    }
}