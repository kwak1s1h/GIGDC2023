using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anvil : MonoBehaviour
{
    [SerializeField] float smithingDuration = 10f;
    [SerializeField] List<ProductSO> blueprints = new List<ProductSO>();

    /// <summary>
    /// 기존 아이템에 재련 재료를 재련한 아이템을 반환하는 메소드
    /// </summary>
    /// <param name="target">기존 아이템 ID</param>
    /// <param name="material">재련 재료</param>
    public void Smithing(int inputID, SmeltMaterial material)
    {
        if (material.Stat != SmeltFlags.Product) //재련 재료가 product 상태가 아니면 돌아가지 재련불가
        {
            Debug.Log("Material is not right state to smithing");
            return; //재련으로 넘어가지 않음
        }

        // if(target.ProductionID.Contains(material.MaterialID)) //이미 재련에 사용된 재료일 때
        // {
        //     Debug.Log("This material has already been used for refining");
        //     return; //재련으로 넘어가지 않음
        // }

        int targetID = inputID * 10 + (int)material.MaterialID;
        StartCoroutine(DelayCoroutine(smithingDuration, () => { //재련이 가능할 때 smithingDuration의 딜레이를 줌
            ProductSO production = GetProduction(targetID); //재련 재료에 따라서 새로운 아이템을 받는 메소드
            
            if(production == null) { //재련 설계도가 리스트에 없을 때
                Debug.Log("Ther is no blueprints for current production id in list");
                return;
            }

            //재련 완료됐을 때
            //production(새로운 아이템) 반환 시켜야 댐
            //스듀 씨앗생성기나 화로처럼 띄웠으면 좋겠음
        }));
    }

    private ProductSO GetProduction(int targetID)
    {
        ProductSO returnValue = null;

        //int tempID = target.ProductionID; //값만 복사하기 위한 코드 ( 더 좋은 방법을 못찾겠음 ) // 찾았지롱
        foreach (ProductSO blueprint in blueprints) //정제된 재료에 따른 아이템을 찾는 코드
        {
            if(targetID == blueprint.ProductionID)
            {
                returnValue = blueprint;
                break;
            }
        }

        return returnValue;
    }

    private IEnumerator DelayCoroutine(float delay, Action callback = null)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
