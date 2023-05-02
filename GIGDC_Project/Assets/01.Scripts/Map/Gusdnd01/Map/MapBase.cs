using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBase : MonoBehaviour
{
    public int CurrentMapIndex;

    [SerializeField] private GameObject[] _obsList;
    [SerializeField] private Door[] _doorList;
    [SerializeField] private float _percent;

    private Door _curActiveDoor;

    private void Awake() {
        ObsSuffle();
        DoorSuffle();
    }

    private void DoorSuffle()
    {
        int idx1 = 0;
        int idx2 = 0;
        foreach(Door d in _doorList)
        {
            d.gameObject.SetActive(false);
        }
        for(int i  = 0;  i < 50; i++)
        {
            idx1 = UnityEngine.Random.Range(0, _doorList.Length);
            idx2 = UnityEngine.Random.Range(0, _doorList.Length);

            Door temp = _doorList[idx1];
            _doorList[idx1] = _doorList[idx2];
            _doorList[idx2] = temp;
        }

        _doorList[0].gameObject.SetActive(true);
    }
    private void Start()
    {
        _doorList[0].nextMap = CurrentMapIndex+1;

    }
    private void ObsSuffle()
    {
        int randNum = 0;
        for(int i = 0 ; i < _obsList.Length; i++){
            randNum = UnityEngine.Random.Range(0, 100);
            if(randNum <= _percent){
                _obsList[i].SetActive(true);
            }
            else{
                _obsList[i].SetActive(false);
            }
        }
    }
}
