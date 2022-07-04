using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawn : MonoBehaviour
{
    public GameObject floor;
    public int offset;
    public Transform storage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            offset = Random.Range(20, 25);
            GameObject floorpiece = Instantiate(floor) as GameObject;
            floorpiece.transform.position = new Vector3(transform.position.x + offset, -4.6f, 0);
            floorpiece.transform.SetParent(storage);
        }
    }

    public void ClearStorage()
    {
        for (int x = 0; x < storage.childCount; x++)
        {
            Destroy(storage.GetChild(x).gameObject);
        }
    }
}
