using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AstroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] float interval = 0.5f;
    private float timer;
    private ObjectPooling pooler = ObjectPooling.Instance;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (timer > interval)
        {
            Random rnd = new Random();
            // pooler.SpawnFromPool("Asteroid", spawnLocations[rnd.Next(0, 4)].position, Quaternion.identity);
            GameObject asteroid = Instantiate(asteroids[rnd.Next(0, asteroids.Length)], spawnLocations[rnd.Next(0, 
            spawnLocations.Length)]);
            asteroid.transform.localPosition = Vector3.zero;
            timer -= interval;
        }

        timer += Time.deltaTime;
    }
}
