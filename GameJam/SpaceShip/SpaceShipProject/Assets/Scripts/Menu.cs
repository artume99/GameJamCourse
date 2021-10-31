using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text Points;
    [SerializeField] private Image PauseImage;
    [SerializeField] private Text Parts;
    private bool pause = false;

    public void UpdateMenu()
    {
        Points.text = GameManager.Instance.GetCurrentPointCount().ToString();
        Parts.text = GameManager.Instance.GetCurrentPartCount().ToString();

    }

    public void Pause()
    {
        if (pause)
        {
            Time.timeScale = 1;
            pause = false;
        }
        else
        {
            Time.timeScale = 0;
            pause = true;
        }
        PauseImage.enabled = !PauseImage.enabled;
    }
}
