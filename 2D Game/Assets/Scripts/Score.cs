using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] Text Myscoretext;
    [SerializeField] Text highScoreText;
    [SerializeField] int score;
    private int highScore;

    private void Awake()
    {
        instance = this;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
    void Start()
    {
        score = 0;
        Myscoretext.text = "Score: " + score;
        UpdateHighScoreText();
    }
    public void AddScore(int amount)
    {
        score += amount;
        Myscoretext.text = "Score: " + score;
        
        
        CheckForHighScore();
        UpdateHighScoreText();
    }
    private void CheckForHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        // Assuming you have a Text component to display the high score
        highScoreText.text = "High Score: " + highScore;
       
    }
    public void AddBulletScore(int amount)
    {
        score += amount;
        Myscoretext.text = "Score: " + score;

        CheckForHighScore();
        UpdateHighScoreText();
    }
    public void AddObstacleScore()
    {
        score += 25; // 2points for hitting the bullets
        Myscoretext.text = "Score: " + score;

        CheckForHighScore();
        UpdateHighScoreText();
    }

    public int GetScore(){return score;}
    public void SetScore(int value) { score = value; }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
