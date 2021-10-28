using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadScript : MonoBehaviour
{
    [SerializeField]
    private int mBadParam = 0;

    private float mTimeMeasure;
    // Start is called before the first frame update
    void Start()
    {
        mTimeMeasure = 1;
    }

    private int frameCounter = 0;
    // Update is called once per frame
    void Update()
    {
        int stam = 0;
        frameCounter++;
        mTimeMeasure -= Time.deltaTime;
        if (mTimeMeasure <= 0)
        {
            mTimeMeasure = 1;

            Debug.Log("Frames: " + frameCounter);
            
            frameCounter = 0;
        }
        for (int a = 0; a < mBadParam; a++)
        {
            for (int b = 0; b < 1000; b++)
            {
                stam += 100;
                
            }
        }
    }
}
