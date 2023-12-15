using UnityEngine;

public class playerStats : MonoBehaviour
{
    private int specialization;
    private int coins;
    private string saveName;
    private int person;
    void Start()
    {
        specialization = PlayerPrefs.GetInt("especializacao",0);
        coins = PlayerPrefs.GetInt("moedas",0);
    }
    void updateEspecialization(){
        if(specialization<10)specialization+=1;
        saveAll();
    }
    void updateMoreCoins(int numberOfCoins){
        coins+=numberOfCoins;
        saveAll();
    }
    bool canBuy(int value){
        if(value<=coins)return true;
        return false;
    }

    void saveAll(){
        PlayerPrefs.SetInt("especializacao_"+saveName,specialization);
        PlayerPrefs.SetInt("moedas_"+saveName,coins);
    }
    public void setCoins(int n){
        coins =n;
    }
    public void setSpecialization(int n){
        specialization =n;
    }
    public void setName(string newName){
        saveName = newName;
    }
    public void setPerson(int person1){
        person = person1;
    }
    public string getName(){
        return saveName;
    }
}
