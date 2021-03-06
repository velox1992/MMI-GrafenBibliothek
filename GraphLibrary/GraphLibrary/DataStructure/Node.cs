﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphLibrary.DataStructure
{
    interface INode
    {
        
        int Id { get; }

        List<NodeEdge> NeighbourEdges { get; }

        void AddEdge(Edge _Edge);

        void FindNeighbours();

        List<int> GetNeighbourIds();

        void RemoveEdge(Edge _Edge);
    }

    class Node : INode
    {
        private List<Edge> FEdges;

        public int Id { get; }

        private List<NodeEdge> FNeighbours;
        public List<NodeEdge> NeighbourEdges
        {
            get
            {
                FindNeighbours();
                return FNeighbours;
            }
        }

        public Node(int _Id)
        {
            Id = _Id;
            FEdges = new List<Edge>();
        }


        public void AddEdge(Edge _Edge)
        {
            FEdges.Add(_Edge);
        }

        public void RemoveEdge(Edge _Edge)
        {
            FEdges.Remove(_Edge);
        }


            /// <summary>
            ///  Inspiziert die Kanten und sichert diese mit den entsprechend gefunden Nachbarknoten ab.
            /// </summary>
            public void FindNeighbours()
        {
            FNeighbours = new List<NodeEdge>();

            var hNeighbours = new List<INode>();
            foreach (var hEdge in FEdges)
            {
                var hPossibleNeighbour = hEdge.GetOtherEndpoint(this);
                if (hPossibleNeighbour != null)
                {
                    var hNewNeighourInfo = new NodeEdge(hPossibleNeighbour,hEdge);
                    FNeighbours.Add(hNewNeighourInfo);
                }
            } 

        }

        public List<int> GetNeighbourIds()
        {
            var hNeighbourIds = new List<int>();

            foreach (var hNeighbour in NeighbourEdges)
            {
                hNeighbourIds.Add(hNeighbour.Node.Id);
            }

            return hNeighbourIds;
        }
    }

    class BalancedNode : Node
    {
        public double Balance { get; set; }
        public BalancedNode(int _Id, double _Balance)
            : base(_Id)
        {
            Balance = _Balance;
        }
    }
}
