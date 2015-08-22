using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FastSharpLib.Intellisense
{
    public class AutoComplete : IAutoComplete
    {
        private TreeView TreeViewList { get; set; }

        public AutoComplete(TreeView treeView)
        {
            TreeViewList = treeView;
        }

        public void ReadAssembly(Assembly assembly)
        {
            Type[] assemblyTypes = assembly.GetTypes();
            // Cycle through types
            foreach (Type type in assemblyTypes)
            {
                TreeViewList.RegisterType(type);
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

            TreeNode node = TreeViewList.Nodes.FindNode(word);
            if (node == null || node.Nodes.Count <= 0)
            {
                yield break;
            }

            foreach (TreeNode leafNode in node.Nodes)
            {
                yield return leafNode.Text;
            }
        }
    }
}