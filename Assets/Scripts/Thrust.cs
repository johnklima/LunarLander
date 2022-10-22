using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thrust : MonoBehaviour
{

    private const int FIRST_CHILD = 0;
    private Transform fire;

    public  Rigidbody rigid;
    public  LanderControl restitution;

    public KeyCode key;

    public float thrustForce = 100.0f;
    public float consumption = 0.1f;
    public float fuelSupply = 1.0f; 
    public float efficiency = 1.0f; //efficiency will affect thrust force not to consumption

    public Slider overallfuel;
    public Slider individualFuel;

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
            //Debug.Log("KEY UP");
            restitution.Restitute(true);
            fire.gameObject.SetActive(false);

        }

    }
    // FixedUpdate is called in sync with the physics engine
    void FixedUpdate()
    {
        //is key press and do we have enough fuel
        if ( Input.GetKey(key)  && fuelSupply > Time.deltaTime * consumption  )
        {
            //show the flame
            fire.gameObject.SetActive(true);

            //apply the thrust in the direction of the up vector of this thruster
            Vector3 force = transform.up * thrustForce * Time.deltaTime * efficiency;

            rigid.AddForceAtPosition(force, fire.position, ForceMode.Force);
            restitution.Restitute(false);

            fuelSupply -= Time.deltaTime * consumption;
            overallfuel.value -= Time.deltaTime * consumption;
            individualFuel.value = fuelSupply;
        }
    }
}
