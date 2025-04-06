using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpPower = 10f;
    private Rigidbody rb;
    private bool jumpCan = false;
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !jumpCan)
        {
            rb.velocity = Vector3.up * jumpPower;
            jumpCan = true;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        jumpCan = false;
    }
}
