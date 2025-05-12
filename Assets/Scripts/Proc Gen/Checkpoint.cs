using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float checkpointTimeExtension = 5f;
    [SerializeField] private float obstacleDecreaseSpawnTime = 0.2f;

    private GameManager gameManager;
    private ObstacleSpawner obstacleSpawner;

    private const string PlayerString = "Player";

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            gameManager.IncreaseTime(checkpointTimeExtension);
            obstacleSpawner.DecreaseObstacleSpawnTime(obstacleDecreaseSpawnTime);
        }
    }
}