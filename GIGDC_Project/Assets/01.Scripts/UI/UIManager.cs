using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private UIDocument _document;
    private VisualElement _root;

    // Hotbar
    private int _hotbarIdx = 0;
    public int HotbarIdx => _hotbarIdx; 
    private int _hotbarLength;
    private VisualElement _hotbar;
    private VisualElement[] _hotbarElements;

    // Inventory Popup
    private int _rows;
    private int _columns;
    private VisualElement _invenPopup;
    private VisualElement[] _invenElements;
    private VisualElement _closeBtn;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple UIManager Instance is running.");
        }
        Instance = this;

        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;

        // Hotbar
        _hotbar = _root.Q<VisualElement>("QuickBar");
        _hotbarElements = _hotbar.Children().ToArray();
        _hotbarLength = _hotbarElements.Length;
        
        // Inventory Popup
        _invenPopup = _root.Q<VisualElement>("invenPopup");
        _closeBtn = _invenPopup.Q<VisualElement>("closeBtn");
        _closeBtn.RegisterCallback<ClickEvent>((e) => {
            _invenPopup.AddToClassList("close");
        });
    }

    public void HotbarScroll(int idx)
    {
        _hotbarElements[_hotbarIdx].RemoveFromClassList("select");
        _hotbarIdx = Mathf.Clamp(idx, 0, _hotbarLength - 1);
        _hotbarElements[_hotbarIdx].AddToClassList("select");
    }

    public void SwichInven()
    {
        if(_invenPopup.ClassListContains("close"))
        {
            _invenPopup.RemoveFromClassList("close");
        }
        else
        {
            _invenPopup.AddToClassList("close");
        }
    }
}
