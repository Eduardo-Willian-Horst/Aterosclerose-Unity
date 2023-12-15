using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class especializationQuestionsControll : MonoBehaviour
{
    [System.Serializable]

    public class especializationQuestions_
    {
        public int id;
        public string pergunta;
        public List<string> opcoes;
        public string respostaCorreta;
    }
    [System.Serializable]
    public class especialQuestionsList
    {
        public List<especializationQuestions_> especializationQuestions;
    }
    public especialQuestionsList especQuestList;

    void Start(){
        loadEspecialQuestions();
    }
    void loadEspecialQuestions(){
        string caminhoJson = Path.Combine(Application.dataPath, "Scripts/forSchool/jsonPath/especializationQuestions.json");
        if(File.Exists(caminhoJson)){
            Debug.Log("JSON ENCONTRADO!");
            string json = File.ReadAllText(caminhoJson);
            especQuestList = JsonUtility.FromJson<especialQuestionsList>(json);
        }else{
            Debug.Log("ARQUIVO NÃO ENCONTRADO!");
        }
    }
}
