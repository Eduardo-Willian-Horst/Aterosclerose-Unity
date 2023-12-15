using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personPersist : MonoBehaviour
{
    private int personChanged;
    private string varName;
    void Start()
    {
        
    }
    void changeName(){
        
    }
    void loadPerson(){
        personChanged = PlayerPrefs.GetInt("personagemEscolhido"+varName);
    }

}
