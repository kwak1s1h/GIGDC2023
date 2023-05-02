using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{

    // �̿ϼ� ��ũ��Ʈ


    private static TimeManager instance;
    public TimeManager Instance => instance;
    public UnityEvent EndOfDay;

    // ��Ÿ��븮 Ÿ�̸�ó�� �۵��� ����
    [Header("1ƽ�� �带 �� ������ �ð�(��)")]
    [SerializeField]
    [Range(0f, 100f)]
    private float tick = 5;
    private int currentDay = 1;
    // time
    // �ڷ���
    // time.deltatime

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple TimeManager is running");
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        // ���� ��¥�� ����� ��¥�� �ҷ�����
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