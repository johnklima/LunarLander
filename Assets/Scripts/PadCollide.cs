using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadCollide : MonoBehaviour
{

    public bool hasLanded = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Rigidbody rigid = (Rigidbody)collision.body;

            rigid.velocity = Vector3.zero;

            if (rigid.velocity.magnitude > 1.0f)  //again another place for gameplay (durability of lander)
            {
                Debug.Log("CRASH");   //game over, reset
                                      //...
            }
            else
            {
                Debug.Log("LANDED SAFELY ON PAD!!!!");

                if (!hasLanded)
                {
                    //keep track of game state
                    transform.parent.GetComponent<PadGame>().addPad();

                    //fill the fuel tanks, upgrade someting etc...
                    foreach (Transform child in transform)
                    {
                        child.GetComponent<Thrust>().fuelSupply = 1.0f;

                    }
                    
                    hasLanded = true ;


                }
                
            }


        }
    }
}
