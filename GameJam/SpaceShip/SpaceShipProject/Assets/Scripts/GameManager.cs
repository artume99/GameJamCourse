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
    public int currentScene;
    
    // Resources
    public AudioSource sheepSound;
    public AudioSource pauseSound;
    public AudioSource engineSound;
    public AudioSource backgroundSound;
    public AudioClip runnerBackgroundSound;
    public AudioClip astroidBackgroundSound;
    public Dictionary<string, AudioSource> AudioSources;
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
        AudioSources = new Dictionary<string, AudioSource>
        {
            {"pause",pauseSound},
            {"sheep", sheepSound},
            {"engine", engineSound},
            {"back", backgroundSound}
        };
        currentScene = 0;
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
        currentScene = 1 - currentScene;
        AudioSources["back"].clip = astroidBackgroundSound;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    private IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
    
}
