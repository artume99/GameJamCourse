using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;
    private Rigidbody rg;
    private ParticleSystem p;
    private AudioSource explosion;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.velocity = Vector3.back * speed; 
        p = GetComponent<ParticleSystem>();
        explosion = GetComponent<AudioSource>();
        if(p)
            p.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        // rg.MovePosition(rg.position+Vector3.back*Time.deltaTime*speed);
    }

    public void Explode()
    {
        if (!p)
        {
            return;
        }
        p.Play();
        explosion.Play();
        Destroy(gameObject, p.main.duration);
    }
}
