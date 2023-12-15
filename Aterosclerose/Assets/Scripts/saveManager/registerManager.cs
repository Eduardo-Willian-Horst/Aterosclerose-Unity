using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class registerManager : MonoBehaviour
{
    private int meuPersonagemAuxiliar =1;
    public SceneSampler ss;
    public playerController pc;
    public Button buttonContinue;
    public TextMeshProUGUI saveAlert;
    //public SceneSampler sceneSampler;
    public TextMeshProUGUI inputField;
    public TextMeshProUGUI inputField2aux;
    private int numberOfSaves;
    private List<string> mySaves = new List<string>();
    private string saveName;
    public RawImage men1;
    public RawImage women1;
    private string nomeDaCenaAtual;
    // Start is called before the first frame update

    // PLAYER PREFS É PERSISTÊNCIA PRIMITIVA DO UNITY, QUE LIDA COM INT, FLOAT E STRING
    // HÁ 2 MÉTODOS: GET E SET.
    // GET, DOIS PARÂMETROS: NOME DA VARIÁVEL E VALOR DEFAULT A SER RETORNADO SE ELA NÃO EXISTIR
    // SET, DOIS PARÂMETROS: NOME DA VARIÁVEL E VALOR A SER GUARDADO PARA ELA
    // DELETEALL: DELETAR TODOS OS DADOS SALVOS ATÉ O MOMENTO

    void Start()
    {

        //PlayerPrefs.DeleteAll(); //UTILIZAR PARA LIMPAR AS PERSISTÊNCIAS //ATENÇÃO: LIMPA TUDO E NÃO PODE SER DESFEITO
        nomeDaCenaAtual = SceneManager.GetActiveScene().name; // APENAS UTILIZADO QUANDO VEM DO OVERRIDE
        numberOfSaves = PlayerPrefs.GetInt("nsaves",0);
        saveAlert.gameObject.SetActive(false);
        updateList();
    }
    void Update(){
        buttonActiveOrNot();
        whichPersonShow();
    }
    void buttonActiveOrNot(){ // MÉTODO PARA DEIXAR O BUTTON CONTINUE ATIVO OU NÃO, A DEPENDER DO INPUT FIELD SER NULO, OU NÃO
        string auxiliar = inputField.text;
        if(auxiliar.Length>1){
            buttonContinue.interactable = true;
        }else{
            buttonContinue.interactable = false;
        }
    }
    void updateList(){ // MÉTODO PARA DEIXAR A LISTA MYSAVES ATUALIZADA COM TODOS OS SAVES QUE O PLAYER POSSUI
        if(numberOfSaves>0){
            mySaves.Clear();
            for(int i=1; i<=numberOfSaves; i++){
                string aux = i.ToString();
                string aux2 = PlayerPrefs.GetString(aux);
                mySaves.Add(aux2);
            }
        }
    }

    public void register(){   // MÉTODO PARA REGISTRAR UM NOVO SAVE AO CLICAR NO BUTTON CONTINUE, POSSUI TRATAMENTO PARA NULL EXCEPTION E NOMES QUE JÁ EXISTEM
        saveName = inputField.text;
        if(mySaves.Contains(saveName)){
            saveAlert.gameObject.SetActive(true);
        }else{
            saveAlert.gameObject.SetActive(false);
            if(nomeDaCenaAtual=="CreateCharacter"){
                numberOfSaves++;
                string aux3 = numberOfSaves.ToString();
                PlayerPrefs.SetString(aux3,saveName);
            }else{
                int auxiliar_ = PlayerPrefs.GetInt("playerOverride");
                string auxiliar__ = auxiliar_.ToString();
                PlayerPrefs.SetString(auxiliar__,saveName);
            }
            auxiliaRegister();
            saveAll();
            updateList();
           ss.LoadCity();
        }
    }
    void saveAll(){ //MÉTODO PARA ATUALIZAR A PERSISTÊNCIA DE NÚMERO DE SAVES
        PlayerPrefs.SetInt("nsaves",numberOfSaves);
    }

    void auxiliaRegister(){ //MÉTODO PARA AUXILIAR O REGISTER, SALVAR O PERSONAGEM ESCOLHIDO PELO PLAYER (1 OU 2) E CARREGAR OS VALORES PARA O PLAYER STATS
        pc.setComingNewGame(saveName, meuPersonagemAuxiliar);
        PlayerPrefs.SetInt("personagem_"+saveName, meuPersonagemAuxiliar);
        PlayerPrefs.SetInt("moedas_"+saveName,0);
        PlayerPrefs.SetInt("especializacao_"+saveName,0);
    }
    public void onClickRight(){
        meuPersonagemAuxiliar++;
        if(meuPersonagemAuxiliar>2)meuPersonagemAuxiliar=1;
    }
    public void onClickLeft(){
        meuPersonagemAuxiliar--;
        if(meuPersonagemAuxiliar==0)meuPersonagemAuxiliar=2;
    }
    void whichPersonShow(){
        if(meuPersonagemAuxiliar==1){
            men1.gameObject.SetActive(true);
            women1.gameObject.SetActive(false);
        }else if(meuPersonagemAuxiliar==2){
            men1.gameObject.SetActive(false);
            women1.gameObject.SetActive(true);
        }
    }
}
