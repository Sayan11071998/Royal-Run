using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] private int scoreAmount = 100;

    private ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}