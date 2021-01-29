using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float zSpawnRange = 22.0f;
    private float xSpawnRange = 22.0f;
    private float ySpawnPos = 2.0f;

    private float startDelay = 5.0f;
    private float enemySpawnTime = 7.0f;
    private float powerupSpawnTime = 20.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);

        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, randomZ);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        float randomZ = Random.Range(-zSpawnRange, zSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, ySpawnPos, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }

}
