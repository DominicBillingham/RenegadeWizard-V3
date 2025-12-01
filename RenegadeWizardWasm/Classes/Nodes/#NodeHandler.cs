using RenegadeWizard.Classes.Data;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace RenegadeWizard.Classes.Nodes
{
    public class NodeHandler
    {
        public List<Node> NodeList { get; set; } = new();
        public Node? CurrentNode { get; set; } = null;

        public NodeHandler()
        {
            var intro = new Opening();
            NodeList.Add(intro);
            CurrentNode = intro;
        }

        public CommandResponse SwapNode(string[] input)
        {
            foreach (Node node in NodeList)
            {
                if (InputHelper.FuzzyMatch(node.Names, input))
                {
                    CurrentNode = node;
                    return node.Auto();
                }

            }

            return new CommandResponse();
        }

        public CommandResponse CheckNodeKeywords(string[] input)
        {
            if (CurrentNode == null) { return new CommandResponse(); }

            foreach (var keyWord in CurrentNode.Keywords)
            {
                if (InputHelper.FuzzyMatch(keyWord.Synonyms, input))
                {
                    return keyWord.Response();
                }
            }

            return CurrentNode.Fallback();

        }
    }

    public abstract class Node
    {
        public virtual List<string> Names { get; set; } = new();
        public virtual List<KeyWords> Keywords { get; set; } = new();
        public virtual CommandResponse Auto() { return new CommandResponse(); }
        public virtual CommandResponse Fallback() { return new CommandResponse(); }
        public virtual int Counter { get; set; } = 0;

    }

    public class KeyWords
    {
        public List<string> Synonyms { get; set; }
        public Func<CommandResponse>? Response { get; set; }
        public KeyWords(IEnumerable<string> keywords, Func<CommandResponse> response)
        {
            Synonyms = keywords.ToList();
            Response = response;
        }

    }

}
