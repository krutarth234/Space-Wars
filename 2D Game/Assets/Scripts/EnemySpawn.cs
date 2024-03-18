using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] private GameObject healthPickupPrefab;
    [SerializeField] private float dropChance = 0.15f; // 15% chance to drop


    // [SerializeField] GameObject Explosion;

    private float Spawnrate = 1.25f;
    private float timer = 1.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0f;
        }

    }
    // void spawnEnemy()
    // {
    //     Instantiate(EnemyPrefab, new Vector3(7.6f, Random.Range(-4.0f, 3.5f), 0f), Quaternion.Euler(0f,0f,90f)); // 90 for rotation, it was spawning left
    //     //Instantiate(EnemyBulletPrefab, new Vector3(7.6f, Random.Range(-4.0f, 3.5f), 0f), Quaternion.Euler(0f, 0f, 0f)); // 90 for rotation, it was spawning left
    // }
   void spawnEnemy()
{
    float spawnX = 7.6f; // X position for enemy and health pickup
    float spawnY = Random.Range(-4.0f, 3.5f); // Y position for enemy and health pickup

    Instantiate(EnemyPrefab, new Vector3(spawnX, spawnY, 0f), Quaternion.Euler(0f, 0f, 90f));

    // Check if a health pickup should be dropped
    if (Random.value < dropChance)
    {
        float healthPickupSpawnY = Random.Range(0f, 1f); // Adjust Y range for health pickup
        Instantiate(healthPickupPrefab, new Vector3(spawnX, healthPickupSpawnY, 0f), Quaternion.identity);
    }
}

}
