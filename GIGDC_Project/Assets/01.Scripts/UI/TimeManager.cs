using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{

    // 미완성 스크립트


    private static TimeManager instance;
    public TimeManager Instance => instance;
    public UnityEvent EndOfDay;

    // 스타듀밸리 타이머처럼 작동할 예정
    [Header("1틱이 흐를 때 까지의 시간(초)")]
    [SerializeField]
    [Range(0f, 100f)]
    private float tick = 5;
    private int currentDay = 1;
    // time
    // 코루팅
    // time.deltatime

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple TimeManager is running");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        // 현재 날짜를 저장된 날짜로 불러오기
        //StartCoroutine(Cycle());
    }

    private IEnumerator Cycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(tick);
            
        }
    }
}