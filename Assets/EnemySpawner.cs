using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Vector2 MinMaxPos;                // Range on the X-axis
    public Vector2 SpawnIntervalRange = new Vector2(0.5f, 2f); // Min and Max interval

    public int MaxEnemies = 10;              // Total enemies to spawn
    private int enemiesSpawned = 0;          // Counter

    private float spawnTimer;

    public GameObject Enemy;

    void Start()
    {
        SetRandomSpawnTime();
    }

    void Update()
    {
        if (enemiesSpawned >= MaxEnemies)
            return;

        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemy();
            SetRandomSpawnTime();
        }
    }

    void SetRandomSpawnTime()
    {
        spawnTimer = Random.Range(SpawnIntervalRange.x, SpawnIntervalRange.y);
    }

    void SpawnEnemy()
    {
        if (Enemy)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(MinMaxPos.x, MinMaxPos.y),
                transform.position.y,
                transform.position.z
            );

            Instantiate(Enemy, randomPosition, Quaternion.identity);
            enemiesSpawned++;
        }
    }
}
