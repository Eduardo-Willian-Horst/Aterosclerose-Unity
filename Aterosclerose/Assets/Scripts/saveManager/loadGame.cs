using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// PERSONAGEM = 1 CORRESPONDE AO MÉDICO
// PERSONAGEM = 2 CORRESPONDE A MÉDICA
public class loadGame : MonoBehaviour
{
    private int iterador;
    private int numberOfSaves;
    public Button right;
    public Button left;
    public Button load;
    public RawImage medico;
    public RawImage medica;
    public Button newGame;
    public TextMeshProUGUI error;
    public TextMeshProUGUI nameplayer;
    private bool showOrNot; // BOOL AUXILIAR PARA O MÉTODO DENTRO DO UPDATE SABER SE DEVE OU NÃO SER EXECUTADO, DE ACORDO COM HAVER SAVES OU NÃO;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        setarFalse();
        numberOfSaves = PlayerPrefs.GetInt("nsaves",0);
        initializer();
    }
    void Update(){
       if(showOrNot){
            whatShow();
       }
    }
    void initializer(){
        if(numberOfSaves==0){
            showOrNot = false;
            newGame.gameObject.SetActive(true);
            error.gameObject.SetActive(true);
        }else{
            iterador =1;
            showOrNot = true;
            right.interactable = true;
            left.interactable = true;
            load.gameObject.SetActive(true);
        }
    }

    void setarFalse(){
        load.gameObject.SetActive(false);
        error.gameObject.SetActive(false);
        newGame.gameObject.SetActive(false);
        medico.gameObject.SetActive(false);
        medica.gameObject.SetActive(false);
        right.interactable = false;
        left.interactable = false;
    }
    void whatShow(){
        int it = iterador;
        string aux = it.ToString();
        string nome = PlayerPrefs.GetString(aux);
        nameplayer.text = nome;
        int sheOrHe = PlayerPrefs.GetInt("personagem_"+nome);
        heOrShe(sheOrHe);
    }
    public void onClickRight(){
        iterador++;
        if(iterador>numberOfSaves){
            iterador=1;
        }
    }

    public void onClickLeft(){
        iterador--;
        if(iterador==0){
            iterador=numberOfSaves;
        }
    }

    void heOrShe(int a){    // METODO PARA DECIDIR SE ATIVAMOS O PERSONAGEM MEDICO OU MEDICA, DE ACORDO COM O SAVE DO PLAYER
        if(a==1){
            medico.gameObject.SetActive(true);
            medica.gameObject.SetActive(false);
        }else if(a==2){
            medico.gameObject.SetActive(false);
            medica.gameObject.SetActive(true);
        }
    }
}
