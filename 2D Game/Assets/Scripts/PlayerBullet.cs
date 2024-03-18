using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour
{

    [SerializeField] float PlayerBulletSpeed = 3.0f;
    [SerializeField] GameObject Explosion;
 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (PlayerBulletSpeed * Time.deltaTime));
        if (transform.position.x >= 6.6f)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemySprite")
        {
            Score.instance.AddScore(10);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Score.instance.AddBulletScore(10);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
