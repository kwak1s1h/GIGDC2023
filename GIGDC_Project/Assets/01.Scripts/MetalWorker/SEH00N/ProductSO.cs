using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Product")]
public class ProductSO : ScriptableObject
{
    [SerializeField] string productionName;
    public string ProductionName => productionName;

    [SerializeField] Sprite productionSprite;
    public Sprite ProductionSprite => productionSprite;

    [SerializeField] List<MaterialID> productionID;
    public List<MaterialID> ProductionID => productionID;
}
