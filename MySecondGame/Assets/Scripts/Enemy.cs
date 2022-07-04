using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer;
    public float timeToMove;
    int numOfMove = 0;
    float speed = 0.1f;
    public GameObject enemyProjectile;
    public Transform storage;
    private void Start()
    {
        storage = GameObject.Find("EnemyProjectileClone").transform;
    }
    private void FixedUpdate()
    {
        if (GameManager.state == "Play")
        {
            MoveEnemy();
            EnemyFireProjectile();
        }
    }

    void EnemyFireProjectile()
    {
        if (Random.Range(0f, 4400f) < 1)
        {
            SpawnBullet();
        }
    }

    void SpawnBullet()
    {
        GameObject enemyProjectileClone = Instantiate(enemyProjectile) as GameObject;
        enemyProjectileClone.transform.position = new Vector3(
            transform.position.x,
            transform.position.y - 0.5f,
            transform.position.z);
        enemyProjectileClone.transform.SetParent(storage);
    }

    void MoveEnemy()
    {
        timer += Time.deltaTime;
        //Debug.Log("timer: " + timer);
        if (timer > timeToMove && numOfMove < 45)
        {
            transform.position += new Vector3(speed, 0, 0);
            timer = 0;
            numOfMove++;
        }
        if (numOfMove == 45)
        {
            transform.position += new Vector3(0, -0.2f, 0);
            numOfMove = 0;
            speed = -speed;
            timer = 0;
        }
    }
}
