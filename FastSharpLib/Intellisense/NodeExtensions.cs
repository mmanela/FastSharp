using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FastSharpLib.Intellisense
{
    public static class NodeExtensions
    {

        /// <summary>
        /// Searches the tree until the given path is found, storing
        /// the found node in a member var.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        public static INode FindNode(this INode node, string name)
        {
            return node.DeepSearch(name);
        }

        /// <summary>
        /// Takes an LoadedAssembly filename, opens it and retrieves all types.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="type">Type</param>
        public static void RegisterType(this INode node, Type type)
        {
            if (string.IsNullOrWhiteSpace(type.Namespace))
            {
                // skip anonymous types
                return;
            }

            node.AddOrGet(type.Name, type.Namespace);
        }
    }
}