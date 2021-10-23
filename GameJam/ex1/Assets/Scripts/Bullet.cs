using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inAir = false;
    private float duration = 3f;
    private float lastShown;
    private SpriteRenderer sr;

    [SerializeField]
    private float speed = 1f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = Shooter.instance.selectedBullet;
    }

    void Start()
    {
        inAir = true;
        lastShown = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (!inAir)
        {
            Destroy(gameObject);
        }
        
        transform.Translate(Vector3.up*Time.deltaTime*speed);
        if (Time.time - lastShown > duration)
        {
            inAir = false;
        }
    }

    public void SetDuration(float n_duration)
    {
        duration = n_duration;
    }
    
}
