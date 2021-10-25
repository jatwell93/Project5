using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public int enemiesCount;
    public int waveNumber = 1;
    public GameObject enemiesPrefab;
    public GameObject powerupsPrefabs;
    private readonly float randomRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewWave(waveNumber);
        Instantiate(powerupsPrefabs, GenerateSpawnPos(), powerupsPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = FindObjectsOfType<Enemy>().Length;
        
        if (enemiesCount == 0)
        {
            waveNumber++;
            SpawnNewWave(waveNumber);
            Instantiate(powerupsPrefabs, GenerateSpawnPos(), powerupsPrefabs.transform.rotation);
        }
    }

    void SpawnNewWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemiesPrefab, GenerateSpawnPos(), enemiesPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnRangeX = Random.Range(-randomRange, randomRange);
        float spawnRangeZ = Random.Range(-randomRange, randomRange);
        Vector3 randomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);

        return randomPos;
    }
}
