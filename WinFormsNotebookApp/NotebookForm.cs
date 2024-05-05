namespace WinFormsNotebookApp
{
    public partial class NotebookForm : Form
    {
        List<Editor> editors = new();
        Editor editorCurrent;

        MainCommand fileNewCommand;
        MainCommand fileSaveCommand;
        MainCommand fileOpenCommand;

        public int Count { set; get; } = 0;

        public NotebookForm()
        {
            InitializeComponent();

            Editor editor = new Editor(++Count);
            editorCurrent = editor;
            editor.txtEditor.TextChanged += TxtEditor_TextChanged;
            
            editors.Add(editor);

            tabDocuments.Controls.Add(editor.tabPage);
            
        }

        

        private void NotebookForm_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem fileItem = new("File");
            ToolStripMenuItem fileNewItem = new("New");
            ToolStripMenuItem fileOpenItem = new("Open");
            ToolStripMenuItem fileSaveItem = new("Save");
            ToolStripMenuItem fileExitItem = new("Exit");

            fileItem.DropDownItems.Add(fileNewItem);
            fileItem.DropDownItems.Add(fileOpenItem);
            fileItem.DropDownItems.Add(fileSaveItem);
            fileItem.DropDownItems.Add(new ToolStripSeparator());
            fileItem.DropDownItems.Add(fileExitItem);

            ToolStripMenuItem viewItem = new("View");
            ToolStripMenuItem viewFontItem = new("Font");
            ToolStripMenuItem viewColorItem = new("Color");
            viewFontItem.Click += ViewFontItem_Click;
            viewColorItem.Click += ViewColorItem_Click;

            viewItem.DropDownItems.Add(viewFontItem);
            viewItem.DropDownItems.Add(viewColorItem);

            menuMain.Items.Add(fileItem);
            menuMain.Items.Add(viewItem);

            fileNewCommand = new MainCommand(obj =>
            {
                Editor editor = new(++Count);
                editor.txtEditor.TextChanged += TxtEditor_TextChanged;
                editors.Add(editor);

                editorCurrent = editor;
                tabDocuments.Controls.Add(editor.tabPage);
                tabDocuments.SelectedTab = editor.tabPage;
            });
            
            fileSaveCommand = new MainCommand(obj =>
            {
                if (obj is Editor editor)
                {
                    string fileName = "";

                    if (editorCurrent.FileName == "")
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                            return;
                        fileName = saveFileDialog.FileName;
                    }
                    else
                        fileName = editorCurrent.FileName;
                     
                    File.WriteAllText(fileName, editorCurrent.txtEditor.Text);
                    editorCurrent.tabPage.Text = fileName.Remove(0, fileName.LastIndexOf("\\") + 1);
                    editorCurrent.FileName = fileName;
                    if (editorCurrent.tabPage.Text.EndsWith(" *"))
                        editorCurrent.tabPage.Text
                        = editorCurrent.tabPage.Text.Remove(editorCurrent.tabPage.Text.Length - 2);
                }
            });

            fileOpenCommand = new MainCommand(obj =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                Editor editor = new();
                editor.FileName = openFileDialog.FileName;
                string text = File.ReadAllText(editor.FileName);

                editor.tabPage.Text = editor.FileName.Remove(0, editor.FileName.LastIndexOf("\\") + 1);
                editor.txtEditor.Text = text;
                editor.txtEditor.TextChanged += TxtEditor_TextChanged;

                editorCurrent = editor;
                tabDocuments.Controls.Add(editor.tabPage);
                tabDocuments.SelectedTab = editorCurrent.tabPage;

            });


            fileNewItem.Command = fileNewCommand;
            fileSaveItem.Command = fileSaveCommand;
            fileSaveItem.CommandParameter = editorCurrent;
            fileOpenItem.Command = fileOpenCommand;

            editorCurrent.txtEditor.Focus();
        }

        private void ViewColorItem_Click(object? sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            editorCurrent.txtEditor.BackColor = colorDialog.Color;
        }

        private void ViewFontItem_Click(object? sender, EventArgs e)
        {
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() == DialogResult.Cancel)
                return;
            editorCurrent.txtEditor.Font = fontDialog.Font;
            editorCurrent.txtEditor.ForeColor = fontDialog.Color;
        }


        private void TxtEditor_TextChanged(object? sender, EventArgs e)
        {
            if (!editorCurrent.tabPage.Text.EndsWith(" *"))
                editorCurrent.tabPage.Text += " *";
        }

        private void tabDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            editorCurrent.txtEditor.Focus();
        }

        private void tabDocuments_Selected(object sender, TabControlEventArgs e)
        {
            foreach (var editor in editors)
                if (editor.tabPage == e.TabPage)
                    editorCurrent = editor;
            editorCurrent.txtEditor.Focus();
        }
    }
}
