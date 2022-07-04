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
    public Projectile pt;
    float timer;
    public float timeToCombo;
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
        
        if (Projectile.numOfCombo == 1)
        {
            timer += Time.deltaTime;
            Debug.Log("Timer" + timer);
        }
        if (Projectile.numOfCombo == 2)
        {
            if (timer <= timeToCombo)
            {
                GameManager.scoreCombo++;
                if (GameManager.scoreCombo >= 7) { GameManager.scoreCombo = 7; }
                GameManager.score += GameManager.scoreCombo;
                Projectile.numOfCombo = 1;
            }
            if (timer > timeToCombo)
            {
                GameManager.scoreCombo = 0;
                Projectile.numOfCombo = 0;
            }
            timer = 0;
            Debug.Log("Set timer = 0");
        }
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -8.45f, 8.45f);
        viewPos.y = Mathf.Clamp(viewPos.y, -4.64f, 4.58f);
        transform.position = viewPos;
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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            gameObject.transform.position = new Vector3(5, -4, 0);
            GameManager.lives--;
        }
    }
}
