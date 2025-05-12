using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] private int scoreAmount = 100;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}