using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSampler : MonoBehaviour
{
    public void LoadNewGameScene(){
        SceneManager.LoadScene("CreateCharacter");
    }
    public void LoadGame(){
        SceneManager.LoadScene("LoadGame");
    }
    public void LoadCity(){
        SceneManager.LoadScene("City");
    }
    public void LoadCredits(){
        SceneManager.LoadScene("Credits");
    }
    public void ReturnMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void loadOverrideCharacter(){
        SceneManager.LoadScene("OverrideCharacter");
    }
    public void loadOverrideSave(){
        SceneManager.LoadScene("OverrideSave");
    }
}
