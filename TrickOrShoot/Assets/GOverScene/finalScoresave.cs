using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalScoresave : MonoBehaviour
{
    public TextMeshProUGUI fhscoretext;
    public TextMeshProUGUI fscoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fhscoretext.text = PlayerPrefs.GetInt("Hscore", playerscore.instance.highscore).ToString();
    }
    public void ResetScore()
    {
        playerscore.instance.highscore = 0;
        PlayerPrefs.SetInt("HScore", playerscore.instance.highscore);

    }
}
