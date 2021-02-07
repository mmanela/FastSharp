using System.Collections.Generic;

namespace FastSharpLib.Intellisense
{
    public interface INode
    {
        string Name { get; }

        INode Parent { get; }

        ICollection<INode> Children { get; }

        IDictionary<string, INode> Data { get; }

        INode AddOrGet(string name);

        INode AddOrGet(string name, string path);

        INode Search(string name);

        INode SearchPath(string path);

        INode DeepSearch(string name);
    }
}