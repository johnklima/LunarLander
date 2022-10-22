using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadGame : MonoBehaviour
{

    private int padsLanded = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
