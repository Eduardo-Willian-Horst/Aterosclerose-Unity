using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EspecializationBarController : MonoBehaviour
{
    private float Especializacao;
    [SerializeField] private Slider EspecializationBar;
    [SerializeField] private int PerguntasRespondidas;
    private int TotalDePerguntas;

    private void Start(){
        // Aqui vai ficar a lógica para pegar o valor da especializacao
        //total de perguntas
        TotalDePerguntas = 50;
        //Perguntas Respondidas
        PerguntasRespondidas = 50;

        //Atualiza o Valor
        AttEspec();
    }


    //LEMBRAR DE TIRAR O METODO UPDATE
    


    
    private void AttEspec(){
        AddEspec();
    }





    private void AddEspec(){

        Especializacao = (PerguntasRespondidas * 100) / TotalDePerguntas;
        AtualizaBarra(Especializacao);
        
        //Aqui posso guardar a especialização em algum lugar se eu precisar
    }

    private void AtualizaBarra(float valorDaEspec){
        EspecializationBar.value = valorDaEspec;
    }








}
