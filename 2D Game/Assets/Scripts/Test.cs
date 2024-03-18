using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject EnemyBulletPrefab;
    [SerializeField] Transform EnemyFirePoint;
    //[SerializeField] AudioSource EnemyShoot;
    public float timer;
    void Start()
    {
        Instantiate(EnemyBulletPrefab, EnemyFirePoint.position, Quaternion.identity);
        MainController.Instance.SoundManager.PlaySFX("EnemyShoot");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.5f)
        {
            timer = 0;
            Instantiate(EnemyBulletPrefab, EnemyFirePoint.position, Quaternion.identity);
           // MainController.Instance.SoundManager.PlaySFX("EnemyShoot");
            //EnemyShoot.Play();
            
        }
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(this.gameObject);
    //        Destroy(collision.gameObject);
    //    }
    //}
}
