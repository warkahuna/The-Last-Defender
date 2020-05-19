using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneRotation : MonoBehaviour
{

    
    Rigidbody rigidbody;
   public float speedY, speedZ, torque;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddTorque(transform.up * torque * speedY);
    }
    private void FixedUpdate()
    {
        rigidbody.AddTorque(transform.up * torque * speedZ);
    }
}
