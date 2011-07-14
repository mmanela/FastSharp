using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace FastSharpLib.LanguageProviders
{
    public class VisualBasicLanguageProvider : CodeLanguageProvider
    {
        private VBCodeProvider codeDomProvider;
        protected override CodeDomProvider CodeDomProvider
        {
            get
            {
                if (codeDomProvider == null)
                    codeDomProvider = new VBCodeProvider(Settings.ProviderOptions);
                return codeDomProvider;
            }
        }

        public VisualBasicLanguageProvider()
            : base(CodeLanguage.VisualBasic)
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
                              "Imports Microsoft.VisualBasic",
                              "Imports System",
                              "Imports System.Collections.Generic",
                              "Imports System.ComponentModel",
                              "Imports System.Data",
                              "Imports System.Drawing",
                              "Imports System.Text",
                              "Imports System.Windows.Forms",
                              "Imports System.Reflection",
                              "Imports System.CodeDom.Compiler",
                              "Imports System.IO",
                              "Imports System.Xml",
                              "Imports System.Globalization",
                              "Imports System.Collections",
                              "Imports System.Security",
                              "Imports System.Threading",
                              "Imports System.Timers",
                              "Imports System.Diagnostics",
                              "Imports System.Net",
                              "Imports System.Linq",
                              "Imports System.Text.RegularExpressions",
                          };
            Settings.ProviderOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
        }


        public override CodeSnippet WrapSnippet(string snippet, string consoleOutBufferPath)
        {
            var buffer = new StringBuilder();
            foreach (var import in Settings.Imports)
            {
                buffer.AppendLine(import);
                
            }
            buffer.AppendLine("Module FastSharp");
            buffer.AppendLine("Sub Main()");
            if (!string.IsNullOrEmpty(consoleOutBufferPath)) 
                AppendConsoleOutStart(buffer, consoleOutBufferPath);
            AppendTryCatchStart(buffer);
            buffer.AppendLine(snippet);
            AppendTryCatchEnd(buffer);
            if (!string.IsNullOrEmpty(consoleOutBufferPath)) 
                AppendConsoleOutEnd(buffer);
            buffer.AppendLine("End Sub");
            buffer.AppendLine("End Module");

            int lineOffset = Settings.Imports.Count;
            if (string.IsNullOrEmpty(consoleOutBufferPath))
                lineOffset += 3;
            else
                lineOffset += 6;

            return new CodeSnippet {LineOffset = lineOffset, Source = buffer.ToString()};
        }


        private void AppendConsoleOutStart(StringBuilder buffer, string bufferOutFile)
        {
            buffer.AppendLine("Dim fOut As FileStream = New FileStream(\"" + bufferOutFile + "\", FileMode.Create)");
            buffer.AppendLine("Dim sOut As StreamWriter = New StreamWriter(fOut)");
            buffer.AppendLine("Console.SetOut(sOut)");
        }


        private void AppendConsoleOutEnd(StringBuilder buffer)
        {
            buffer.AppendLine("sOut.Close()");
            buffer.AppendLine("fOut.Close()");
        }

        private void AppendTryCatchStart(StringBuilder buffer)
        {
            buffer.AppendLine("Try");
        }
        private void AppendTryCatchEnd(StringBuilder buffer)
        {
            buffer.AppendLine("Catch e As Exception");
            buffer.AppendLine("Console.WriteLine(\"Exception Occured: \" &  e.Message)");
            buffer.AppendLine("End Try");
        }
    }
}