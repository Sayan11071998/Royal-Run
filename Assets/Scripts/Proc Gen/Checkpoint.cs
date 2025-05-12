using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private float checkpointTimeExtension = 5f;

    private GameManager gameManager;

    private const string PlayerString = "Player";

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerString))
        {
            gameManager.IncreaseTime(checkpointTimeExtension);
        }
    }
}