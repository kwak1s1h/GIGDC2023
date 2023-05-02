using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

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
