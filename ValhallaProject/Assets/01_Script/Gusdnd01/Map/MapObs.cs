using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObs : MonoBehaviour
{
    [SerializeField] private GameObject[] obsList;
    [SerializeField] private float percent;

    private void Awake() {
        int randNum = 0;
        for(int i = 0 ; i < obsList.Length; i++){
            randNum = UnityEngine.Random.Range(0, 100);
            if(randNum <= percent){
                obsList[i].SetActive(true);
            }
            else{
                obsList[i].SetActive(false);
            }
        }
    }
}
