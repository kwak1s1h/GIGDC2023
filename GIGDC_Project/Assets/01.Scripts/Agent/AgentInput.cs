using System;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour, IAgentInput
{
    [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPress { get; set; }
    [field: SerializeField] public UnityEvent OnFireButtonPress { get; set; }
    [field: SerializeField] public UnityEvent OnInteractionKeyPress { get; set; }
    [field: SerializeField] public UnityEvent<int> OnMouseWheelScroll { get; set; }

    private void Update()
    {
        GetMovementInput();
        GetFireInput();
        GetInteractionInput();
        GetMouseWheelInput();
    }

    private void GetMouseWheelInput()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            OnMouseWheelScroll?.Invoke(UIManager.Instance.HotbarIdx + (Input.mouseScrollDelta.y > 0 ? -1 : 1));
        }
    }

    private void GetInteractionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteractionKeyPress?.Invoke();
        }
    }

    private void GetFireInput()
    {
        if(Input.GetAxisRaw("Fire1") > 0)
        {
            OnFireButtonPress?.Invoke();
        }
    }

    private void GetMovementInput()
    {
        OnMovementKeyPress?.Invoke(
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
        );
    }
}