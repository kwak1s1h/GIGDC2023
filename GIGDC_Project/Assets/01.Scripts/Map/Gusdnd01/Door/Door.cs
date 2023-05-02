using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int nextMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (nextMap >= MapManager.Instance.MapList.Count)
                print("Dungeon Clear");
            else
                collision.transform.position = MapManager.Instance.MapList[nextMap].transform.position;
        }
    }
}
