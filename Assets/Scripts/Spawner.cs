using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<ChunkData> chunks;
    [SerializeField] private List<CollectibleData> collectibles;

    [SerializeField] private Transform chunkContainer;
    [SerializeField] private Transform collectibleContainer;

    [SerializeField] private GameObject chunk;

    private float spawnRate = 1f;
    private float lastSpawn = 0f;

    private int lastChunkId = -1;

    private void Update()
    {
        lastSpawn += Time.deltaTime;
        if(lastSpawn >= spawnRate)
        {
            SpawnCollectible();
            lastSpawn = 0f;
        }
    }

    private void SpawnCollectible()
    {
        Debug.Log("Spawning collectible");
        Instantiate(collectibles[0].prefab, transform.position, Quaternion.identity, collectibleContainer);
    }

    private GameObject RandomizedChunk()
    {
        float totalSpawnRate = 0f;

        foreach (var chunk in chunks) { totalSpawnRate += chunk.spawnRate; }

        float randodmized = Random.Range(0f, totalSpawnRate);
        float cumulative = 0f;

        for (int i = 0; i < chunks.Count; i++)
        {
            cumulative += chunks[i].spawnRate;
            if(randodmized <= cumulative)
            {
                if (i == lastChunkId)
                    return RandomizedChunk();

                lastChunkId = i;
                return chunks[i].prefab;
            }
        }
        return chunks[0].prefab;


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Transform chunkEnd = other.gameObject.transform.Find("End");
            Instantiate(RandomizedChunk(), chunkEnd.position, Quaternion.identity, chunkContainer);
        }
    }
}
