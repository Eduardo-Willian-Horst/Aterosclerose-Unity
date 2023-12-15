using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private CreateMatriz CriadorDaMatriz;
    private List<Node> ListaDosNodos;
    private Node PosicaoInicial;
    private Node PosicaoFinal;
    private Dijkstra dijkstra;

    // Start is called before the first frame update
    void Start()
    {   
        PosicaoFinal = new Node();
        PosicaoInicial = new Node();
        ListaDosNodos = new List<Node>();

        dijkstra = GetComponent<Dijkstra>();
        StartCoroutine(Executa());
        
        
    }

    private void PontosDeAncoragem()
    {
        PosicaoInicial = ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == "1")];
        PosicaoFinal = ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == "14")];
        PosicaoFinal.ConnectTo(PosicaoInicial);
        
    }


    IEnumerator Executa(){
        yield return new WaitForSeconds(2f);
        this.ListaDosNodos = CriadorDaMatriz.ListaDosNodos;
        
        PontosDeAncoragem();
        Debug.Log(ListaDosNodos.Count);
        Debug.Log(ListaDosNodos[0]);
        Node[] shortestPath = dijkstra.FindShortestPath(ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == "1")],ListaDosNodos[ListaDosNodos.FindIndex(node => node.Label == "21")]);

        /* foreach (Node nodeInPath in shortestPath)
        {
            //Faça algo com cada nó no caminho, como marcá-lo, movimentar um personagem, etc.
            Debug.Log("Node in path: " + nodeInPath.Label);
        } */
    }
    
}
