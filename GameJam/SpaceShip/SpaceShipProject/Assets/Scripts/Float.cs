using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    public float FloatStrenght = 1f;
    public float RandomRotationStrenght = 1f;
    private Rigidbody2D rg;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        rg.AddForce(Vector3.up *FloatStrenght);
        transform.Rotate(RandomRotationStrenght,RandomRotationStrenght,RandomRotationStrenght);
    }
}
