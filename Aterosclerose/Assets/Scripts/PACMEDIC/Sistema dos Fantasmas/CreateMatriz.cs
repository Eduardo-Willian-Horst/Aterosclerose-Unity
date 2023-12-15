using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.Tilemaps;


public class CreateMatriz : MonoBehaviour
{   
    public List<Node> ListaDosNodos;
    private int[,] MatrizDeLocais;
    public Tilemap tilemap;
    private int indices = 0;
    // Posição que você deseja verificar
    public Vector3Int positionToCheck;
    private Node NodeAtual;
    private Node NodeReferencia;
    private Dijkstra dijkstra;

    public GameObject Prefab;
   
    
    // Start is called before the first frame update
    void Start()
    {
        MatrizDeLocais = new int[19, 35];
        ListaDosNodos = new List<Node>();
        CriaMatriz();
        CriaGrafo();

        CalculaMenorRota();
        
    }

    private void CriaMatriz()
    {
        for (int c = -1; c <= 33; c++)
        {
           for (int l = 7; l >= -11; l--)
            {
                positionToCheck = new Vector3Int(c, l, 0);
                if (tilemap.GetTile(positionToCheck) == null)
                {
                    // Fazer algo se não achar nada
                    MatrizDeLocais[l + 11, c + 1] = ++indices;
                    ListaDosNodos.Add(new Node(indices.ToString()));
                }
                else
                {
                    // Se achar algo, faz outra coisa
                    MatrizDeLocais[l + 11, c + 1] = 0;
                }
            }
        }
        
        
    //printPrimeiraLinha();
    }

    //void printPrimeiraLinha(){
   //    for(int i = 0; i < 35; i++){
    //        Debug.Log(MatrizDeLocais[18,i]);
    //    }
    //}

    private void CriaGrafo()
    {
        for(int c = 0; c < 34; c++)
        {
            for(int l = 0; l < 18; l++)
            {
                if(MatrizDeLocais[l, c] != 0)
                {   
                    
                    if(MatrizDeLocais[l+1, c] > 0){
                        NodeAtual = ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l, c].ToString())];
                        NodeReferencia = ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l+1, c].ToString())];
                        NodeAtual.ConnectTo(NodeReferencia);
                        ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l, c].ToString())] = NodeAtual;
                        ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l+1, c].ToString())] = NodeReferencia;
                    }
                    if(MatrizDeLocais[l, c+1] > 0){
                        NodeAtual = ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l, c].ToString())];
                        NodeReferencia = ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l, c+1].ToString())];
                        NodeAtual.ConnectTo(NodeReferencia);
                        ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l, c].ToString())] = NodeAtual;
                        ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == MatrizDeLocais[l, c+1].ToString())] = NodeReferencia;
                    }
                }
                
            }
        }

    } 


    private void CalculaMenorRota()
    {
        dijkstra = GetComponent<Dijkstra>();
        Node[] shortestPath = dijkstra.FindShortestPath(ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == "1")],ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == "21")]);

        /* foreach (Node nodeInPath in shortestPath)
        {
            //Faça algo com cada nó no caminho, como marcá-lo, movimentar um personagem, etc.
            Debug.Log("Node in path: " + nodeInPath.Label);
        } */
    }
}
