using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] private float moveSpeed = 15f;
    private Rigidbody2D rb;
    private float localX;
 
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    // CODE FOR LERPING WITH CONSTANT SPEED
    void FixedUpdate () {
        if (true) {
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 tmpDir = mousePosition - transform.position;
            rb.MovePosition(Vector2.Lerp(transform.position,mousePosition, moveSpeed * 1f / tmpDir.magnitude * Time.deltaTime));
        }
 
    }
    
    // CODE FOR LERPING WITH SLOW DOWN!
    private IEnumerator MoveToPosition (Vector3 target)
    {
        Debug.Log(transform.position);
        float t = 0;
        Vector3 start = transform.position;
 
        while (t <= 1)
        {
            t += Time.fixedDeltaTime / moveSpeed;
            rb.MovePosition (Vector3.Lerp (start, target, t*moveSpeed));
 
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Sheep")
        {
            GameManager.Instance.AudioSources["sheep"].Play();
        }
    }
}

