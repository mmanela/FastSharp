using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using Microsoft.FSharp.Compiler.CodeDom;

namespace FastSharpLib.LanguageProviders
{
    public class FSharpLanguageProvider : CodeLanguageProvider
    {

        private FSharpCodeProvider codeDomProvider;
        protected override CodeDomProvider CodeDomProvider
        {
            get
            {
                if (codeDomProvider == null)
                    codeDomProvider = new FSharpCodeProvider();
                return codeDomProvider;
            }
        }

        public FSharpLanguageProvider()
            : base(CodeLanguage.FSharp)
        {
            InitializeDefaultSettings();
            LoadSettingsFromDisk();
        }

        private void InitializeDefaultSettings()
        {
            Settings = new LanguageProviderSettings();
            Settings.References = new List<string>
                             {
                                 "system.dll",
                                 "system.xml.dll",
                                 "system.data.dll",
                                 "system.security.dll",
                                 "system.drawing.dll",
                                 "system.deployment.dll",
                                 "system.windows.forms.dll",
                                 "system.data.linq.dll",
                                 "system.core.dll",
                             };

            Settings.Imports = new List<string>
                          {
                              "open System",
                              "open System.Collections.Generic",
                              "open System.ComponentModel",
                              "open System.Data",
                              "open System.Drawing",
                              "open System.Text",
                              "open System.Windows.Forms",
                              "open System.Reflection",
                              "open System.CodeDom.Compiler",
                              "open System.IO",
                              "open System.Xml",
                              "open System.Globalization",
                              "open System.Collections",
                              "open System.Security",
                              "open System.Threading",
                              "open System.Timers",
                              "open System.Diagnostics",
                              "open System.Net",
                              "open System.Linq",
                              "open System.Text.RegularExpressions",
                          };
        }


        public override CodeSnippet WrapSnippet(string snippet, string consoleOutBufferPath)
        {
            var buffer = new StringBuilder();
            foreach (var import in Settings.Imports)
            {
                buffer.AppendLine(import);
                
            }
            buffer.AppendLine("module FastSharp =");
            if (!string.IsNullOrEmpty(consoleOutBufferPath)) 
                AppendConsoleOutStart(buffer, consoleOutBufferPath);
            AppendTryCatchStart(buffer);
            buffer.Append(Indent(snippet, 4));
            AppendTryCatchEnd(buffer);
            if (!string.IsNullOrEmpty(consoleOutBufferPath)) 
                AppendConsoleOutEnd(buffer);

            int lineOffset = Settings.Imports.Count;
            if (string.IsNullOrEmpty(consoleOutBufferPath))
                lineOffset += 2;
            else
                lineOffset += 5;

            return new CodeSnippet {LineOffset = lineOffset, Source = buffer.ToString()};
        }

        private string Indent(string text, int spaces)
        {
            var builder = new StringBuilder();
            foreach(var line in text.Split(new[]{Environment.NewLine, "\n"},StringSplitOptions.None))
            {
                builder.AppendLine(" ".PadLeft(spaces) + line);
            }
            return builder.ToString();
        }

        private void AppendConsoleOutStart(StringBuilder buffer, string bufferOutFile)
        {
            buffer.AppendLine("    let fOut = new FileStream(@\"" + bufferOutFile + "\", FileMode.Create)");
            buffer.AppendLine("    let sOut = new StreamWriter(fOut)");
            buffer.AppendLine("    Console.SetOut(sOut)");
        }


        private void AppendConsoleOutEnd(StringBuilder buffer)
        {
            buffer.AppendLine("    sOut.Close()");
            buffer.AppendLine("    fOut.Close()");
        }

        private void AppendTryCatchStart(StringBuilder buffer)
        {
            buffer.AppendLine("    try");
        }
        private void AppendTryCatchEnd(StringBuilder buffer)
        {
            buffer.AppendLine("    printf \"\"");
            buffer.AppendLine("    with e ->");
            buffer.AppendLine("        printf \"Exception Occured: %s\" e.Message");
        }
    }
}