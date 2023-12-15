using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Node
{
    // Propriedade para obter o rótulo do nó.
    public string Label { get; private set; }

    public Node(string label)
    {
        this.Label = label;
    }
    
    public Node()
    {
        
    }
    // Lista privada de arestas associadas a este nó.
    private List<Edge> _edges = new List<Edge>();

    // Propriedade pública para obter a lista de arestas.
    public List<Edge> Edges => _edges;

    // Propriedade pública para obter informações sobre os vizinhos deste nó.
    public List<NeighborhoodInfo> Neighbors =>
        Edges.Select(edge => new NeighborhoodInfo(
            edge.Node1 == this ? edge.Node2 : edge.Node1,
            edge.Value
        )).ToList();

    // Método privado para associar uma aresta ao nó.
    private void Assign(Edge edge)
    {
        _edges.Add(edge);
    }

    // Método público para conectar este nó a outro nó com um valor de conexão especificado.
    public void ConnectTo(Node other)
    {
        Edge.Create(1, this, other);
    }

    // Classe serializável que armazena informações sobre a vizinhança de um nó.
    [Serializable]
    public class NeighborhoodInfo
    {
        public Node Node;
        public int WeightToNode;

        // Construtor que inicializa as informações da vizinhança.
        public NeighborhoodInfo(Node node, int weightToNode)
        {
            Node = node;
            WeightToNode = weightToNode;
        }
    }

    // Classe serializável que representa uma aresta entre dois nós.
    [Serializable]
    public class Edge
    {
        // Valor associado à aresta.
        public int Value;
        // Nós conectados pela aresta.
        public Node Node1;
        public Node Node2;

        // Construtor privado para criar uma instância de Edge.
        private Edge(int value, Node node1, Node node2)
        {
            // Verifica se o valor da aresta é positivo.
            if (value <= 0)
            {
                throw new ArgumentException("Edge value needs to be positive.");
            }
            Value = value;
            Node1 = node1;
            node1.Assign(this);
            Node2 = node2;
            node2.Assign(this);
        }

        // Método estático para criar uma instância de Edge.
        public static Edge Create(int value, Node node1, Node node2)
        {
            return new Edge(value, node1, node2);
        }
    }
}
