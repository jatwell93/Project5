using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public int enemiesCount;
    public int waveNumber = 1;
    public GameObject[] enemiesPrefab;
    public GameObject[] powerupsPrefab;

    private readonly float randomRange = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewWave(waveNumber);
        int randomPowerup = Random.Range(0, powerupsPrefab.Length);
        Instantiate(powerupsPrefab[randomPowerup], GenerateSpawnPos(), powerupsPrefab[randomPowerup].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        WaveManager();
    }

    void SpawnNewWave(int enemiesToSpawn)
    {
        int obstacleIndex = Random.Range(0, enemiesPrefab.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemiesPrefab[obstacleIndex], GenerateSpawnPos(), enemiesPrefab[obstacleIndex].transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnRangeX = Random.Range(-randomRange, randomRange);
        float spawnRangeZ = Random.Range(-randomRange, randomRange);
        Vector3 randomPos = new Vector3(spawnRangeX, 0, spawnRangeZ);

        return randomPos;
    }

    void WaveManager()
    {
        enemiesCount = FindObjectsOfType<Enemy>().Length;

        if (enemiesCount == 0)
        {
            waveNumber++;
            SpawnNewWave(waveNumber);
            int randomPowerup = Random.Range(0, powerupsPrefab.Length);
            Instantiate(powerupsPrefab[randomPowerup], GenerateSpawnPos(), powerupsPrefab[randomPowerup].transform.rotation);
        }
    }
}
