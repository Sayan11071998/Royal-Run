using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float obstacleSpawnTime = 1f;

    private int obstaceleSpawned = 0;

    private void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (obstaceleSpawned < 5)
        {
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, transform.position, quaternion.identity);
            obstaceleSpawned++;
        }
    }
}