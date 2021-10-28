using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rg;
    [SerializeField] private float speed = 40f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rg.MovePosition(transform.position + Vector3.left* Time.deltaTime*speed);
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rg.MovePosition(transform.position + Vector3.right* Time.deltaTime*speed);
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rg.MovePosition(transform.position + Vector3.up* Time.deltaTime*speed);
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rg.MovePosition(transform.position + Vector3.down* Time.deltaTime*speed);
            
        }
    }
}
