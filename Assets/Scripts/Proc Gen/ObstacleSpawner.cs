using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    [SerializeField] private float obstacleSpawnTime = 1f;
    [SerializeField] private float minObstacleSpawnTime = 0.2f;
    [SerializeField] private Transform obstacleParent;
    [SerializeField] private float spawnWidth = 4f;

    private void Start() => StartCoroutine(SpawnObstacleRoutine());

    public void DecreaseObstacleSpawnTime(float amount)
    {
        obstacleSpawnTime -= amount;

        if (obstacleSpawnTime <= minObstacleSpawnTime)
            obstacleSpawnTime = minObstacleSpawnTime;
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y, transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition, Random.rotation, obstacleParent);
        }
    }
}