using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontuacaoAtual : MonoBehaviour
{
    [SerializeField] private int Pontuacao = 0;


    public void AddPontuacaoAtual(){
        Pontuacao += 15;
    }
}
