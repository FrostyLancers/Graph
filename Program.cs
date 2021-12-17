using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Node
    {
        public string Name;
        public Node Left;
        public Node Right;

        public Node(string name)
        {
            this.Name = name;
        }
    }

    class Program
    {
        static List<Node> AllNodeName = new List<Node>();

        static void Main(string[] args)
        {
            Console.Write("How many Node do you want? : ");
            int NumofVertex = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the Node's name (in string): ");
            
            for (int i = 1; i <= NumofVertex; i++)
            {
                string Vertex = Console.ReadLine();
                Node NodeName = new Node(Vertex);
                AllNodeName.Add(NodeName);
            }
            
            SettheAdjacent();
        }

        static void SettheAdjacent()
        {
            int index = 0;
            int lastIndex = AllNodeName.Count - 1;
            List<Node> Visited = new List<Node>();
            Queue<Node> Graph = new Queue<Node>();
            Node CurrentNode;

            for (int j = 1; j <= lastIndex - 1; j++)
            {
                Node ThisNode = AllNodeName.ElementAt(index);

                if (index != AllNodeName.Count - 1)
                {
                    ThisNode.Left = AllNodeName.ElementAt(index + 1);
                }

                if (index != AllNodeName.Count - 2)
                {
                    ThisNode.Right = AllNodeName.ElementAt(index + 2);
                }

                Graph.Enqueue(ThisNode);

                while (Graph.Count != 0)
                {
                    CurrentNode = Graph.Dequeue();
                }

                if (Visited.Contains(ThisNode) == false)
                {
                    Graph.Enqueue(ThisNode.Left);
                    Graph.Enqueue(ThisNode.Right);
                    Visited.Add(ThisNode);
                }
                index++;
            }

            Console.WriteLine(Graph.Dequeue().ToString());
        }
    }
}
