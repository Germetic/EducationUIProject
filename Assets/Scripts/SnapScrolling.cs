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
    private int _startLastIgnoredElementsCount;
    public ScrollRect scrollRect;

    private GameObject[] instPans;
    private Vector2[] pansPos;

    private RectTransform contentRect;
    private Vector2 contentVector;

    private int selectedPanID;
    private bool isScrolling;

    private void Awake()
    {
        contentRect = GetComponent<RectTransform>();
        _startLastIgnoredElementsCount = LastIgnoredElementsCount;
    }

    private void Start()
    {
        UpdateElementsInfo();
    }

    private void Update()
    {
        if (PanCount < 2)
            return;
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
            scrollRect.inertia = false;
        float nearestPos = float.MaxValue;
        for (int i = 0; i < PanCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                if (i > ((PanCount - 1) - LastIgnoredElementsCount))
                    selectedPanID = (PanCount - 1) - LastIgnoredElementsCount;
                else
                    selectedPanID = i;
            }
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < InertiaDisablingScrollVelocity && !isScrolling) scrollRect.inertia = false;
        if (isScrolling || scrollVelocity > InertiaDisablingScrollVelocity) return;
        contentVector.x = Mathf.SmoothStep(
            contentRect.anchoredPosition.x, 
            pansPos[selectedPanID].x + 
            SnapPointOffset, SnapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
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

        pansPos = new Vector2[PanCount];
        for (int i = 0; i < PanCount; i++)
        {
            pansPos[i] = InverseScrollRect ?
                -transform.GetChild(i).gameObject.transform.localPosition
                : transform.GetChild(i).gameObject.transform.localPosition;
        }
    }
}