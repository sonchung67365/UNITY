using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleSpawn : MonoBehaviour
{
    public Transform pos1, pos2;
    public GameObject triangle;
    private void Start()
    {
        int x = Random.Range(1, 3);
        if (x == 1)
        {
            SpawnTriangle(pos1);
        }
        x = Random.Range(1, 3);
        if (x == 1)
        {
            SpawnTriangle(pos2);
        }
    }

    void SpawnTriangle(Transform pos)
    {
        GameObject Triangle = Instantiate(triangle) as GameObject;
        Triangle.transform.position = pos.position;
        Triangle.transform.SetParent(transform);
    }
}
