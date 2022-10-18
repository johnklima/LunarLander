using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitRotation : MonoBehaviour
{

    private bool doRestitute = true;
    private Rigidbody rigid;

    public  Quaternion b = Quaternion.identity;
    public  Quaternion a;
    public float t = 0;
    public Vector3 avb = Vector3.zero;
    public Vector3 ava;

    public Quaternion bufrot;

    // Start is called before the first frame update
    void Start()
    {
        
        rigid = transform.GetComponent<Rigidbody>();
        rigid.maxAngularVelocity = 1f;
    }

 
    //in sync with physics
    void FixedUpdate()
    {


        // check rotation
        float ang = Quaternion.Angle(transform.rotation, Quaternion.identity);
        if (Mathf.Abs(ang) > 90.0f)
        {

            Debug.Log("GREATER THAN 90");
            
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
