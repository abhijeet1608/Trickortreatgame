using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerscore : MonoBehaviour
{
    public static playerscore instance;

    public int score, highscore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hscoreText;
    void Start()
    {
        score = 0;
        highscore = PlayerPrefs.GetInt("HScore");
        hscoreText.text = PlayerPrefs.GetInt("HScore").ToString();

    }
    public void Awake()
    {
        MakeInstance();
    }
    void Update()
    {
        scoreText = GameObject.Find("scoretext").GetComponent<TextMeshProUGUI>();
        hscoreText = GameObject.Find("hscoretext").GetComponent<TextMeshProUGUI>();
        //Singleton Pattern Implemented
    }
    void MakeInstance()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void AddScore()
    {
        score++;
        UpdateHS();
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score);
    }
    public int GetScore()
    {
        return this.score;
    }
    public void UpdateHS()
    {
        if (score > highscore)
        {
            highscore = score;
            hscoreText.text = highscore.ToString();
            PlayerPrefs.SetInt("HScore", highscore);
        }
    }
    public int HighScore()
    {
        return this.highscore;
    }
    
}
