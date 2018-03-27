using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    private int Score = 0;
    private int HighScore;
    public Text ScoreText;
    public Text FinalScoreText;
    public Text HighScoreText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset()
    {
        Score = 0;
        ScoreText.text = Score.ToString();
    }

    public void IncrementScore(int amount)
    {
        Score += amount;
        if(Score % 15 == 0)
        {
            Camera.main.GetComponent<CameraMovement>().SpeedAmount += 0.02f;
        }
        ScoreText.text = Score.ToString();
    }

    public void UpdateFinalScore()
    {
        if(HighScore < Score)
        {
            HighScore = Score;
        }
        FinalScoreText.text = Score.ToString();
        HighScoreText.text = HighScore.ToString();
        
    }
}
