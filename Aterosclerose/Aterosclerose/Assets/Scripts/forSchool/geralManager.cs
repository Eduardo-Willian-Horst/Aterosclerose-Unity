using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class geralManager : MonoBehaviour
{
    public questionsControll qc;
    public Canvas canvasA; // canvas do menu das questoes
    public Canvas canvasB; // canvas das questoes gerais 
    public Canvas canvasC; // canvas de erro
    
    void Start()
    {
        canvasA.gameObject.SetActive(true);
        canvasB.gameObject.SetActive(false);
        canvasC.gameObject.SetActive(false);
    }
    public void returnToMenuQuestions(){
        canvasA.gameObject.SetActive(true);
        canvasB.gameObject.SetActive(false);
        canvasC.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void onClickGeralQuests(){
        canvasA.gameObject.SetActive(false);
        canvasB.gameObject.SetActive(true);
        canvasC.gameObject.SetActive(false);
        qc.init();
    }

    public void allQuestionsAnswered(){
        canvasA.gameObject.SetActive(false);
        canvasB.gameObject.SetActive(false);
        canvasC.gameObject.SetActive(true);
    }
}
