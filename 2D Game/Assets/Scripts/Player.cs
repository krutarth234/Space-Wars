using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] float playerSpeed = 9.0f;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject superMissilePrefab;
    [SerializeField] GameObject Explosion;
    // [SerializeField] AudioSource Shoot;

    //[SerializeField] GameObject ExplosionPrefab;
    float xInput;
    float yInput;

    //[SerializeField] float HitPoints;
    //[SerializeField] float MaxHitPoints = 4;

    [SerializeField] float HitPoints;
    [SerializeField] float MaxHitPoints = 4;
    GameObject[] healthImages = new GameObject[4];
    bool HasBeenHit = false;

    public GameManager gameManager;
    private bool isDead;


    void Start()
    {
        healthImages = new GameObject[4];

        for (int i = 0; i < 4; i++)
        {
            healthImages[i] = GameObject.Find("HealthImage" + (i + 1));
        }
        HitPoints = MaxHitPoints;
    }
    public void TakeHit(float damage)
    {
        if (HasBeenHit)
        {
            return; // Skip updating health images
        }
        HitPoints -= damage;
        HasBeenHit = true;

        for (int i = 0; i < HitPoints; i++)
        {
            healthImages[i].SetActive(true);
        }

        for (int i = (int)HitPoints; i < MaxHitPoints; i++)
        {
            healthImages[i].SetActive(false);
        }
        HasBeenHit = false; // Reset hit flag
        if (HitPoints <= 0 && !isDead)
        {
            isDead = true;
            Destroy(gameObject);
            gameObject.SetActive(false);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            gameManager.GameOver();

        }

    }
    public void RestoreHealth(float healthAmount)
    {
        HitPoints = Mathf.Min(HitPoints + healthAmount, MaxHitPoints);
        UpdateHealthImages();
    }

    private void UpdateHealthImages()
    {
        for (int i = 0; i < HitPoints; i++)
        {
            healthImages[i].SetActive(true);
        }
        for (int i = (int)HitPoints; i < MaxHitPoints; i++)
        {
            healthImages[i].SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Obstacle")
        // {
        //     TakeHit(0.25f); // Reduce health by 1 point
        // }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            TakeHit(0.5f);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            TakeHit(0.5f);
            Score.instance.AddObstacleScore();
        }
        else if (collision.gameObject.tag == "EnemySprite")
        {
            TakeHit(0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(xInput, yInput, 0f) * playerSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && Score.instance.GetScore() >= 100 && !GameManager.isPaused)
        {
            // Play the sound of a roaring cat
            MainController.Instance.SoundManager.PlaySFX("TomScream");
            ActivateCouscousSuperWeapon();
        }

        if (Input.GetMouseButtonDown(0) && !GameManager.isPaused)
        {
            //Shoot.Play();
            MainController.Instance.SoundManager.PlaySFX("PlayerShoot");
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.identity);
        }
    }
    void ActivateCouscousSuperWeapon()
    {

        // Instantiate the super missile at the player's position
        GameObject superMissileObject = Instantiate(superMissilePrefab, transform.position, Quaternion.identity);

        // Get the SuperMissile script component from the instantiated object
        SuperMissile superMissileScript = superMissileObject.GetComponent<SuperMissile>();

        // If the SuperMissile script is found, detonate after a delay
        if (superMissileScript != null)
        {
            StartCoroutine(DelayedDetonation(superMissileScript));
            // Deduct 100 points from the score after activation (if needed)
            Score.instance.AddScore(-1);
        }
        else
        {
            Debug.LogError("SuperMissile script not found on the instantiated super missile object.");
        }

        // // Deduct 100 points from the score after activation (if needed)
        // Score.instance.AddScore(75);
    }

    IEnumerator DelayedDetonation(SuperMissile superMissileScript)
    {
        yield return new WaitForSeconds(2.0f); // Wait for 5 seconds

        // Detonate the super missile after the delay
        superMissileScript.Detonate();
    }

    public float GetHitPoints() { return HitPoints; }
    public void SetHitPoints(float value) { HitPoints = value; }
}
