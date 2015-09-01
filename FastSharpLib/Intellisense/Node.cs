using System;
using System.Collections.Generic;
using System.Linq;

namespace FastSharpLib.Intellisense
{
    public class Node : INode
    {
        public static char PathSeparator = '.';

        public string Name { get; protected set; }

        public INode Parent { get; protected set; }

        public ICollection<INode> Children { get { return Data.Values; } }

        public IDictionary<string, INode> Data { get; protected set; }

        private Node()
        {
            Data = new Dictionary<string, INode>(StringComparer.OrdinalIgnoreCase);
        }

        public static INode CreateRoot()
        {
            return new Node { Name = "." };
        }

        public INode AddOrGet(string name, string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }

            INode node = this;
            string[] parts = path.Split(new [] { PathSeparator, }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                node = node.AddOrGet(part);
            }

            return node.AddOrGet(name);
        }

        public INode AddOrGet(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            INode node = new Node
            {
                Name = name,
                Parent = this
            };

            if (Data.ContainsKey(name))
            {
                return Data[name];
            }
            else
            {
                Data[name] = node;
            }

            return node;
        }

        public INode SearchPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path");
            }

            INode node = this;
            string[] parts = path.Split(new[] { PathSeparator, }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                node = node.Search(part);
            }

            return node;
        }

        public INode Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            if (Data.ContainsKey(name))
            {
                return Data[name];
            }

            return null;
        }

        public INode DeepSearch(string name)
        {
            INode match = Data.Values.FirstOrDefault(k => k.Name.Contains(name));
            if (match != null)
            {
                return match;
            }

            foreach (INode node in Data.Values)
            {
                INode temp = node.DeepSearch(name);
                if (temp != null)
                {
                    return temp;
                }
            }

            return null;
        }
    }
}