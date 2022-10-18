using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour
{

    private const int FIRST_CHILD = 0;
    private Transform fire;

    public  Rigidbody rigid;
    public  LimitRotation restitution;

    public KeyCode key;
    public float thrustForce = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        //get my representation of flame thrust
        fire = transform.GetChild(FIRST_CHILD);

    }
    private void LateUpdate()
    {
        if ( Input.GetKeyUp(key) )
        {
            Debug.Log("KEY UP");
            restitution.Restitute(true);
            fire.gameObject.SetActive(false);

        }

    }
    // FixedUpdate is called in sync with the physics engine
    void FixedUpdate()
    {

        if ( Input.GetKey(key)  )
        {
            //show the flame
            fire.gameObject.SetActive(true);

            //apply the thrust in the direction of the up vector of this thruster
            Vector3 force = transform.up * thrustForce * Time.deltaTime;

            rigid.AddForceAtPosition(force, fire.position, ForceMode.Force);
            restitution.Restitute(false);
           

        }
    }
}
