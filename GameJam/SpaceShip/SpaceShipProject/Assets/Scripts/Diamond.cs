using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Diamond : MonoBehaviour, IPooledObject
{
    private List<string> allowedToCollect;

    private void Awake()
    {
        allowedToCollect = new List<string> {"Player", "Sheep"};
    }

    public void ObjectSPawn()
    {
        return;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (allowedToCollect.Contains(other.tag)){
            gameObject.SetActive(false);
            GameManager.Instance.AddScore();
            // TODO: add sound 
        }
    }
}
