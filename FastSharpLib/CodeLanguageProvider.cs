using System;
using System.CodeDom.Compiler;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security;

namespace FastSharpLib
{
    public abstract class CodeLanguageProvider
    {
        public LanguageProviderSettings Settings { get; set; }
        protected abstract CodeDomProvider CodeDomProvider { get; }
        public CodeLanguage Language { get; private set; }
        public abstract CodeSnippet WrapSnippet(string snippet, string consoleOutBufferPath);

        private readonly string settingsFileName;

        public bool CanLoadProvider
        {
            get
            {
                try
                {
                    var provider = CodeDomProvider;
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        private void SetReferences(CompilerParameters options)
        {
            options.ReferencedAssemblies.Clear();

            foreach (string refToAdd in Settings.References)
            {
                options.ReferencedAssemblies.Add(refToAdd);
            }
        }

        protected CodeLanguageProvider(CodeLanguage language)
        {
            Language = language;
            settingsFileName = string.Format("FastSharp.{0}.settings", Language);
        }

        public CompilerResults Compile(string source)
        {
            var options = new CompilerParameters
                              {
                                  GenerateExecutable = true,
                                  GenerateInMemory = true,
                                  IncludeDebugInformation = true,
                              };

            SetReferences(options);
            return CodeDomProvider.CompileAssemblyFromSource(options, source);
        }

        public void LoadSettingsFromDisk()
        {
            try
            {
                var isoStore = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var stream = new IsolatedStorageFileStream(settingsFileName, FileMode.Open, isoStore))
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof (LanguageProviderSettings));
                    var result = jsonSerializer.ReadObject(stream) as LanguageProviderSettings;
                    if (result != null)
                        Settings = result;
                }
            }
            catch (IOException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (SerializationException)
            {
            }
        }

        public void SaveSettingsToDisk()
        {
            try
            {
                var isoStore = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var stream = new IsolatedStorageFileStream(settingsFileName, FileMode.Create, isoStore))
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof (LanguageProviderSettings));
                    jsonSerializer.WriteObject(stream, Settings);
                }
            }
            catch (IOException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (SerializationException)
            {
            }
        }
    }
}