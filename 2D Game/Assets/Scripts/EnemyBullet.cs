using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float EnemyBulletSpeed = 3.0f;

    //int hitPoints = 4;
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * (EnemyBulletSpeed * Time.deltaTime));
        if (transform.position.x <= -6.3f)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var enemy = collision.collider.GetComponent<Player>();
            if (enemy)
            {
                enemy.TakeHit(0.5f);
                //Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
           // Destroy(collision.gameObject);
 
        }
    }
}
