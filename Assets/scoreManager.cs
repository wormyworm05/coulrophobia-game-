using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text scoreText;

    private int totalScore = 0;

    void Awake()
    {
        //so other scripts can call GameManager.Instance
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int points)
    {
        totalScore += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = totalScore.ToString("D4");
    }

    public void ResetScore()
    {
        totalScore = 0;
        UpdateScoreUI();
    }
}

