using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


// ESSE SCRIPT SERVE PARA QUANDO O PLAYER ATINGE O NÚMERO MÁXIMO DE SAVES, E PRECISA EXCLUIR UM DELES PARA PODER CRIAR UM NOVO
public class OverrideGame1 : MonoBehaviour
{
    public SceneSampler ss;
    public Button yesButton;
    public Button noButton;
    public Button return_;
    public Button override_;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public Image background;
    public TextMeshProUGUI names;
    public TextMeshProUGUI dinheiro;
    public RawImage medico;
    public RawImage medica;
    private int myIterator=1;
    private int numberOfSaves;

    void Start(){
        numberOfSaves = PlayerPrefs.GetInt("nsaves",0);
        setFalse();
    }
    void Update(){
        whatShow();
    }
    public void onClickLeft(){
        myIterator--;
        if(myIterator==0){
            myIterator=numberOfSaves;
        }
    }
    public void onClickRight(){
        myIterator++;
        if(myIterator>numberOfSaves)myIterator=1;
    }
    void whatShow(){
        string aux = myIterator.ToString();
        string nome = PlayerPrefs.GetString(aux);
        int personagem = PlayerPrefs.GetInt("personagem_"+nome);
        int moedas = PlayerPrefs.GetInt("moedas_"+nome);
        dinheiro.text = "$ "+moedas;
        sheOrHe(personagem);
        names.text = nome;
    }
    void sheOrHe(int a){ //PARA DECIDIR SE MOSTRAMOS O MÉDICO OU A MÉDICA NA TELA
        if(a==1){
            medico.gameObject.SetActive(true);
            medica.gameObject.SetActive(false);
        }else if(a==2){
            medico.gameObject.SetActive(false);
            medica.gameObject.SetActive(true);
        }
    }
    void activeAlert(){
        noButton.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        return_.interactable = false;
        override_.interactable = false;
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
        text3.gameObject.SetActive(true);
        string aux2 = myIterator.ToString();
        string nameOfSave = PlayerPrefs.GetString(aux2);
        text3.text = "Tem certeza que deseja excluir o progresso de " + nameOfSave+ "?";
        background.gameObject.SetActive(true);
    }
    void setFalse(){
        noButton.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        return_.interactable = true;
        override_.interactable = true;
        text1.gameObject.SetActive(false);
        text2.gameObject.SetActive(false);
        text3.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }
    public void onClickOverride(){
        activeAlert();
    }
    public void onClickNoButton(){
        setFalse();
    }
    public void onClickYesButton(){
        PlayerPrefs.SetInt("playerOverride", myIterator);
        ss.loadOverrideCharacter();
    }
}
