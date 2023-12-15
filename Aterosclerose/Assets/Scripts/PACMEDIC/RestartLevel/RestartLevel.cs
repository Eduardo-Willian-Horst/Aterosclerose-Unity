using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RestartLevel : MonoBehaviour
{
    public Tilemap tilemap;

    // Posição que você deseja verificar
    public Vector3Int positionToCheck;
    public GameObject PrefabBall;
    private int Quant_Balls = 0;



    void Start()
    {
        ReCreateBalls();
        //Debug.Log(Quant_Balls);
    }



    public void ReCreateBalls(){
        for(int c = -1; c <= 33; c++){
            for(int l = -11; l <= 7; l++){
                positionToCheck = new Vector3Int(c,l,0);
                if (tilemap.GetTile(positionToCheck) == null)
                {
                    
                    if(new Vector3(positionToCheck.x + 0.5f, positionToCheck.y + 0.5f, 0f) != new Vector3( 16.5f, -6.5f, 0f)){
                        Instantiate(PrefabBall, new Vector3(positionToCheck.x + 0.5f, positionToCheck.y + 0.5f, 0f), Quaternion.identity);
                        Quant_Balls++;
                    }
          
                }
                
    
            }
        }

    }
}
