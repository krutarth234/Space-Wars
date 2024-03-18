using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthValue = 1f; // The amount of health to restore
    float healthDropSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * (healthDropSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.RestoreHealth(healthValue);
                Destroy(gameObject); // Destroy the health pickup after it's used
            }
        }
    }
}