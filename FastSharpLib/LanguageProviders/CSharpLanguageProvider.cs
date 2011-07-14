using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp;

namespace FastSharpLib.LanguageProviders
{
    public class CSharpLanguageProvider : CodeLanguageProvider
    {
        private CSharpCodeProvider codeDomProvider;
        protected override CodeDomProvider CodeDomProvider
        {
            get
            {
                if (codeDomProvider == null)
                    codeDomProvider = new CSharpCodeProvider(Settings.ProviderOptions);
                return codeDomProvider;
            }
        }

        public CSharpLanguageProvider() : base(CodeLanguage.CSharp)
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
                                 "microsoft.csharp.dll",
                             };

            Settings.Imports = new List<string>
                          {
                              "using System;",
                              "using System.Collections.Generic;",
                              "using System.ComponentModel;",
                              "using System.Data;",
                              "using System.Drawing;",
                              "using System.Text;",
                              "using System.Windows.Forms;",
                              "using System.Reflection;",
                              "using System.CodeDom.Compiler;",
                              "using Microsoft.CSharp;",
                              "using System.IO;",
                              "using System.Xml;",
                              "using System.Globalization;",
                              "using System.Collections;",
                              "using System.Security;",
                              "using System.Threading;",
                              "using System.Timers;",
                              "using System.Diagnostics;",
                              "using System.Net;",
                              "using System.Linq;",
                              "using System.Text.RegularExpressions;",
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
            buffer.AppendLine("namespace FastSharp");
            buffer.AppendLine("{");
            buffer.AppendLine("class CSharpScript {");
            buffer.AppendLine("static void Main() {");
            if (!string.IsNullOrEmpty(consoleOutBufferPath)) 
                AppendConsoleOutStart(buffer, consoleOutBufferPath);
            AppendTryCatchStart(buffer);
            buffer.AppendLine(snippet);
            AppendTryCatchEnd(buffer);
            if (!string.IsNullOrEmpty(consoleOutBufferPath)) 
                AppendConsoleOutEnd(buffer);
            buffer.AppendLine("}}}");

            int lineOffset = Settings.Imports.Count;
            if (string.IsNullOrEmpty(consoleOutBufferPath))
                lineOffset += 5;
            else
                lineOffset += 8;

            return new CodeSnippet {LineOffset = lineOffset, Source = buffer.ToString()};
        }


        private void AppendConsoleOutStart(StringBuilder buffer, string bufferOutFile)
        {
            buffer.AppendLine("FileStream fOut = new FileStream(@\"" + bufferOutFile + "\", FileMode.Create);");
            buffer.AppendLine("StreamWriter sOut = new StreamWriter(fOut);");
            buffer.AppendLine("Console.SetOut(sOut);");
        }


        private void AppendConsoleOutEnd(StringBuilder buffer)
        {
            buffer.AppendLine("sOut.Close();");
            buffer.AppendLine("fOut.Close();");
        }

        private void AppendTryCatchStart(StringBuilder buffer)
        {
            buffer.AppendLine("try{");
        }
        private void AppendTryCatchEnd(StringBuilder buffer)
        {
            buffer.AppendLine("} catch(Exception e) {");
            buffer.AppendLine(" Console.WriteLine(\"Exception Occured: \" +  e.Message);  }");
        }
    }
}