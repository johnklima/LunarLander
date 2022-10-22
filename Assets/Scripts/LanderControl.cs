using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanderControl : MonoBehaviour
{

    private bool doRestitute = true;
    private Rigidbody rigid;

    public  Quaternion b = Quaternion.identity;
    public  Quaternion a;
    public float t = 0;
    public Vector3 avb = Vector3.zero;
    public Vector3 ava;

    public Quaternion bufrot;
    public float decay = 10.0f;
    public Text magnitude;


    // Start is called before the first frame update
    void Start()
    {
        
        rigid = transform.GetComponent<Rigidbody>();
        rigid.maxAngularVelocity = 1f;

    }


 
    //in sync with physics
    void FixedUpdate()
    {
        //show user how fast they currently are
        magnitude.text = rigid.velocity.magnitude.ToString();

        // check for max rotation
        float ang = Quaternion.Angle(transform.rotation, Quaternion.identity);
        if (Mathf.Abs(ang) > 90.0f)
        {

            //Debug.Log("GREATER THAN 90");
            
            rigid.angularVelocity = Vector3.zero;
            transform.rotation = bufrot;

        }

        //cheat, make an "onboard" gyroscope stabilizer
        if (doRestitute)
        {
            //restitution
            t += Time.deltaTime * 5f;

            if (t > 1.0f)
            {
                t = 1.0f;
                doRestitute = false;
            }

            //upright orientation
            transform.rotation = Quaternion.Lerp(a, b, t);

            //wind down the angular velocity
            rigid.angularVelocity = Vector3.Lerp(ava, avb, t);


        }
        //apply custom drag to slow/halt the lander on the x,z axis, but not the y
        //because y is the gravity vector.
        if(!Input.anyKey)
        {
            //do decay
            Vector3 targvelo = rigid.velocity;
            targvelo.x = 0;
            targvelo.z = 0;
            //lerp down to halt on x,z but leave y gravity untouched
            rigid.velocity = Vector3.Lerp(rigid.velocity, targvelo, Time.deltaTime * decay);
        }
        


        //keep track of a "last good" rotation
        bufrot = transform.rotation;

    }

    //one shot to start the restitute cycle
    public void Restitute (bool doit)
    {
        if(doit)
        {
            //start the restitution cycle
            doRestitute = true;
            a = transform.rotation;
            ava = rigid.angularVelocity; ;
            t = 0;
        }
        else 
        {
            //stop restitution
            doRestitute = false;
        }


    }
}
