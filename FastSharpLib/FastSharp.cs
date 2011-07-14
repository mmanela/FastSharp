using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using FastSharpLib.LanguageProviders;

namespace FastSharpLib
{
    public class FastSharp
    {
        public CodeLanguageProvider ActiveLanguageProvider { get; private set; }
        private readonly IList<CodeLanguageProvider> languageProviders;

        public IEnumerable<CodeLanguage> SupportedLanguages
        {
            get { return languageProviders.Where(x => x.CanLoadProvider).Select(x => x.Language); }
        }

        public FastSharp()
        {
            languageProviders = new List<CodeLanguageProvider>
                                    {
                                        new CSharpLanguageProvider(),
                                        new FSharpLanguageProvider(),
                                        new VisualBasicLanguageProvider(),
                                    };
        }

        public CodeLanguageProvider GetLanguageProvider(CodeLanguage language)
        {
            return languageProviders.SingleOrDefault(x => x.Language == language);
        }

        public void SetProvider(CodeLanguage language)
        {
            ActiveLanguageProvider = GetLanguageProvider(language);
        }

        public CompileState CompileSnippet(string snippet, string consoleBufferOutPath)
        {
            var executableSnippet = ActiveLanguageProvider.WrapSnippet(snippet, consoleBufferOutPath);
            var compilerResults = ActiveLanguageProvider.Compile(executableSnippet.Source);

            var result = new CompileState();
            result.CompilerResults = compilerResults;
            result.HasErrors = compilerResults.Errors.HasErrors;

            if (compilerResults.Errors.HasErrors)
                foreach (CompilerError err in compilerResults.Errors)
                    result.Errors.Add(string.Format("{0} at line {1} column {2} ", err.ErrorText, err.Line - executableSnippet.LineOffset, err.Column));

            return result;
        }

        public RunState ExecuteSnippet(string snippet)
        {
            var runState = new RunState();
            string consoleBufferOutPath;
            try
            {
                consoleBufferOutPath = Path.GetTempFileName();
            }
            catch (IOException ex)
            {
                runState.HasExecutionErrors = true;
                runState.Exception = ex;
                return runState;
            }


            var compileState = CompileSnippet(snippet, consoleBufferOutPath);
            runState.CompileState = compileState;
            if (!compileState.HasErrors)
            {
                Assembly a = compileState.CompilerResults.CompiledAssembly;
                try
                {
                    object o = a.CreateInstance("FastSharpScript");
                    MethodInfo mi = a.EntryPoint;
                    mi.Invoke(o, null);
                }
                catch (Exception ex)
                {
                    runState.Exception = ex;
                    runState.HasExecutionErrors = true;
                }

                try
                {
                    runState.Output = File.ReadAllText(consoleBufferOutPath);
                }
                catch (IOException ex)
                {
                    runState.HasExecutionErrors = true;
                    runState.Exception = ex;
                    return runState;
                }
            }
            else
            {
                runState.HasCompileErrors = true;
            }


            return runState;
        }

    }
}