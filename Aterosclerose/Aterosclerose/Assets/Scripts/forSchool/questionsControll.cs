using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class questionsControll : MonoBehaviour
{
    public Image bk1;
    public Image bk2;
    public Image bk3;
    public Image bk4;
    public TextMeshProUGUI question; // QUESTAO
    public TextMeshProUGUI a1; // RESPOSTA 1
    public TextMeshProUGUI a2; // RESPOSTA 2
    public TextMeshProUGUI a3; // RESPOSTA 3
    public TextMeshProUGUI a4; // RESPOSTA 4
    private System.Random random;
    public geralManager gm;
    public playerStats pstats;
    private int myRandom;
    private int numberOfQuestions;
    private int numberOfQuestionsAnswered;
    private string saveName;

    [System.Serializable]
    public class geralquestions_
    {
        public int id;
        public string pergunta;
        public List<string> opcoes;
        public string respostaCorreta;
    }

    [System.Serializable]
    public class geralQuestionsList
    {
        public List<geralquestions_> geralquestions;
    }

    public geralQuestionsList questList;

    void Start(){
        random = new System.Random();
    }

    public void init()
    {
        loadGeralQuestions();
        chargeData();
        verify();
    }

    void chargeData(){
        numberOfQuestions = questList.geralquestions.Count;
        saveName = pstats.getName();
        numberOfQuestionsAnswered = PlayerPrefs.GetInt("questionsAnswered_"+saveName,0);
    }
    void verify(){
        //Debug.Log("eu cheguei no verify?");
        //Debug.Log(numberOfQuestions);
        //Debug.Log(numberOfQuestionsAnswered);
        if(numberOfQuestionsAnswered==numberOfQuestions){
            //Debug.Log("eu entrei no if?");
            gm.allQuestionsAnswered();
        }else{
            chargeQuestion();
        }
    }
    void loadGeralQuestions(){
        string caminhoJson = Path.Combine(Application.dataPath, "Scripts/forSchool/jsonPath/geralQuestions.json");
        if(File.Exists(caminhoJson)){
            Debug.Log("JSON ENCONTRADO!");
            string json = File.ReadAllText(caminhoJson);
            questList = JsonUtility.FromJson<geralQuestionsList>(json);
        }else{
            Debug.Log("ARQUIVO NÃO ENCONTRADO!");
        }
    }
    void chargeQuestion(){
        while(true){
            myRandom = random.Next(0, numberOfQuestions);
            int idOfQuest = questList.geralquestions[myRandom].id;
            if(PlayerPrefs.GetInt("qAnsweredOrNot_"+saveName+"_"+idOfQuest,0)>0){
                continue;
            }else{
                questList.geralquestions[myRandom].opcoes.Sort((a,b) => random.Next(-1,2));
                break;    
            }
        }
        question.text = questList.geralquestions[myRandom].pergunta;
        a1.text = questList.geralquestions[myRandom].opcoes[0];
        a2.text = questList.geralquestions[myRandom].opcoes[1];
        a3.text = questList.geralquestions[myRandom].opcoes[2];
        a4.text = questList.geralquestions[myRandom].opcoes[3];
    }
    public void onClickb1(){
        if(a1.text != questList.geralquestions[myRandom].respostaCorreta){
            bk1.color = Color.red;
        }else{
            bk1.color = Color.green;
        }
    }
    public void onClickb2(){
        if(a2.text != questList.geralquestions[myRandom].respostaCorreta){
            bk2.color = Color.red;
        }else{
            bk2.color = Color.green;
        }
    }
    public void onClickb3(){
        if(a3.text != questList.geralquestions[myRandom].respostaCorreta){
            bk3.color = Color.red;
        }else{
            bk3.color = Color.green;
        }
    }
    public void onClickb4(){
        if(a4.text != questList.geralquestions[myRandom].respostaCorreta){
            bk4.color = Color.red;
        }else{
            bk4.color = Color.green;
        }
    }

}
