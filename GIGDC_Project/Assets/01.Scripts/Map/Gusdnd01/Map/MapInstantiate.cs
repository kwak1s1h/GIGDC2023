using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstantiate : MonoBehaviour
{
    [SerializeField] private MapBase[] mapList;
    [SerializeField] private int mapListCnt = 3;

    [SerializeField] private int _suffleAmount = 100;

    private void Awake() {
        Init();
    }

    private void Start()
    {
        for (int i = 0; i < mapListCnt; i++)
        {
            MapInit(i, new Vector2(200 * i, 0));
        }
    }

    [ContextMenu("GOGO")]
    public void GOGO()
    {
        Init();

        for (int i = 0; i < mapListCnt; i++)
        {
            MapInit(i, new Vector2(100 * i, 0));
        }
    }

    public void MapInit(int index, Vector2 ins_Pos){
        GameObject map_Inc = Instantiate(mapList[index].gameObject);
        MapBase mb = map_Inc.GetComponent<MapBase>();
        mb.CurrentMapIndex = index;
        MapManager.Instance.MapList.Add(mb);
        map_Inc.transform.position = ins_Pos;
    }
    private void Init(){
        MapBase temp;
        int F_randNum = 0;
        int S_randNum = 0;
        for(int i = 0; i < _suffleAmount; i++){
            F_randNum = Random.Range(0, mapList.Length);
            S_randNum = Random.Range(0, mapList.Length);
            temp = mapList[F_randNum];
            mapList[F_randNum] = mapList[S_randNum];
            mapList[S_randNum] = temp;
        }
    }
}
