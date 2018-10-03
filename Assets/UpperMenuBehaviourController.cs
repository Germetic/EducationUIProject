using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpperMenuBehaviourController : MonoBehaviour {

    [SerializeField]
    private RectTransform _searchPanel;
    [SerializeField]
    private RectTransform _appPanel;

    private Vector2 _searchPanelStartPosition;
    private Vector2 _searchPanelStartSize;
    private Vector2 _appPanelStartPosition;
    private Vector2 _appPanelStartSize;

    private Vector2 _searchPanelPanelHidePosition;
    private Vector2 _appPanelFullscreenPosition;
    private Vector2 _appPanelFullscreenSize;

    private bool _canHide;

    private void Awake()
    {
        _searchPanelStartPosition = _searchPanel.localPosition;
        _searchPanelStartSize = _searchPanel.sizeDelta;

        _appPanelStartPosition = _appPanel.anchoredPosition;
        _appPanelStartSize = _appPanel.sizeDelta;

       // _searchPanelPanelHidePosition = new Vector2(_searchPanelStartPosition.x,_searchPanelStartPosition.y-_searchPanelStartSize.y);

    }
    private void ShowSearchPanel(bool isShow)
    {
        _searchPanel.anchoredPosition = isShow ? _searchPanelStartSize : Vector2.zero;

    }
    private void ShowAppPanel(bool isShow)
    {
        _appPanel.sizeDelta = new Vector2(_appPanel.sizeDelta.x,isShow ? 0 : _appPanelStartSize.y);
        //_appPanel.anchoredPosition = new Vector2(_appPanel.anchoredPosition.x, isShow ? 0 : _appPanelStartPosition.y);
       // _appPanel.DOSizeDelta()
        _appPanel.DOAnchorPos(new Vector2(_appPanel.anchoredPosition.x, isShow ? 0 : _appPanelStartPosition.y),1);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ShowSearchPanel(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ShowSearchPanel(false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            ShowAppPanel(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ShowAppPanel(false);
        }

    }

}
