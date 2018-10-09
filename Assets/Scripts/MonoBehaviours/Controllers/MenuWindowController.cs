using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindowController : MonoBehaviour
{
    public Animator Animator;
    public bool IsShowingNow;

    [SerializeField]
    private string _showAnimationName;
    [SerializeField]
    private string _hideAnimationName;

    public void Show()
    {
        gameObject.SetActive(true);
        IsShowingNow = true;
        Animator.SetTrigger(_showAnimationName);
    }

    public void Hide()
    {
        IsShowingNow = false;
        Animator.SetTrigger(_hideAnimationName);
    }

    public void Close()
    {
        IsShowingNow = false;
        gameObject.SetActive(false);
    }

}
