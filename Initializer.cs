using NotePad_Metro.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
{
    abstract class Initializer
    {
        public static void Init(RichTextBox editor, RichTextBox errorLog, ListBox suggestionBox)
        {
            Utility.Init(editor, errorLog, suggestionBox);
            KeyEventsHandler.Init(editor, errorLog, suggestionBox);
            TokenGenerator.InitBox(editor);
            Highlighter.Init(editor);
            SuggestionProvider.InitSuggestionProvider(new List<string>(), suggestionBox, editor);
            Coloring.InitColoring(editor);
            Helper.Init();
            MenuItemEvents.Init(editor);
        }
    }
}
