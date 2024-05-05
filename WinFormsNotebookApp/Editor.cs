using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsNotebookApp
{
    public class Editor
    {
        public TabPage tabPage { get; } = new TabPage();
        public TextBox txtEditor { get; } = new TextBox();

        public bool ControlPress { set; get; } = false;
       
        //public bool IsSave { set; get; } = false;
        public string FileName { set; get; } = "";

        public Editor(int count = 0)
        {
            tabPage.Text = "New Document " + count.ToString();

            txtEditor.Multiline = true;
            txtEditor.Dock = DockStyle.Fill;
            txtEditor.ScrollBars = ScrollBars.Both;

            txtEditor.MouseWheel += TxtEditor_MouseWheel;
            txtEditor.KeyDown += TxtEditor_KeyDown;
            txtEditor.KeyUp += TxtEditor_KeyUp;

            tabPage.Controls.Add(txtEditor);
        }

        private void TxtEditor_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (sender is not TextBox)
                return;
            var txtEditor = (TextBox)sender;

            if (!ControlPress)
                return;
            Font oldFont = txtEditor.Font;
            Font font;

            if (e.Delta > 0)
                font = new Font(oldFont.FontFamily, oldFont.Size + 1, oldFont.Style);
            else
                font = new Font(oldFont.FontFamily, oldFont.Size - 1, oldFont.Style);
            txtEditor.Font = font;
        }

        private void TxtEditor_KeyUp(object? sender, KeyEventArgs e)
        {
            if (ControlPress)
                ControlPress = false;
        }

        private void TxtEditor_KeyDown(object? sender, KeyEventArgs e)
        {
            ControlPress = e.Control;
        }
    }


}
