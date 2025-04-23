using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float obstacleSpawnTime = 1f;

    private void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, Random.rotation);
        }
    }
}