using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    public void IncreaseScore(int amount)
    {
        if (gameManager.GameOver) return;

        score += amount;
        scoreText.text = score.ToString();
    }
}