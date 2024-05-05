namespace WinFormsNotebookApp
{
    partial class NotebookForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotebookForm));
            menuMain = new MenuStrip();
            toolBar = new ToolStrip();
            statusBar = new StatusStrip();
            tabDocuments = new TabControl();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            fontDialog = new FontDialog();
            colorDialog = new ColorDialog();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(800, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // toolBar
            // 
            toolBar.Location = new Point(0, 24);
            toolBar.Name = "toolBar";
            toolBar.Size = new Size(800, 25);
            toolBar.TabIndex = 1;
            toolBar.Text = "toolStrip1";
            // 
            // statusBar
            // 
            statusBar.Location = new Point(0, 428);
            statusBar.Name = "statusBar";
            statusBar.Size = new Size(800, 22);
            statusBar.TabIndex = 2;
            statusBar.Text = "statusStrip1";
            // 
            // tabDocuments
            // 
            tabDocuments.Dock = DockStyle.Fill;
            tabDocuments.Location = new Point(0, 49);
            tabDocuments.Name = "tabDocuments";
            tabDocuments.SelectedIndex = 0;
            tabDocuments.Size = new Size(800, 379);
            tabDocuments.TabIndex = 3;
            tabDocuments.SelectedIndexChanged += tabDocuments_SelectedIndexChanged;
            tabDocuments.Selected += tabDocuments_Selected;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // NotebookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabDocuments);
            Controls.Add(statusBar);
            Controls.Add(toolBar);
            Controls.Add(menuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "NotebookForm";
            Text = "Notebook";
            Load += NotebookForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStrip toolBar;
        private StatusStrip statusBar;
        //private TabPage tabPage1;
        private TabControl tabDocuments;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private FontDialog fontDialog;
        private ColorDialog colorDialog;
    }
}
