using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using FastSharpApplication.Properties;
using FastSharpLib;

namespace FastSharpApplication
{
    public partial class FastSharpForm : Form
    {
        private readonly FastSharp fastSharp = new FastSharp();
        private const string FormStateFileName = "FastSharpFormState.settings";

        private readonly IDictionary<CodeLanguage, string> languageToDisplayMap = new Dictionary<CodeLanguage, string>
                                                                                      {
                                                                                          {CodeLanguage.CSharp, "C#"},
                                                                                          {CodeLanguage.FSharp, "F#"},
                                                                                          {CodeLanguage.VisualBasic, "Visual Basic"}
                                                                                      };

        private readonly IDictionary<string, CodeLanguage> displayToLanguageMap = new Dictionary<string, CodeLanguage>();

        public FastSharpForm()
        {
            InitializeComponent();
            foreach (var pair in languageToDisplayMap)
                displayToLanguageMap.Add(pair.Value, pair.Key);

            foreach (var language in fastSharp.SupportedLanguages)
            {
                codeLanguageCombo.Items.Add(languageToDisplayMap[language]);
            }
        }

        private void SetDefaultLanguage()
        {
            codeLanguageCombo.SelectedItem = languageToDisplayMap[CodeLanguage.CSharp];
        }

        private void Compile()
        {
            var compileState = fastSharp.CompileSnippet(codeWindow.Text, null);
            ReportCompileState(compileState);
        }

        private void ReportCompileState(CompileState compileState)
        {
            if (compileState.HasErrors)
            {
                statusBar.BackColor = Color.Red;
                statusBar.ForeColor = Color.White;
                statusStrip1.BackColor = Color.Red;
                statusBar.Text = "Error during compiling";

                var sbErr = new StringBuilder("Compiling file: ");
                sbErr.AppendLine();
                sbErr.AppendLine();
                foreach (string error in compileState.Errors)
                    sbErr.AppendLine(error);

                errorWindow.Text = sbErr.ToString();
                tabControl.SelectedIndex = 1;
            }
            else
            {
                statusStrip1.BackColor = Color.Green;
                statusBar.BackColor = Color.Green;
                statusBar.ForeColor = Color.White;
                statusBar.Text = "Compiled Succesfully";
                errorWindow.Text = "";
            }
        }

        private void Run()
        {
            var runState = fastSharp.ExecuteSnippet(codeWindow.Text);
            ReportCompileState(runState.CompileState);

            if (runState.HasExecutionErrors || runState.HasCompileErrors)
            {
                if (runState.Exception != null)
                {
                    MessageBox.Show(runState.Exception.Message);
                }
            }
            else
            {
                DisplayOutput(runState.Output);
            }
        }

        private void compileButtonClick(object sender, EventArgs e)
        {
            Compile();
        }

        private void runButtonClick(object sender, EventArgs e)
        {
            Run();
        }

        private void DisplayOutput(string output)
        {
            outputWindow.Text = output;
            tabControl.SelectedIndex = 0;
        }

        private void saveButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                File.WriteAllText(saveFileDialog1.FileName, codeWindow.Text);
            }
        }

        private void openButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                codeWindow.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void codeWindow_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = false;
            if (e.KeyCode == Keys.S && e.Control)
            {
                saveButtonClick(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.O && e.Control)
            {
                openButtonClick(null, null);
                e.SuppressKeyPress = true;
            }
            else if ((e.KeyCode == Keys.E && e.Control) || e.KeyCode == Keys.F4)
            {
                Compile();
                e.SuppressKeyPress = true;
            }
            else if ((e.KeyCode == Keys.R && e.Control) || e.KeyCode == Keys.F5)
            {
                Run();
                e.SuppressKeyPress = true;
            }
        }

        private void aboutButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("FastSharpForm\nRapid .NET Scripting \nCreated by Matthew Manela", "About FastSharpForm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("You don't need any help, trust me.", "FastSharpForm Help");
        }

        private void settingsButtonClick(object sender, EventArgs e)
        {
            SettingsPage settingsPage = new SettingsPage(fastSharp);
            settingsPage.ShowDialog();
        }

        private void FastSharp_Load(object sender, EventArgs e)
        {
            var formState = LoadFormState();
            if (formState != null)
            {
                codeLanguageCombo.SelectedItem = languageToDisplayMap[formState.SelectedLanguage];
                codeWindow.Text = formState.CodeText;
            }
            else
            {
                SetDefaultLanguage();
            }
        }

        private void SaveFormState()
        {
            try
            {
                var formState = new FastSharpFormState
                                    {
                                        CodeText = codeWindow.Text,
                                        SelectedLanguage = displayToLanguageMap[(string) codeLanguageCombo.SelectedItem]
                                    };
                var isoStore = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var stream = new IsolatedStorageFileStream(FormStateFileName, FileMode.Create, isoStore))
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof (FastSharpFormState));
                    jsonSerializer.WriteObject(stream, formState);
                }
            }
            catch
            {
            }
        }

        private static FastSharpFormState LoadFormState()
        {
            try
            {
                var isoStore = IsolatedStorageFile.GetUserStoreForAssembly();
                using (var stream = new IsolatedStorageFileStream(FormStateFileName, FileMode.Open, isoStore))
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof (FastSharpFormState));
                    var result = jsonSerializer.ReadObject(stream) as FastSharpFormState;
                    if (result != null)
                        return result;
                }
            }
            catch
            {
            }

            return null;
        }

        private void fontButtonClick(object sender, EventArgs e)
        {
            if (DialogResult.OK == codeFontDialog.ShowDialog())
            {
                Settings.Default.CodeWindowFont = codeFontDialog.Font;
                Settings.Default.Save();
            }
        }

        private void codeLanguageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var language = displayToLanguageMap[(string) codeLanguageCombo.SelectedItem];
            fastSharp.SetProvider(language);
        }

        private void FastSharpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveFormState();
        }
    }
}