using System;

namespace FastSharpLib.Intellisense
{
    public static class StringExtensions
    {
        /// <summary>
        /// Searches backwards from the current caret position, until
        /// a space or newline or dot is found.
        /// </summary>
        /// <returns>The previous word from the carret position</returns>
        public static string GetPreviousWord(this string text, int selectionStart)
        {
            string word = "";

            int pos = selectionStart;
            if (pos > 1)
            {
                char f = new char();
                while (f != ' ' && f != 10 && f != '.' && pos > 0)
                {
                    pos--;
                    string tmp = text.Substring(pos, 1);
                    f = tmp[0];
                    word += f;
                }

                char[] ca = word.ToCharArray();
                Array.Reverse(ca);
                word = new String(ca);

            }

            return word.Trim();
        }
    }
}