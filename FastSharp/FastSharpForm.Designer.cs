namespace FastSharpApplication
{
    partial class FastSharpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStrip toolStrip1;
            System.Windows.Forms.ToolStripButton saveButton;
            System.Windows.Forms.ToolStripButton openButton;
            System.Windows.Forms.ToolStripButton compileButton;
            System.Windows.Forms.ToolStripButton runButton;
            System.Windows.Forms.ToolStripButton helpButton;
            System.Windows.Forms.ToolStripButton aboutButton;
            System.Windows.Forms.ToolStripButton settingsButton;
            System.Windows.Forms.ToolStripButton fontButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastSharpForm));
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.codeLanguageCombo = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.codeOutputSplit = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.codeWindow = new System.Windows.Forms.RichTextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.outputTab = new System.Windows.Forms.TabPage();
            this.outputWindow = new System.Windows.Forms.RichTextBox();
            this.errorTab = new System.Windows.Forms.TabPage();
            this.errorWindow = new System.Windows.Forms.RichTextBox();
            this.codeFontDialog = new System.Windows.Forms.FontDialog();
            this.suggestionsBox = new System.Windows.Forms.ListBox();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            saveButton = new System.Windows.Forms.ToolStripButton();
            openButton = new System.Windows.Forms.ToolStripButton();
            compileButton = new System.Windows.Forms.ToolStripButton();
            runButton = new System.Windows.Forms.ToolStripButton();
            helpButton = new System.Windows.Forms.ToolStripButton();
            aboutButton = new System.Windows.Forms.ToolStripButton();
            settingsButton = new System.Windows.Forms.ToolStripButton();
            fontButton = new System.Windows.Forms.ToolStripButton();
            toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.codeOutputSplit)).BeginInit();
            this.codeOutputSplit.Panel1.SuspendLayout();
            this.codeOutputSplit.Panel2.SuspendLayout();
            this.codeOutputSplit.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.outputTab.SuspendLayout();
            this.errorTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            saveButton,
            openButton,
            this.toolStripSeparator1,
            compileButton,
            runButton,
            helpButton,
            aboutButton,
            this.toolStripSeparator3,
            this.codeLanguageCombo,
            settingsButton,
            fontButton});
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            toolStrip1.Size = new System.Drawing.Size(1218, 33);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // saveButton
            // 
            saveButton.Image = global::FastSharpApplication.Properties.Resources.saveHS;
            saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(77, 30);
            saveButton.Text = "&Save";
            saveButton.Click += new System.EventHandler(this.saveButtonClick);
            // 
            // openButton
            // 
            openButton.Image = global::FastSharpApplication.Properties.Resources.openHS;
            openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            openButton.Name = "openButton";
            openButton.Size = new System.Drawing.Size(84, 30);
            openButton.Text = "&Open";
            openButton.Click += new System.EventHandler(this.openButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // compileButton
            // 
            compileButton.Image = global::FastSharpApplication.Properties.Resources.CopyHS;
            compileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            compileButton.Name = "compileButton";
            compileButton.Size = new System.Drawing.Size(106, 30);
            compileButton.Text = "Compile";
            compileButton.Click += new System.EventHandler(this.compileButtonClick);
            // 
            // runButton
            // 
            runButton.Image = global::FastSharpApplication.Properties.Resources.DataContainer_MoveNextHS;
            runButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            runButton.Name = "runButton";
            runButton.Size = new System.Drawing.Size(71, 30);
            runButton.Text = "Run";
            runButton.Click += new System.EventHandler(this.runButtonClick);
            // 
            // helpButton
            // 
            helpButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            helpButton.DoubleClickEnabled = true;
            helpButton.Image = global::FastSharpApplication.Properties.Resources.Help;
            helpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            helpButton.Name = "helpButton";
            helpButton.Size = new System.Drawing.Size(77, 30);
            helpButton.Text = "Help";
            helpButton.Click += new System.EventHandler(this.helpButtonClick);
            // 
            // aboutButton
            // 
            aboutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            aboutButton.Image = global::FastSharpApplication.Properties.Resources.Information;
            aboutButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            aboutButton.Name = "aboutButton";
            aboutButton.Size = new System.Drawing.Size(90, 30);
            aboutButton.Text = "About";
            aboutButton.Click += new System.EventHandler(this.aboutButtonClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // codeLanguageCombo
            // 
            this.codeLanguageCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codeLanguageCombo.Name = "codeLanguageCombo";
            this.codeLanguageCombo.Size = new System.Drawing.Size(180, 33);
            this.codeLanguageCombo.SelectedIndexChanged += new System.EventHandler(this.codeLanguageCombo_SelectedIndexChanged);
            // 
            // settingsButton
            // 
            settingsButton.Image = global::FastSharpApplication.Properties.Resources.OptionsHS;
            settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new System.Drawing.Size(104, 30);
            settingsButton.Text = "Settings";
            settingsButton.Click += new System.EventHandler(this.settingsButtonClick);
            // 
            // fontButton
            // 
            fontButton.Image = global::FastSharpApplication.Properties.Resources.Font;
            fontButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            fontButton.Name = "fontButton";
            fontButton.Size = new System.Drawing.Size(76, 30);
            fontButton.Text = "Font";
            fontButton.Click += new System.EventHandler(this.fontButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 33);
            this.statusStrip1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1218, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.statusBar.AutoSize = false;
            this.statusBar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusBar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1195, 17);
            this.statusBar.Spring = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "C# Files|*.cs|Text Files|*.txt|All Files|*.*";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "FastSharpForm Save";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "FastSharpForm";
            this.openFileDialog1.Filter = "C# Files|*.cs|Text Files|*.txt|All Files|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "FastSharpForm Open";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "Critical.bmp");
            this.imageList1.Images.SetKeyName(1, "EditCodeHS.png");
            // 
            // codeOutputSplit
            // 
            this.codeOutputSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeOutputSplit.Location = new System.Drawing.Point(0, 55);
            this.codeOutputSplit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.codeOutputSplit.Name = "codeOutputSplit";
            this.codeOutputSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // codeOutputSplit.Panel1
            // 
            this.codeOutputSplit.Panel1.Controls.Add(this.groupBox1);
            // 
            // codeOutputSplit.Panel2
            // 
            this.codeOutputSplit.Panel2.Controls.Add(this.tabControl);
            this.codeOutputSplit.Size = new System.Drawing.Size(1218, 894);
            this.codeOutputSplit.SplitterDistance = 639;
            this.codeOutputSplit.SplitterWidth = 6;
            this.codeOutputSplit.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.suggestionsBox);
            this.groupBox1.Controls.Add(this.codeWindow);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1218, 639);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Code";
            // 
            // codeWindow
            // 
            this.codeWindow.AcceptsTab = true;
            this.codeWindow.DataBindings.Add(new System.Windows.Forms.Binding("Font", global::FastSharpApplication.Properties.Settings.Default, "CodeWindowFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codeWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeWindow.Font = global::FastSharpApplication.Properties.Settings.Default.CodeWindowFont;
            this.codeWindow.Location = new System.Drawing.Point(4, 24);
            this.codeWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.codeWindow.Name = "codeWindow";
            this.codeWindow.ShowSelectionMargin = true;
            this.codeWindow.Size = new System.Drawing.Size(1210, 610);
            this.codeWindow.TabIndex = 0;
            this.codeWindow.Text = "";
            this.codeWindow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codeWindow_KeyDown);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.outputTab);
            this.tabControl.Controls.Add(this.errorTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.ImageList = this.imageList1;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1218, 249);
            this.tabControl.TabIndex = 6;
            // 
            // outputTab
            // 
            this.outputTab.Controls.Add(this.outputWindow);
            this.outputTab.ImageIndex = 1;
            this.outputTab.Location = new System.Drawing.Point(4, 32);
            this.outputTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputTab.Name = "outputTab";
            this.outputTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputTab.Size = new System.Drawing.Size(1210, 213);
            this.outputTab.TabIndex = 0;
            this.outputTab.Text = "Output";
            this.outputTab.UseVisualStyleBackColor = true;
            // 
            // outputWindow
            // 
            this.outputWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputWindow.Location = new System.Drawing.Point(4, 5);
            this.outputWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputWindow.Name = "outputWindow";
            this.outputWindow.ReadOnly = true;
            this.outputWindow.Size = new System.Drawing.Size(1202, 203);
            this.outputWindow.TabIndex = 1;
            this.outputWindow.Text = "";
            // 
            // errorTab
            // 
            this.errorTab.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.errorTab.Controls.Add(this.errorWindow);
            this.errorTab.ImageIndex = 0;
            this.errorTab.Location = new System.Drawing.Point(4, 32);
            this.errorTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.errorTab.Name = "errorTab";
            this.errorTab.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.errorTab.Size = new System.Drawing.Size(1210, 207);
            this.errorTab.TabIndex = 1;
            this.errorTab.Text = "Errors";
            this.errorTab.UseVisualStyleBackColor = true;
            // 
            // errorWindow
            // 
            this.errorWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorWindow.Location = new System.Drawing.Point(4, 5);
            this.errorWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.errorWindow.Name = "errorWindow";
            this.errorWindow.ReadOnly = true;
            this.errorWindow.Size = new System.Drawing.Size(1202, 197);
            this.errorWindow.TabIndex = 2;
            this.errorWindow.Text = "";
            // 
            // codeFontDialog
            // 
            this.codeFontDialog.Font = global::FastSharpApplication.Properties.Settings.Default.CodeWindowFont;
            this.codeFontDialog.ShowColor = true;
            // 
            // suggestionsBox
            // 
            this.suggestionsBox.FormattingEnabled = true;
            this.suggestionsBox.ItemHeight = 20;
            this.suggestionsBox.Location = new System.Drawing.Point(31, 48);
            this.suggestionsBox.Name = "suggestionsBox";
            this.suggestionsBox.Size = new System.Drawing.Size(120, 84);
            this.suggestionsBox.Sorted = true;
            this.suggestionsBox.TabIndex = 1;
            this.suggestionsBox.Visible = false;
            // 
            // FastSharpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 949);
            this.Controls.Add(this.codeOutputSplit);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FastSharpForm";
            this.Text = "FastSharpForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FastSharpForm_FormClosing);
            this.Load += new System.EventHandler(this.FastSharp_Load);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.codeOutputSplit.Panel1.ResumeLayout(false);
            this.codeOutputSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.codeOutputSplit)).EndInit();
            this.codeOutputSplit.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.outputTab.ResumeLayout(false);
            this.errorTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FontDialog codeFontDialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SplitContainer codeOutputSplit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox codeWindow;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage outputTab;
        private System.Windows.Forms.RichTextBox outputWindow;
        private System.Windows.Forms.TabPage errorTab;
        private System.Windows.Forms.RichTextBox errorWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel statusBar;
        private System.Windows.Forms.ToolStripComboBox codeLanguageCombo;
        private System.Windows.Forms.ListBox suggestionsBox;
    }
}

