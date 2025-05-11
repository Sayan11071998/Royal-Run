using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private float[] lanes = { -2.5f, 0f, 2.5f };

    private void Start()
    {
        SpawnFence();
    }

    private void SpawnFence()
    {
        List<int> availableLens = new List<int> { 0, 1, 2 };
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLens.Count <= 0) break;

            int randomLaneIndex = Random.Range(0, availableLens.Count);
            int selectedLane = availableLens[randomLaneIndex];
            availableLens.RemoveAt(randomLaneIndex);

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }
    }
}