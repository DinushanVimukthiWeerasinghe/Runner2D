using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private AudioSource coinSound;
    public float coinPoint = 15f;
    private ScoreManager scoreManager;
    void Start()
    {
        coinSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            if (coinSound.isPlaying)
            {
                coinSound.Stop();
            }
            coinSound.Play();
            // Increase the score
            scoreManager.score += coinPoint;
        }
    }
}
