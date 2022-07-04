using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject projectile;
    public Transform storage;
    float horizontal;
    float vertical;
    public MusicManager music;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        FireProjectile();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed * horizontal, speed * vertical);
    }

    void FireProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectileClone = Instantiate(projectile) as GameObject;
            projectileClone.transform.position = new Vector3(
                transform.position.x, 
                transform.position.y + 0.7f,
                transform.position.z);
            projectileClone.transform.SetParent(storage);
            music.PlayShoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameObject.transform.position = new Vector3(5, -4, 0);
            GameManager.lives--;
        }
    }
}
