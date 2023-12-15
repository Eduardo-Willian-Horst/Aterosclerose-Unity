using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public playerStats pstats;
    public void setComingNewGame(string name, int person){
        pstats.setCoins(0);
        pstats.setCoins(0);
        pstats.setName(name);
        pstats.setPerson(person);
    }
}
