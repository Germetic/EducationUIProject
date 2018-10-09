using System;
using UnityEngine;
using UnityEngine.UI;

public class SnapScrolling : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int PanCount;
    [Range(0f, 20f)]
    public float SnapSpeed;
    [Range(0f, 200f)]
    public float SnapPointOffset;
    [Range(100f, 1000f)]
    public float InertiaDisablingScrollVelocity;
    public bool InverseScrollRect;
    [Header("Ignoring snap to elements from the end count")]
    public int LastIgnoredElementsCount;
    public ScrollRect scrollRect;

    private int _startLastIgnoredElementsCount;

    private GameObject[] _instPans;
    private Vector2[] _pansPos;

    private RectTransform _contentRect;
    private Vector2 _contentVector;

    private int _selectedPanID;
    private bool _isScrolling;

    private void Awake()
    {
        _contentRect = GetComponent<RectTransform>();
        _startLastIgnoredElementsCount = LastIgnoredElementsCount;
    }

    private void Start()
    {
        UpdateElementsInfo();
    }

    private void Update()
    {
        Snap();      
    }

    private void Snap()
    {
        if (PanCount < 2)
            return;
        if (_contentRect.anchoredPosition.x >= _pansPos[0].x && !_isScrolling || _contentRect.anchoredPosition.x <= _pansPos[_pansPos.Length - 1].x && !_isScrolling)
            scrollRect.inertia = false;
        float nearestPos = float.MaxValue;
        for (int i = 0; i < PanCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                if (i > ((PanCount - 1) - LastIgnoredElementsCount))
                    _selectedPanID = (PanCount - 1) - LastIgnoredElementsCount;
                else
                    _selectedPanID = i;
            }
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < InertiaDisablingScrollVelocity && !_isScrolling) scrollRect.inertia = false;
        if (_isScrolling || scrollVelocity > InertiaDisablingScrollVelocity) return;
        _contentVector.x = Mathf.SmoothStep(
            _contentRect.anchoredPosition.x,
            _pansPos[_selectedPanID].x +
            SnapPointOffset, SnapSpeed * Time.fixedDeltaTime);
        _contentRect.anchoredPosition = _contentVector;
    }

    public void Scrolling(bool scroll)
    {
        _isScrolling = scroll;
        if(scroll)
            scrollRect.inertia = true;
    }
    /// <summary>
    /// Call this method when will added new elements on content
    /// </summary>
    public void UpdateElementsInfo()
    {
        PanCount = transform.childCount;
        if (LastIgnoredElementsCount >= PanCount)
            LastIgnoredElementsCount = 0;
        else
            LastIgnoredElementsCount = _startLastIgnoredElementsCount;

        _pansPos = new Vector2[PanCount];
        for (int i = 0; i < PanCount; i++)
        {
            _pansPos[i] = InverseScrollRect ?
                -transform.GetChild(i).gameObject.transform.localPosition
                : transform.GetChild(i).gameObject.transform.localPosition;
        }
    }
}