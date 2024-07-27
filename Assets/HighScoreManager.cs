using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text highScoreText;  // Yüksek skoru gösterecek UI Text bileşeni
    private int highScore = 0;
    private const string HighScoreKey = "HighScore";

    void Start()
    {
        // Yüksek skoru yükleyin
        LoadHighScore();
        UpdateHighScoreUI();
    }

    public void CheckForHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
            UpdateHighScoreUI();
        }
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey);
        }
    }
    private void UpdateHighScoreUI()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}