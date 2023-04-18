using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<MapBase> MapList = new List<MapBase>();

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError($"Multiple Instance is running! : {Instance.name}");
        }
        Instance = this;
    }
}
