using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankManager : MonoBehaviour
{ 
    [SerializeField] private Transform mTankObject;
    [SerializeField] private Transform mTankTop;
    [SerializeField] private float mTankSpeed = 0.2f;
    [SerializeField] private float mRotationSpeed = 0.2f;
    [SerializeField] private Shooter shooter;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mTankObject.Translate(Vector3.up * mTankSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mTankObject.Translate(Vector3.down * mTankSpeed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mTankObject.Rotate(Vector3.back * mRotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mTankObject.Rotate(Vector3.forward * mRotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            mTankTop.Rotate(Vector3.back * mRotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            mTankTop.Rotate(Vector3.forward * mRotationSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooter.Shoot(mTankTop.transform);
        }
        
        if (mTankObject.localPosition.x < -6)
        {
            mTankObject.localPosition = new Vector3(-6, mTankObject.localPosition.y, mTankObject.localPosition.z);
        }
    }
}
