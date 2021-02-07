using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FastSharpLib.Intellisense
{
    public class AutoComplete : IAutoComplete
    {
        private INode Root { get; set; }

        public AutoComplete(INode root = null)
        {
            Root = root ?? Node.CreateRoot();
        }

        public void ReadAssembly(Assembly assembly)
        {
            Type[] assemblyTypes = assembly.GetTypes();
            // Cycle through types
            foreach (Type type in assemblyTypes)
            {
                Root.RegisterType(type);
            }
        }

        /// <summary>
        /// Called when a "." is pressed - the previous word is found,
        /// and if matched in the treeview, the members listbox is
        /// populated with items from the tree, which are first sorted.
        /// </summary>
        /// <returns>Whether an items are found for the word</returns>
        public  IEnumerable<string> FindMatches(string word)
        {
            if (word == "")
            {
                yield break;
            }

            INode node = Root.FindNode(word);
            if (node == null)
            {
                yield break;
            }

            foreach (INode match in node.Children)
            {
                yield return match.Name;
            }
        }

        /// <summary>
        /// Called when a "." is pressed - the previous word is found,
        /// and if matched in the treeview, the members listbox is
        /// populated with items from the tree, which are first sorted.
        /// </summary>
        /// <returns>Whether an items are found for the word</returns>
        public  IEnumerable<string> FindExact(string word)
        {
            if (word == "")
            {
                yield break;
            }

            INode node = Root.FindNode(word);
            if (node == null)
            {
                yield break;
            }

            yield return node.Name;
        }
    }
}