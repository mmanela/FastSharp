using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FastSharpLib.Intellisense
{
    public interface IAutoComplete
    {
        void ReadAssembly(Assembly assembly);

        IEnumerable<string> FindMatches(string word);

        IEnumerable<string> FindExact(string word);
    }
}