using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FastSharpLib.Intellisense
{
    public static class TreeExtensions
    {

        /// <summary>
        /// Searches the tree until the given path is found, storing
        /// the found node in a member var.
        /// </summary>
        /// <param name="treeNodes"></param>
        /// <param name="path"></param>
        public static TreeNode FindNode(this TreeNodeCollection treeNodes, string path)
        {
            for (int i = 0; i < treeNodes.Count; i++)
            {
                if (treeNodes[i].FullPath == path)
                {
                    return treeNodes[i];
                }

                if (treeNodes[i].Nodes.Count > 0)
                {
                    return FindNode(treeNodes[i].Nodes, path);
                }
            }

            return null;
        }

        /// <summary>
        /// Takes an LoadedAssembly filename, opens it and retrieves all types.
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="type">Type</param>
        public static void RegisterType(this TreeView treeView, Type type)
        {
            Hashtable Namespaces = new Hashtable();
            if (type.Namespace == null)
            {
                return;
            }

            if (Namespaces.ContainsKey(type.Namespace))
            {
                // Already got namespace, add the class to it
                TreeNode treeNode = (TreeNode)Namespaces[type.Namespace];
                treeNode = treeNode.Nodes.Add(type.Name);
                treeNode.AddMembers(type);

                if (type.IsClass)
                {
                    treeNode.Tag = MemberTypes.Custom;
                }
            }
            else
            {
                // New namespace
                TreeNode membersNode = null;

                if (type.Namespace.IndexOf(".") != -1)
                {
                    // Search for already existing parts of the namespace
                    TreeNode NameSpaceNode = treeView.Nodes.SearchTree(type.Namespace, false);

                    // No existing namespace found
                    if (NameSpaceNode == null)
                    {
                        // Add the namespace
                        string[] parts = type.Namespace.Split('.');

                        TreeNode treeNode = treeView.Nodes.Add(parts[0]);
                        string sNamespace = parts[0];

                        if (!Namespaces.ContainsKey(sNamespace))
                        {
                            Namespaces.Add(sNamespace, treeNode);
                        }

                        for (int i = 1; i < parts.Length; i++)
                        {
                            treeNode = treeNode.Nodes.Add(parts[i]);
                            sNamespace += "." + parts[i];
                            if (!Namespaces.ContainsKey(sNamespace))
                            {
                                Namespaces.Add(sNamespace, treeNode);
                            }
                        }

                        membersNode = treeNode.Nodes.Add(type.Name);
                    }
                    else
                    {
                        // Existing namespace, add this namespace to it,
                        // and add the class
                        string[] parts = type.Namespace.Split('.');
                        TreeNode newNamespaceNode = null;

                        if (!Namespaces.ContainsKey(type.Namespace))
                        {
                            newNamespaceNode = NameSpaceNode.Nodes.Add(parts[parts.Length - 1]);
                            Namespaces.Add(type.Namespace, newNamespaceNode);
                        }
                        else
                        {
                            newNamespaceNode = (TreeNode)Namespaces[type.Namespace];
                        }

                        if (newNamespaceNode != null)
                        {
                            membersNode = newNamespaceNode.Nodes.Add(type.Name);
                            if (type.IsClass)
                            {
                                membersNode.Tag = MemberTypes.Custom;
                            }
                        }
                    }
                }
                else
                {
                    // Single root namespace, add to root
                    membersNode = treeView.Nodes.Add(type.Namespace);
                }

                // Add all members
                if (membersNode != null)
                {
                    membersNode.AddMembers(type);
                }
            }
        }

        /// <summary>
        /// Adds all members to the node's children, grabbing the parameters
        /// for methods.
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="type"></param>
        public static void AddMembers(this TreeNode treeNode, Type type)
        {
            // Get all members except methods
            MemberInfo[] memberInfo = type.GetMembers();
            for (int j = 0; j < memberInfo.Length; j++)
            {
                if (memberInfo[j].ReflectedType.IsPublic && memberInfo[j].MemberType != MemberTypes.Method)
                {
                    TreeNode node = treeNode.Nodes.Add(memberInfo[j].Name);
                    node.Tag = memberInfo[j].MemberType;
                }
            }

            // Get all methods
            MethodInfo[] methodInfo = type.GetMethods();
            for (int j = 0; j < methodInfo.Length; j++)
            {
                TreeNode node = treeNode.Nodes.Add(methodInfo[j].Name);
                string parms = "";

                ParameterInfo[] parameterInfo = methodInfo[j].GetParameters();
                for (int f = 0; f < parameterInfo.Length; f++)
                {
                    parms += parameterInfo[f].ParameterType + " " + parameterInfo[f].Name + ", ";
                }

                // Knock off remaining ", "
                if (parms.Length > 2)
                {
                    parms = parms.Substring(0, parms.Length - 2);
                }

                node.Tag = parms;
            }
        }

        /// <summary>
        /// Searches the tree view for a namespace, saving the node. The method
        /// stops and returns as soon as the namespace search can't find any
        /// more items in its path, unless continueUntilFind is true.
        /// </summary>
        /// <param name="treeNodes"></param>
        /// <param name="path"></param>
        /// <param name="continueUntilFind"></param>
        /// <param name="currentPath"></param>
        internal static TreeNode SearchTree(this TreeNodeCollection treeNodes, string path, bool continueUntilFind, string currentPath = "")
        {
            string p;
            int n;
            n = path.IndexOf(".");

            if (n != -1)
            {
                p = path.Substring(0, n);

                if (currentPath != "")
                {
                    currentPath += "." + p;
                }
                else
                {
                    currentPath = p;
                }

                // Knock off the first part
                path = path.Remove(0, n + 1);
            }
            else
            {
                currentPath += "." + path;
            }

            for (int i = 0; i < treeNodes.Count; i++)
            {
                if (treeNodes[i].FullPath == currentPath)
                {
                    if (!continueUntilFind)
                    {
                        return treeNodes[i];
                    }

                    // got a dot, continue, or return
                    return SearchTree(treeNodes[i].Nodes, path, true);

                }
                else if (!continueUntilFind)
                {
                    return null;
                }
            }

            return null;
        }
    }
}