using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    private float timer;
    private ObjectPooling pooler;
    [SerializeField] float interval = 3f;
    [SerializeField] private Sprite[] toSpawn;
    private void Awake()
    {
        pooler = ObjectPooling.Instance;
       
    }

    // Update is called once per frame
    // private void FixedUpdate()
    // {
    //    
    //     if (timer > interval)
    //     {
    //         Spawn();
    //     }
    //
    //     timer += Time.deltaTime;
    // }
    //
    // private void Spawn()
    // {
    //     int num = Random.Range(0, toSpawn.Length); 
    //     GameObject obj = pooler.SpawnFromPool("Planets", transform.position, Quaternion.identity);
    //     obj.GetComponent<SpriteRenderer>().sprite = toSpawn[num];
    //     timer -= interval;
    // }
}
