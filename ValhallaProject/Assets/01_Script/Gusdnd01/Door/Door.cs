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
            if (nextMap >= GameManager.Instance.MapList.Count)
                print("Dungeon Clear");
            else
                collision.transform.position = GameManager.Instance.MapList[nextMap].transform.position;
        }
    }
}
