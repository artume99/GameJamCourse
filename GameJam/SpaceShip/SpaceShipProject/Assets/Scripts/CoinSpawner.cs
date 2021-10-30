using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] float interval = 0.5f;
    private float timer;
    private ObjectPooling pooler;
    private List<KeyValuePair<string, int>> toSpawn;
    private int totalPres = 100;
    
    // constraints
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;


    private void Awake()
    {
       pooler = ObjectPooling.Instance;
       toSpawn = new List<KeyValuePair<string, int>>()
       {
           new KeyValuePair<string, int>("3DIA", 20), 
           new KeyValuePair<string, int>("DIA", 80), 
       };  
    }

    private void FixedUpdate()
    {
       
        if (timer > interval)
        {
            Spawn();
        }

        timer += Time.deltaTime;
    }

    private void Spawn()
    {
        int num = Random.Range(0, totalPres);
        string searchToSpawn = "";
        foreach (var pair in toSpawn)
        {
            if ((num-pair.Value)<0)
            {
                searchToSpawn = pair.Key;
                break;
            }
        }
            
        if (searchToSpawn == "")
        {
            searchToSpawn = "DIA";
        }

        Vector3 pos = transform.position + RandomLocation();
        pooler.SpawnFromPool(searchToSpawn, pos, Quaternion.identity);
        timer -= interval;
    }

    private Vector3 RandomLocation()
    {
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);
        return new Vector3(randX, randY, transform.position.z);
    }
    
}
