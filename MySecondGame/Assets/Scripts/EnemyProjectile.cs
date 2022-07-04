using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Transform enemy;
    public Transform storage;
    private void Start()
    {
        storage = GameObject.Find("EnemyProjectileClone").transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -3 * Time.deltaTime, 0));
        if ((transform.position.y + 8) < enemy.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
