using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBall : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed;
    public float factor;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //This limits rotation in postive z
        if(Input.GetKey("w"))
        {
            rb.AddForce(0,0,movementSpeed);
        }
        //This limits rotation in negative z
        if(Input.GetKey("s"))
        {
            rb.AddForce(0,0,-movementSpeed);
        }
    
        if(Input.GetKey("d"))
        {
            rb.AddForce(movementSpeed,0,0);
        }
        //This limits rotation in negative x
        if(Input.GetKey("a"))
        {
            rb.AddForce(-movementSpeed,0,0);
        }
    }
}
