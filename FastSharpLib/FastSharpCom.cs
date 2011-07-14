using System.Runtime.InteropServices;
using System.Text;

namespace FastSharpLib
{

    [ComVisible(true), GuidAttribute("FC3F083C-C689-4de8-8187-C62CBFE67A18")]
    [ProgId("Jemts.FastSharpCom")]
    [ClassInterface(ClassInterfaceType.None)]
    public class FastSharpCom : IFastSharpCom
    {
        private readonly FastSharp fastSharp;

        public FastSharpCom()
        {
            fastSharp = new FastSharp();
            fastSharp.SetProvider(CodeLanguage.CSharp);
        }

        public FastSharpComResult ExecuteSnippet(string snippet)
        {
            var fastSharpResult = new FastSharpComResult();
            var runResult = fastSharp.ExecuteSnippet(snippet);
            if (runResult.HasCompileErrors)
            {
                var sb = new StringBuilder();
                foreach (var error in runResult.CompileState.Errors)
                    sb.AppendLine(error);

                fastSharpResult.HasErrors = true;
                fastSharpResult.Output = sb.ToString();
            }
            else if (runResult.HasExecutionErrors)
            {
                fastSharpResult.HasErrors = true;
                fastSharpResult.Output = runResult.Exception == null ? "An error occured" : runResult.Exception.Message;
            }
            else
            {
                fastSharpResult.Output = runResult.Output;
            }

            return fastSharpResult;
        }

        public FastSharpComResult CompileSnippet(string snippet)
        {
            var fastSharpResult = new FastSharpComResult();
            var runResult = fastSharp.CompileSnippet(snippet,null);
            if (runResult.HasErrors)
            {
                var sb = new StringBuilder();
                foreach (var error in runResult.Errors)
                    sb.AppendLine(error);

                fastSharpResult.HasErrors = true;
                fastSharpResult.Output = sb.ToString();
            }

            return fastSharpResult;
        }
    }
}