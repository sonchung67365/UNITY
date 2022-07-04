using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDelete : MonoBehaviour
{
    public Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }
    void LateUpdate()
    {
        if (transform.position.x < (player.transform.position.x - 10))
        {
            Destroy(gameObject);
        }
    }
}
