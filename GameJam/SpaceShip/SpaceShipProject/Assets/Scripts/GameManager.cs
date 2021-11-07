using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    // GAME STATE
    public int score;
    public int partCollected;
    public int endLevel = 5;
    private float transitionTime = 3.2f;

    // References
    public Ship ship;
    public Menu menu;
    public Animator transition;
    
    // Resources
    // public Dictionary<string, AudioSource> audio;
    public Sprite[] SpaceShipParts;

    private void Awake()
    {
        if (GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        menu.UpdateMenu();
        // audio = new Dictionary<string, AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menu.Pause();
        }
    }

    public void AddScore()
    {
        score += 1;
        menu.UpdateMenu();
    }

    public void AddPart()
    {
        partCollected += 1;
        if (partCollected == endLevel)
        {
           LoadNextLevel();
        }
        menu.UpdateMenu();
    }

    public int GetCurrentPointCount()
    {
        return score;
    }

    public int GetCurrentPartCount()
    {
        return partCollected;
    }

    

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
}
