using NotePad_Metro.Logical;
using NotePad_Metro.Refactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
{
    class KeyEventsHandler
    {
        public static bool controlKeyPressed;
        private static RichTextBox editor;
        private static RichTextBox errorLog;
        private static ListBox suggestionList;

        public static void Init(RichTextBox ed, RichTextBox er, ListBox sg)
        {
            editor = ed;
            errorLog = er;
            suggestionList = sg;
            controlKeyPressed = false;
        }

        public static void EditorKeyHandler(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Back:
                    Utility.RemoveFromTemp();
                    break;
                case Keys.Tab:
                    break;
                case Keys.Enter:
                    Utility.AddNewLineObj();
                    break;
                case Keys.Escape:
                    break;
                case Keys.Space:
                    Utility.ClearTemp();
                    suggestionList.Items.Clear();
                    break;
                case Keys.End:
                    break;
                case Keys.Home:
                    break;
                case Keys.Left:
                    break;
                case Keys.Up:
                    break;
                case Keys.Right:
                    break;
                case Keys.Down:
                    suggestionList.Focus();
                    suggestionList.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        public static void EditorKeyHandler(char KeyChar)
        {
            switch (KeyChar)
            {
                default:
                    break;
            }
        }

        public static void SuggestionKeyHandler(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Enter:
                    string textToInsert = SuggestionProvider.GetItem();
                    int indexToRemove = editor.Text.Length - Utility.GetTemp().Length;
                    Utility.FocusEditor();
                    Utility.RemoveTextFromEditor(indexToRemove);
                    Utility.AppendWordToEditor(textToInsert);
                    Utility.AddSpaceAfterText();
                    break;
                case Keys.Escape:
                    editor.Focus();
                    suggestionList.Items.Clear();
                    break;
                default:
                    break;
            }
        }

        public static void EditorMulitpleKeyPressHandler(Keys key)
        {
            switch (key)
            {
                case Keys.K:
                    Utility.CommentCode();
                    break;
                case Keys.S:
                    MenuItemEvents.SaveFile();
                    break;
                case Keys.O:
                    MenuItemEvents.OpenFile();
                    break;
                case Keys.R:
                    MenuItemEvents.Run();
                    break;
            }
        }
    }
}
