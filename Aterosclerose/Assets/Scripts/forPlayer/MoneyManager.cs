using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{

    private float Money;
    [SerializeField] private TMP_Text textMoney;


    // Start is called before the first frame update
    void Start()
    {
        Money = 100.00f;
        
    }
    
    public void AddMoney(float valorAdd){
        if(valorAdd < 1){
            Debug.Log("O valor a ser adicionado deve ser positivo!");
            return;
        }
        Money += valorAdd;
        AtualizaMoney();
    }

    public void SubMoney(float valorSub){
        if(valorSub < 1){
            Debug.Log("O valor a ser subtraido deve ser positivo!");
            return;
        }
        Money -= valorSub;
        AtualizaMoney();
    }


    private void AtualizaMoney(){
        textMoney.text = Money.ToString();
        Debug.Log("Valor do dinheiro atualizado.");
    }


    private void salvaDinheiro(){
        Debug.Log("Valor do dinheiro Salvo");
    }
    
}
