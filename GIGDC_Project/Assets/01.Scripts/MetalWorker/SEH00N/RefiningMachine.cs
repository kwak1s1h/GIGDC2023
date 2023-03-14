using System;
using System.Collections;
using UnityEngine;

public class RefiningMachine : MonoBehaviour
{
    //해당 재료 정제기가 정제할 대상을 나타내는 변수
    //targetMaterial이 SmeltingStat.Melted인 도구는 SmeltMaterial의 currentStat이 SmeltingStat.Melted 재료만 정제할 수 있음
    [SerializeField] SmeltingStat targetMaterial; 
    [SerializeField] float refiningDuration = 3f; //재료 정제 시간

    /// <summary>
    /// 정제 대상이 정제 가능한 상태인지 확인하는 메소드
    /// </summary>
    private bool CheckMaterial(SmeltingStat materialStat) 
        => targetMaterial != materialStat; //정제 가능 상태일 때 true 정제 불가능 상태일 때 false

    public void Refining(SmeltMaterial material)
    {
        if(CheckMaterial(material.Stat) == false) //정제 불가 상태일 때 아무 반응도 하지 않는 코드
        {
            Debug.Log("This material is not compatible with this refinery machine");
            return;
        }

        StartCoroutine(DelayCoroutine(refiningDuration, () => { //정제 가능 상태일 때 정제시간만든 딜레이
            material.RefiningMaterail(targetMaterial); //정제 시간이 다 지났을 때 정제한 재료의 상태를 기존 상태에서 다음 단계로 업데이트하는 코드
            //아이템 반환하는 코드
            //스듀 씨앗생성기나 화로처럼 띄웠으면 좋겠음
        }));
    }

    private IEnumerator DelayCoroutine(float delay, Action callback = null)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
