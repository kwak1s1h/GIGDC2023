using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    [SerializeField] private GameObject[] mapList;
    [SerializeField] private int mapListCnt = 3;
    private void Awake() {
        int randNum = 0;

        for(int i = 0; i < mapListCnt;i++){
            randNum = UnityEngine.Random.Range(0, 6);
            MapInstantiate(randNum, new Vector2(20 * i, 0));
        }
    }

    public void MapInstantiate(int index, Vector2 ins_Pos){
        GameObject map_Inc = Instantiate(mapList[index]);
        map_Inc.transform.position = ins_Pos;
    }
}
