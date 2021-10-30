using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;
    private Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.back*Time.deltaTime * speed , Space.World);
        rg.MovePosition(rg.position+Vector3.back*Time.deltaTime*speed);
    }
}
