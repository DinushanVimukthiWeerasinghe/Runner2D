using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public ScoreManager scoreManager;
    public AudioSource backgroundMusic;
    public AudioSource deathMusic;
    public ScrollingBackground backgroundRenderer;
    public HealthManager healthManager;
    public int noOfLevels = 10;
    
    private Vector3 playerStartPoint;
    private Vector3 groundGeneratorStartPoint;
    
    public GroundGenerator groundGenerator;
    
    public GameObject largeGround;
    public GameObject smallGround;
    
    public GameObject gameOverScreen;
    public GameObject gameStartMenu;
    public GameObject levelCompleteScreen;
    public Text gameLevelText;
    
    public List<float> levelMilestomns;
    private int currentMilestoneIndex = 0;
    
    void Start()
    {
        //generate Levels
        levelMilestomns = new List<float>();
        int multiplier = 1;
        for (int i = 0; i < noOfLevels; i++)
        {
            levelMilestomns.Add(multiplier * 500);
            multiplier *= 2;
        }
        gameLevelText.text = (currentMilestoneIndex + 1).ToString();
        playerStartPoint = player.transform.position;
        groundGeneratorStartPoint = groundGenerator.transform.position;
        backgroundRenderer = FindObjectOfType<ScrollingBackground>();
        GameStartMenu();
    }

    private void Update()
    {
        print(levelMilestomns[currentMilestoneIndex]);
        if (scoreManager.score > levelMilestomns[currentMilestoneIndex])
        {
            LevelCompleted();
        }
    }

    void LevelCompleted()
    {
        healthManager.resetHealth();
        player.gameObject.SetActive(false);
        levelCompleteScreen.SetActive(true);
        scoreManager.scoreIncreasing = false;
        player.speed = player.speed * 1.1f;
        currentMilestoneIndex++;
        // backgroundMusic.Stop();
    }
    
    public void nextLevel()
    {
        player.gameObject.SetActive(true);
        levelCompleteScreen.SetActive(false);
        scoreManager.score = 0;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y+5, player.transform.position.z);
        scoreManager.scoreIncreasing = true;
        backgroundRenderer.scrollEnabled = true;
        gameLevelText.text = (currentMilestoneIndex + 1).ToString();
    }

    private void GameStartMenu()
    {
        gameStartMenu.SetActive(true);
        gameOverScreen.SetActive(false);
        levelCompleteScreen.SetActive(false);
        player.gameObject.SetActive(false);
        scoreManager.scoreIncreasing = false;
        backgroundMusic.Play();
    }

    public void StartGame()
    {
        instance = this;
        
        player.gameObject.SetActive(true);
        gameOverScreen.SetActive(false);
        gameStartMenu.SetActive(false);
        scoreManager.scoreIncreasing = true;
        backgroundRenderer.scrollEnabled = true;
    }
    
    public void GameOver ()
    {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManager.scoreIncreasing = false;
        backgroundMusic.Stop();
        deathMusic.Play();
    }
    
    public void Quit ()
    {
        Application.Quit();
    }
    
    
    public void Restart ()
    {
        GroundDestroyer[] groundDestroyers = FindObjectsOfType<GroundDestroyer>();
        foreach (GroundDestroyer groundDestroyer in groundDestroyers)
        {
            groundDestroyer.gameObject.SetActive(false);
        }
        largeGround.SetActive(true);
        smallGround.SetActive(true);
        player.transform.position = playerStartPoint;
        groundGenerator.transform.position = groundGeneratorStartPoint;
        player.gameObject.SetActive(true);
        gameOverScreen.SetActive(false);
        scoreManager.scoreIncreasing = true;
        scoreManager.score = 0;
        backgroundMusic.Play();
        healthManager.resetHealth();
        
    }

    public void SwitchScene()
    {
        int sceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex + 1);
    }

}
