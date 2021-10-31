using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float speed = 50000f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rg.AddForce(Vector3.left* Time.deltaTime*speed);
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rg.AddForce(Vector3.right* Time.deltaTime*speed);
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rg.AddForce(Vector3.up* Time.deltaTime*speed);
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rg.AddForce(Vector3.down* Time.deltaTime*speed);
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Asteroid asteroid = other.GetComponent<Asteroid>();
            asteroid.Explode();
        }
    }
}
