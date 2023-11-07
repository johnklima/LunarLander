using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadGame : MonoBehaviour
{

    private int padsLanded = 0;

   

    public void addPad()
    {
        padsLanded++;
        if(padsLanded >= transform.childCount)
        {
            Debug.Log("GAME OVER SUCCESS!!!!");
            Time.timeScale = 0; //pause the game
        }
    }

}
