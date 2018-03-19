using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro.Logical
{
    class SuggestionProvider
    {
        private static List<string> keywordList;
        private static ListBox suggestionBox;
        private static RichTextBox editor;

        public static void InitSuggestionProvider(List<string> keywords, ListBox box, RichTextBox textBox)
        {
            SuggestionHelper sg = new SuggestionHelper();
            keywords = sg.GetSuggestionList();
            keywordList = keywords;

            suggestionBox = box;
            editor = textBox;
        }

        public static void GetSuggestion(string key)
        {
            if (keywordList.Any(str => str.Contains(key.Trim())))
            {
                foreach (string s in keywordList)
                {
                    if (s.StartsWith(key))
                    {
                        if (!suggestionBox.Items.Contains(s))
                        {
                            suggestionBox.Items.Add(s);
                        }
                    }
                }
            }

            else
            {
                suggestionBox.Items.Clear();
            }
        }

        public static string GetItem()
        {
            return suggestionBox.SelectedItem.ToString();
        }
    }

}
