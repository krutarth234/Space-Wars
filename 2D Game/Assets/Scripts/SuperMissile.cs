using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperMissile : MonoBehaviour
{
    public float speed = 10.0f; // Speed at which the missile moves
    public float seekRadius = 10.0f; // Radius within which it seeks enemies
    public float detonationTime = 1.5f; // Time before detonation
    
    private bool isDetonating = false;
    private float detonationTimer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (!isDetonating)
        {
            SeekAndDestroyEnemies(seekRadius);
        }
        else
        {
            detonationTimer += Time.deltaTime;
            if (detonationTimer >= detonationTime)
            {
                Destroy(gameObject); // Destroy the missile after the detonation time is over
            }
        }
    }

    public void SeekAndDestroyEnemies(float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("EnemySprite"))
            {
                MoveAndDestroy(collider.transform);
            }
        }
    }

    private void MoveAndDestroy(Transform enemyTransform)
    {
        Vector3 direction = (enemyTransform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        
        float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);
        if (distanceToEnemy < 2.0f) // Adjust this value for proximity sensitivity
        {
            Destroy(enemyTransform.gameObject);
            Score.instance.AddScore(50);
            Debug.Log("Destroyed enemy: " + enemyTransform.name);
        }
    }

    public void Detonate()
    {
        isDetonating = true;
    }
}