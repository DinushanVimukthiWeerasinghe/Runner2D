using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float pointsPerSecond = 5;
    
    public Text scoreText;
    public Text highScoreText;
    public bool scoreIncreasing;
    
    public float score;
    private float highScore;
    public float currentMileStone;
    void Start()
    {
        scoreIncreasing = true;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetFloat("HighScore");
        }
        else
        {
            highScore = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            score += pointsPerSecond * Time.deltaTime;
        }
        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }
        

        highScoreText.text =Mathf.Round(highScore).ToString();
        scoreText.text = Mathf.Round(score).ToString();
    }
}
