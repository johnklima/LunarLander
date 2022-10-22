using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody rigid = other.GetComponent<Rigidbody>();            

            if (rigid.velocity.magnitude > 1.0f)  //again another place for gameplay (durability of lander)
            {
                Debug.Log("CRASH");   //game over, reset
                                      //...
            }

            //rigid.velocity = Vector3.zero;

        }


    }

    
}
