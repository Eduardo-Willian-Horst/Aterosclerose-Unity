using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class newGameTreatment : MonoBehaviour
{
    public SceneSampler ss;
    private int limiteDeSaves = 5;
    private int numberOfSaves;
    // Start is called before the first frame update
    void Start()
    {
        numberOfSaves = PlayerPrefs.GetInt("nsaves",0);
    }

    public void onClickNewGameButton(){
        if(numberOfSaves>limiteDeSaves){
            ss.loadOverrideSave();      
        }else{
            ss.LoadNewGameScene();
        }
    }
    public void onClickExitButton(){
        Application.Quit();
    }
    public void deleteAll_(){
        PlayerPrefs.DeleteAll();
    }
}
