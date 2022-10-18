using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float distance;
    public float height;
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = target.forward;
        transform.position = (target.position - fwd * distance) + Vector3.up * height;
        transform.LookAt(target);
    }
}
