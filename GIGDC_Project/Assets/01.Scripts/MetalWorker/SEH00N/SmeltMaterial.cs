using UnityEngine;

/// <summary>
/// 재련할 수 있는 재료 (원자제 상태)
/// </summary>
public class SmeltMaterial : MonoBehaviour
{
    [SerializeField] MaterialID materialID; //아이템을 재련할 때 아이템 확인용 ID
    public MaterialID MaterialID => materialID;

    private SmeltingStat currentStat = SmeltingStat.RawMaterial; //현재 재련 상태를 알려주는 변수, Product 상태일 때만 아이템에 재련 가능
    public SmeltingStat Stat => currentStat;

    public void RefiningMaterail(SmeltingStat targetStat) => currentStat = targetStat; //현재 재련 상태를 바꿔주는 함수
}
