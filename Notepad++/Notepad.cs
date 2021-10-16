using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Notepad__
{
    public partial class Notepad : Form
    {
        #region fields

        private bool isFileAlreadySave;
        private bool isFileDirty;
        private string currentOpenFileName;
        private FontDialog fontdialog = new FontDialog();

        #endregion fields

        public Notepad()
        {
            InitializeComponent();
        }

        private void buttonAddAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All Right Reserved with Marcus ", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            newFileMaMethod();
        }

        private void newFileMaMethod()
        {
            if (isFileDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to save changes ? ", "File Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                switch (result)
                {
                    case DialogResult.Yes:
                        savefilemanu();
                        break;

                    case DialogResult.No:
                        break;

                    case DialogResult.Cancel:
                        MessageBox.Show("Develop by Marcus ", "Go to New File", MessageBoxButtons.OK);
                        break;
                }
            }

            clearScreen();
            isFileAlreadySave = false;
            currentOpenFileName = "";
            EnableDisableUndoRedoProcessKaMethog(false);
            labelMessageStatus.Text = "New Document is Created ";
        }

        private void buttonAddExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAddOpen_Click(object sender, EventArgs e)
        {
            OpenKlyeMethod();
        }

        private void OpenKlyeMethod()
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|MSWord Files (*.docx)|*.docx|PHP (*.php)|*.php";

            DialogResult result = openfiledialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SaveFileExtension(openfiledialog.FileName);
                isFileAlreadySave = true;
                isFileDirty = false;
                currentOpenFileName = openfiledialog.FileName;

                EnableDisableUndoRedoProcessKaMethog(false);

                labelMessageStatus.Text = " File is Opened !";
            }
        }

        private void EnableDisableUndoRedoProcessKaMethog(bool enable)
        {
            buttonAddUndo.Enabled = enable;
            buttonAddRedo.Enabled = enable;
        }

        private void buttonAddSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsFileKaMethod();
        }

        private void SaveAsFileKaMethod()
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|MSWord Files (*.docx)|*.docx|PHP (*.php)|*.php";
            DialogResult result = savefiledialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                SaveFileExtension(savefiledialog.FileName);
                isFileAlreadySave = true;
                isFileDirty = false;
                currentOpenFileName = savefiledialog.FileName;
            }
        }

        private void buttonAddSave_Click(object sender, EventArgs e)
        {
            savefilemanu();
        }

        private void SaveFileExtension(string filename)
        {
            switch (Path.GetExtension(filename))
            {
                case ".txt":
                    TextEditor.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    break;

                case ".php":
                    TextEditor.SaveFile(filename, RichTextBoxStreamType.PlainText);
                    break;

                case ".rtf":
                    TextEditor.SaveFile(filename, RichTextBoxStreamType.RichText);
                    break;
            }
        }

        private void savefilemanu()
        {
            if (isFileAlreadySave)
            {
                SaveFileExtension(currentOpenFileName);
                isFileDirty = false;
            }
            else
            {
                if (isFileDirty)
                    SaveAsFileKaMethod();
                else
                    clearScreen();
            }
        }

        private void clearScreen()
        {
            TextEditor.Clear();
            isFileDirty = false;
        }

        private void Notepad_Load(object sender, EventArgs e)
        {
            labelMessageStatus.Text = " Normal Text File.. ";
            isFileAlreadySave = false;
            isFileDirty = false;
            currentOpenFileName = "";

            if (Control.IsKeyLocked(Keys.CapsLock))
                labelCaps.Text = " Caps ON";
            else
                labelCaps.Text = " Caps OFF";
        }

        private void TextEditor_TextChanged(object sender, EventArgs e)
        {
            isFileDirty = true;
            buttonAddUndo.Enabled = true;
            buttonUndo.Enabled = true;
            toolStripUndo.Enabled = true;
        }

        private void buttonAddUndo_Click(object sender, EventArgs e)
        {
            undoKlyeMethod();
        }

        private void undoKlyeMethod()
        {
            TextEditor.Undo();
            buttonAddRedo.Enabled = true;
            buttonRedo.Enabled = true;
            buttonUndo.Enabled = false;
            toolStripUndo.Enabled = false;
            toolStripRedo.Enabled = true;
            buttonAddUndo.Enabled = false;
        }

        private void buttonAddRedo_Click(object sender, EventArgs e)
        {
            redoKlyemethod();
        }

        private void redoKlyemethod()
        {
            TextEditor.Redo();
            buttonAddRedo.Enabled = false;
            buttonRedo.Enabled = false;
            buttonUndo.Enabled = true;
            toolStripUndo.Enabled = true;
            toolStripRedo.Enabled = false;
            buttonAddUndo.Enabled = true;
        }

        private void buttonAddSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login obj = new Login();
            obj.Show();
        }

        private void buttonAddSelectAll_Click(object sender, EventArgs e)
        {
            TextEditor.SelectAll();
        }

        private void buttonAddDateTime_Click(object sender, EventArgs e)
        {
            TextEditor.SelectedText = DateTime.Now.ToString();
        }

        private void buttonAddBold_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Bold);
        }

        private void buttonAddItalic_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Italic);
        }

        private void FontKlyeMethod(FontStyle fontstyleVeriable)
        {
            TextEditor.SelectionFont = new Font(TextEditor.SelectionFont, fontstyleVeriable);
        }

        private void buttonAddUnderline_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Underline);
        }

        private void buttonAddStrikethrough_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Strikeout);
        }

        private void buttonAddNormal_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Regular);
        }

        private void buttonAddFormatFont_Click(object sender, EventArgs e)
        {
            fontKlyeMethod();
        }

        private void fontKlyeMethod()
        {
            fontdialog.ShowColor = true;
            fontdialog.ShowApply = true;

            fontdialog.Apply += new System.EventHandler(fontdialog_apply);

            DialogResult result = fontdialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (TextEditor.SelectionLength > 0)
                {
                    TextEditor.SelectionFont = fontdialog.Font;
                    TextEditor.SelectionColor = fontdialog.Color;
                }
            }
        }

        private void fontdialog_apply(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
            {
                TextEditor.SelectionFont = fontdialog.Font;
                TextEditor.SelectionColor = fontdialog.Color;
            }
        }

        private void buttonAddChangeColor_Click(object sender, EventArgs e)
        {
            ColorDialog colordialog = new ColorDialog();
            DialogResult result = colordialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (TextEditor.SelectionLength > 0)
                {
                    TextEditor.SelectionColor = colordialog.Color;
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            newFileMaMethod();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenKlyeMethod();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            savefilemanu();
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsFileKaMethod();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            undoKlyeMethod();
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            redoKlyemethod();
        }

        private void buttonBold_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Bold);
        }

        private void buttonItalic_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Italic);
        }

        private void buttonUnderline_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Underline);
        }

        private void buttonStrikeout_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Strikeout);
        }

        private void buttonFormatFont_Click(object sender, EventArgs e)
        {
            fontKlyeMethod();
        }

        private void TextEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
                labelCaps.Text = " Caps ON";
            else
                labelCaps.Text = " Caps OFF";
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void toolStripBold_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Bold);
        }

        private void toolStripItalicOptions_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Italic);
        }

        private void toolStripUnderline_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Underline);
        }

        private void toolStripNormal_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Regular);
        }

        private void toolStripUndo_Click(object sender, EventArgs e)
        {
            undoKlyeMethod();
        }

        private void toolStripRedo_Click(object sender, EventArgs e)
        {
            redoKlyemethod();
        }

        private void buttonAddCut_Click(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
            {
                Clipboard.SetText(TextEditor.SelectedText);
                TextEditor.SelectedText = "";
            }
        }

        private void buttonAddCopy_Click(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
                TextEditor.Copy();
        }

        private void buttonAddPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                TextEditor.SelectedText = Clipboard.GetText();
            }
        }

        private void toolStripCut_Click(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
            {
                Clipboard.SetText(TextEditor.SelectedText);
                TextEditor.SelectedText = "";
            }
        }

        private void toolStripCopy_Click(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
                TextEditor.Copy();
        }

        private void toolStripPasteOptions_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                TextEditor.SelectedText = Clipboard.GetText();
        }

        private void buttonCut_Click(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
                Clipboard.SetText(TextEditor.SelectedText);
            TextEditor.SelectedText = "";
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (TextEditor.SelectionLength > 0)
                TextEditor.Copy();
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                TextEditor.SelectedText = Clipboard.GetText();
        }
    }
}