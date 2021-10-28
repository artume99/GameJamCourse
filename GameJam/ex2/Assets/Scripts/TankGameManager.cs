using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TankGameManager : MonoBehaviour
{
    [SerializeField] private Transform mTankObject;
    [SerializeField] private Transform mTankTop;
    [SerializeField] private Transform mFlower;
    [SerializeField] private float mMoveSpeed = 1;
    [SerializeField] private float mRotationSpeed = 1;
    [SerializeField] private float mShootSpeed = 1;

    private bool mIsShooting;

    private float mShootTime;

    private Vector3 mShootDirection;

    /// <summary>
    /// Keep the flower initial position so we can return to it after shoot
    /// </summary>
    private Vector3 mFlowerInitialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        mIsShooting = false;

        mFlowerInitialPosition = mFlower.localPosition;
        
        mFlower.gameObject.SetActive((false));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mTankObject.Translate(Vector2.up * mMoveSpeed);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            mTankObject.Translate(Vector2.down * mMoveSpeed);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            mTankObject.Rotate(Vector3.back * mRotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mTankObject.Rotate(Vector3.forward * mRotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            mTankTop.Rotate(Vector3.back * mRotationSpeed);
        }
        
        if (Input.GetKey(KeyCode.Z))
        {
            mTankTop.Rotate(Vector3.forward * mRotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!mIsShooting)
            {
                mIsShooting = true;

                mShootTime = 2;
                
                mFlower.SetParent(null);
                
                mFlower.gameObject.SetActive(true);

                mShootDirection = mTankTop.up;
                
                Debug.Log("Start Shoot");
            }
        }

        if (mIsShooting)
        {
            mFlower.localPosition += (mShootDirection * mShootSpeed);

            mShootTime -= Time.deltaTime;

            if (mShootTime <= 0)
            {
                mIsShooting = false;
                
                mFlower.SetParent(mTankTop);

                mFlower.localPosition = mFlowerInitialPosition;
                
                mFlower.gameObject.SetActive(false);
                
                Debug.Log("End Shoot");
            }
        }
    }
}
