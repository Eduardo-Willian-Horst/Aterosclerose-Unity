using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{

    [SerializeField] private static int PontuacaoAtual = 0;
    private static int Quant_Bolas = 0;

    // Update is called once per frame
    

    void Start(){
        if(transform.position == new Vector3( 16.5f, -0.5f, 0f) ||
           transform.position == new Vector3( 16.5f,  0.5f, 0f) ||
           transform.position == new Vector3( 17.5f, -0.5f, 0f) ||
           transform.position == new Vector3( 15.5f, -0.5f, 0f)){
            Destroy(this.gameObject);   
        }else{
            Quant_Bolas++;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DestroyBallPacMedic")
        {
            Quant_Bolas--;
            PontuacaoAtual += 5;
            //Debug.Log($"Pontuação: {PontuacaoAtual}. Bolas Restantes: {Quant_Bolas}");
            Destroy(this.gameObject);   
        }
    }


   
}
