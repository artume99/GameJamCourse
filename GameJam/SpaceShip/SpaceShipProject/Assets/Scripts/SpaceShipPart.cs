using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipPart : MonoBehaviour, IPooledObject
{
    private SpriteRenderer sr;
    private List<string> allowedToCollect;

   
    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        allowedToCollect = new List<string> {"Player"};
    }

    public void ObjectSPawn()
    {
        int i = GameManager.Instance.partCollected;
        sr.sprite = GameManager.Instance.SpaceShipParts[i];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (allowedToCollect.Contains(other.tag)){
            gameObject.SetActive(false);
            GameManager.Instance.AddPart();
            // TODO: add sound 
        }
    }

    
}
