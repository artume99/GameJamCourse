using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Vector3 mousePosition;
    [SerializeField] private float moveSpeed = 15f;
    [SerializeField] private GameObject objectContainer;
    [SerializeField] private Rigidbody2D rb;
    private float localX;
 
    // Use this for initialization
    void Start ()
    {
        localX = objectContainer.transform.position.x - 33f;
        rb = GetComponent<Rigidbody2D>();
    }
   
    // Update is called once per frame
    void FixedUpdate () {
        localX = objectContainer.transform.position.x - 33f;
        // localX = transform.position.x;
        if (true) {
            mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 tmpDir = mousePosition - transform.position;
            Vector3 lerped = new Vector3(localX, transform.position.y);
            
            // transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * 1f / tmpDir.magnitude * Time
            // .deltaTime);
            Physics2D.SyncTransforms();
            rb.MovePosition(Vector2.Lerp(transform.position,mousePosition, moveSpeed * 1f / tmpDir.magnitude * Time.deltaTime));
            // StartCoroutine(MoveToPosition(mousePosition));
            // rb.MovePosition(mousePosition);

        }
 
    }
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
}

