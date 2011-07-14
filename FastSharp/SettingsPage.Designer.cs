namespace FastSharpApplication
{
    partial class SettingsPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.importsGroupBox = new System.Windows.Forms.GroupBox();
            this.importsBox = new System.Windows.Forms.TextBox();
            this.referencesGroupBox = new System.Windows.Forms.GroupBox();
            this.referenceBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.importsGroupBox.SuspendLayout();
            this.referencesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 63);
            this.panel1.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(526, 21);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(95, 33);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(640, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(95, 33);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.importsGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.referencesGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(747, 470);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // importsGroupBox
            // 
            this.importsGroupBox.Controls.Add(this.importsBox);
            this.importsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importsGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.importsGroupBox.Name = "importsGroupBox";
            this.importsGroupBox.Size = new System.Drawing.Size(342, 466);
            this.importsGroupBox.TabIndex = 0;
            this.importsGroupBox.TabStop = false;
            this.importsGroupBox.Text = "Imports";
            // 
            // importsBox
            // 
            this.importsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.importsBox.Location = new System.Drawing.Point(3, 22);
            this.importsBox.Multiline = true;
            this.importsBox.Name = "importsBox";
            this.importsBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.importsBox.Size = new System.Drawing.Size(336, 441);
            this.importsBox.TabIndex = 2;
            // 
            // referencesGroupBox
            // 
            this.referencesGroupBox.CausesValidation = false;
            this.referencesGroupBox.Controls.Add(this.referenceBox);
            this.referencesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.referencesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referencesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.referencesGroupBox.Name = "referencesGroupBox";
            this.referencesGroupBox.Size = new System.Drawing.Size(389, 466);
            this.referencesGroupBox.TabIndex = 0;
            this.referencesGroupBox.TabStop = false;
            this.referencesGroupBox.Text = "References";
            // 
            // referenceBox
            // 
            this.referenceBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.referenceBox.Location = new System.Drawing.Point(3, 22);
            this.referenceBox.Multiline = true;
            this.referenceBox.Name = "referenceBox";
            this.referenceBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.referenceBox.Size = new System.Drawing.Size(383, 441);
            this.referenceBox.TabIndex = 2;
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 533);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsPage";
            this.Text = "SettingsPage";
            this.Load += new System.EventHandler(this.SettingsPage_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.importsGroupBox.ResumeLayout(false);
            this.importsGroupBox.PerformLayout();
            this.referencesGroupBox.ResumeLayout(false);
            this.referencesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox importsGroupBox;
        private System.Windows.Forms.TextBox importsBox;
        private System.Windows.Forms.GroupBox referencesGroupBox;
        private System.Windows.Forms.TextBox referenceBox;
    }
}