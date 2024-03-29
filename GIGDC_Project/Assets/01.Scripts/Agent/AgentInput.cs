using System;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonPress { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonRelease { get; set; }

    // 곽석현이 쓰는거
    [field: SerializeField] public UnityEvent OnInteractionKeyPress { get; set; }
    [field: SerializeField] public UnityEvent<int> OnMouseWheelScroll { get; set; }
    [field: SerializeField] public UnityEvent OnInvenOpenKeyPress { get; set; }

    // 재희가 쓰는거
    private bool _fireButtonDown = false;

    public UnityEvent OnReloadButtonPress;

    [field: SerializeField] public UnityEvent OnDropButtonPress { get; set; }

    public UnityEvent<bool> OnNextWeaponPress;

    private void Update()
    {
        GetMovementInput();
        GetFireInput();

        // 곽석현이 쓰는거
        GetMouseWheelInput();
        GetOpenInvenInput();
        
        // 재희가 쓰는거
        GetDropInput();
        GetChangeInput();
    }

    private void GetChangeInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnNextWeaponPress?.Invoke(false);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            OnMouseWheelScroll?.Invoke(UIManager.Instance.HotbarIdx + (Input.mouseScrollDelta.y > 0 ? -1 : 1));
        }
    }

    private void GetOpenInvenInput()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            OnInvenOpenKeyPress?.Invoke();
        }
    }

    private void GetMouseWheelInput()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            OnMouseWheelScroll?.Invoke(UIManager.Instance.HotbarIdx + (Input.mouseScrollDelta.y > 0 ? -1 : 1));
        }
    }

    private void GetDropInput()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            OnDropButtonPress?.Invoke();
        }
    }

    private void GetFireInput()
    {
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            if (!_fireButtonDown)
            {
                _fireButtonDown = true;
                OnFireButtonPress?.Invoke();
            }
        }
        else
        {
            if (_fireButtonDown)
            {
                _fireButtonDown = false;
                OnFireButtonRelease?.Invoke();
            }
        }
    }

    private void GetMovementInput()
    {
        OnMovementKeyPress?.Invoke(
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
        );
    }
}