using System;
using System.Windows.Forms;
using FastSharpLib;

namespace FastSharpApplication
{
    public partial class SettingsPage : Form
    {
        private readonly FastSharp fastSharp;

        public SettingsPage()
        {
        }

        public SettingsPage(FastSharp fastSharp)
        {
            this.fastSharp = fastSharp;
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {
            referenceBox.Text = String.Empty;
            importsBox.Text = String.Empty;

            foreach (string line in fastSharp.ActiveLanguageProvider.Settings.References)
            {
                referenceBox.AppendText(line + Environment.NewLine);
            }

            foreach (string line in fastSharp.ActiveLanguageProvider.Settings.Imports)
            {
                importsBox.AppendText(line + Environment.NewLine);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            fastSharp.ActiveLanguageProvider.Settings.Imports.Clear();
            foreach (var line in importsBox.Lines)
                if (!string.IsNullOrEmpty(line.Trim()))
                    fastSharp.ActiveLanguageProvider.Settings.Imports.Add(line);

            fastSharp.ActiveLanguageProvider.Settings.References.Clear();
            foreach (var line in referenceBox.Lines)
                if (!string.IsNullOrEmpty(line.Trim()))
                    fastSharp.ActiveLanguageProvider.Settings.References.Add(line);

            fastSharp.ActiveLanguageProvider.SaveSettingsToDisk();
            Close();
        }
    }
}