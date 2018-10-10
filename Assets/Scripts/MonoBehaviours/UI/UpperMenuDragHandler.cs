using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpperMenuDragHandler : MonoBehaviour, IBeginDragHandler ,IDragHandler,IEndDragHandler
{
    public UpperMenuBehaviourController UpperMenuBehaviourController;

    private Vector2 _startTouchPosition;
    private float _lastTouchYPosition;

    public void OnBeginDrag(PointerEventData data)
    {
        _startTouchPosition = Input.mousePosition;
        _lastTouchYPosition = _startTouchPosition.y;
        UpperMenuBehaviourController.IsDraggingNow = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float currentTouchYPositionDifference = _startTouchPosition.y - Input.mousePosition.y;
        float acceleration = currentTouchYPositionDifference - _lastTouchYPosition;
        _lastTouchYPosition = currentTouchYPositionDifference;        
        UpperMenuBehaviourController.MoveSearchPanelByY(acceleration);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UpperMenuBehaviourController.IsDraggingNow = false;
        UpperMenuBehaviourController.SnapToBorder();
    }
}
