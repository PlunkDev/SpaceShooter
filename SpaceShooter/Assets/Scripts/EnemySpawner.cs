using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 2f;

    public float minXSpawn = -8f;
    public float maxXSpawn = 8f;

    public float ySpawn = 6f;

    private float timeSinceLastAction = 0f;

    List<GameObject> spawnedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAction += Time.deltaTime;
        if(timeSinceLastAction >= spawnRate)
        {
            SpawnEnemy();
        }

    }

    void SpawnEnemy()
    {
        float xPosition = Random.Range(minXSpawn, maxXSpawn);
        Vector2 spawnPosition = new Vector2(xPosition, ySpawn);
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, this.transform);

        timeSinceLastAction = 0f;

        spawnedEnemies.Add(spawnedEnemy);
    }
}
