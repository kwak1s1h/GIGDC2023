using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    [SerializeField] private GameObject[] mapList;
    [SerializeField] private int mapListCnt = 3;

    [SerializeField] private int _suffleAmount = 100;

    private void Awake() {
        Init();

        for(int i = 0; i < mapListCnt;i++){
            MapInstantiate(i, new Vector2(20 * i, 0));
        }
    }

    [ContextMenu("GOGO")]
    public void GOGO()
    {
        Init();

        for (int i = 0; i < mapListCnt; i++)
        {
            MapInstantiate(i, new Vector2(20 * i, 0));
        }
    }

    public void MapInstantiate(int index, Vector2 ins_Pos){
        GameObject map_Inc = Instantiate(mapList[index]);
        map_Inc.transform.position = ins_Pos;
    }
    private void Init(){
        GameObject temp;
        int F_randNum = 0;
        int S_randNum = 0;
        for(int i = 0; i < _suffleAmount; i++){
            F_randNum = Random.Range(0,6);
            S_randNum = Random.Range(0,6);
            temp = mapList[F_randNum];
            mapList[F_randNum] = mapList[S_randNum];
            mapList[S_randNum] = temp;
        }
    }
}
