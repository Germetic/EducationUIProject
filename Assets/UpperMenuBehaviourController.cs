using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UpperMenuBehaviourController : MonoBehaviour {

    public bool IsDraggingNow;
    [Header("Percent of visibiblity when SearchPanel will hide")]
    [Range(1,90)]
    public float PercentToHideSearchPanel;
    [Header("Show , hide panel animation speed")]
    [SerializeField]
    private float _animationSpeed;
    [SerializeField]
    private RectTransform _searchPanel;
    [SerializeField]
    private RectTransform _appPanel;
    [SerializeField]
    private RectTransform _appPanelContent;

    private ScrollRect _appPanelScrollRect;
    private bool _canHideSearchPanel = false;
    private bool _isSearchPanelHidenNow;
    private float _searchPanelSize;

    /// <summary>
    /// Move SearchPanel Y position
    /// </summary>
    /// <param name="newYPos">Acceleration by Y</param>
    public void MoveSearchPanelByY(float newYPos)
    {
        if (_searchPanel.anchoredPosition.y <= _searchPanelSize && _searchPanel.anchoredPosition.y >= 0 && _canHideSearchPanel)
        {
            _searchPanel.anchoredPosition = new Vector2(_searchPanel.anchoredPosition.x, _searchPanel.anchoredPosition.y - newYPos);
        }
    }

    /// <summary>
    /// Check SearchPanel by show percent variable , then show or hide 
    /// </summary>
    public void SnapToBorder()
    {
        if (_canHideSearchPanel)
        {
            if (_searchPanel.anchoredPosition.y < _searchPanelSize / (100/PercentToHideSearchPanel))
                ShowSearchPanel(true);
            else
                ShowSearchPanel(false);
        }
    }

    private void Awake()
    {
        _searchPanelSize = _searchPanel.sizeDelta.y;
        _appPanelScrollRect = _appPanel.GetComponent<ScrollRect>();
    }
    private void ShowSearchPanel(bool isShow)
    {
        _searchPanel.DOAnchorPos(isShow ? Vector2.zero : new Vector2(0, _searchPanelSize), _animationSpeed);
        _isSearchPanelHidenNow = !isShow;
    }

    private void Update()
    {
        CheckHideSearchPanelPossibility();
        LimitSearchPanelPosition();
    }

    private void CheckHideSearchPanelPossibility()
    {
        if (_appPanelContent.anchoredPosition.y >= _searchPanelSize)
        {
            _canHideSearchPanel = true;
        }
        if (_appPanelContent.anchoredPosition.y <= _searchPanelSize)
        {
            _canHideSearchPanel = false;
        }
    }
    private void LimitSearchPanelPosition()
    {   
        if (!IsDraggingNow)
        {
            if(!_canHideSearchPanel && _isSearchPanelHidenNow)
            {
                ShowSearchPanel(true);
            }
        }
        else
        {
            if (_searchPanel.anchoredPosition.y > _searchPanelSize)
            {
                _searchPanel.anchoredPosition = new Vector2(0, _searchPanelSize);
            }
            else if (_searchPanel.anchoredPosition.y < 0)
            {
                _searchPanel.anchoredPosition = Vector2.zero;
            }
        }       
    }

}
