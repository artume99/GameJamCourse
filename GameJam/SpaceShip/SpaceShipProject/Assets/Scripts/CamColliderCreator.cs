using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamColliderCreator : MonoBehaviour
{
    public float colDepth = 4f;
    public float zPosition = 0f;
    private Vector2 screenSize;
    private Transform topCollider;
    private Transform bottomCollider;
    private Transform leftCollider;
    private Transform rightCollider;
    private Vector3 cameraPos;

    [SerializeField] private PhysicsMaterial2D _material;
    // Use this for initialization
    void Start () {
    //Generate our empty objects
        topCollider = new GameObject().transform;
        bottomCollider = new GameObject().transform;
        rightCollider = new GameObject().transform;
        leftCollider = new GameObject().transform;
 
    //Name our objects 
        topCollider.name = "TopCollider";
        bottomCollider.name = "BottomCollider";
        rightCollider.name = "RightCollider";
        leftCollider.name = "LeftCollider";
       
    //Add the colliders
        BoxCollider2D bxTop = topCollider.gameObject.AddComponent<BoxCollider2D>();
        BoxCollider2D bxBot = bottomCollider.gameObject.AddComponent<BoxCollider2D>();
        BoxCollider2D bxR = rightCollider.gameObject.AddComponent<BoxCollider2D>();
        BoxCollider2D bxL = leftCollider.gameObject.AddComponent<BoxCollider2D>();
       
    //Make them the child of whatever object this script is on, preferably on the Camera so the objects move with the camera without extra scripting
        topCollider.parent = transform;
        bottomCollider.parent = transform;
        rightCollider.parent = transform;
        leftCollider.parent = transform; 
        
        // Makes the walls colliders bouncy
        bxTop.sharedMaterial = _material;
        bxBot.sharedMaterial = _material;
        bxR.sharedMaterial = _material;
        bxL.sharedMaterial = _material;
        
    //Generate world space point information for position and scale calculations
        cameraPos = Camera.main.transform.position;
        screenSize.x = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
        screenSize.y = Vector2.Distance (Camera.main.ScreenToWorldPoint(new Vector2(0,0)),Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
        Debug.Log(screenSize);
        
       
    //Change our scale and positions to match the edges of the screen...   
        rightCollider.localScale = new Vector3(colDepth, screenSize.y * 4, colDepth);
        rightCollider.position = new Vector3(cameraPos.x + screenSize.x + (rightCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        leftCollider.localScale = new Vector3(colDepth, screenSize.y * 4, colDepth);
        leftCollider.position = new Vector3(cameraPos.x - screenSize.x - (leftCollider.localScale.x * 0.5f), cameraPos.y, zPosition);
        topCollider.localScale = new Vector3(screenSize.x * 4, colDepth, colDepth);
        topCollider.position = new Vector3(cameraPos.x, cameraPos.y + screenSize.y + (topCollider.localScale.y * 0.5f), zPosition);
        bottomCollider.localScale = new Vector3(screenSize.x * 4, colDepth, colDepth);
        bottomCollider.position = new Vector3(cameraPos.x , cameraPos.y - screenSize.y - (bottomCollider
        .localScale.y * 0.5f), zPosition);
    }
}
