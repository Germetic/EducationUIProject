using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryBlockController : MonoBehaviour
{
    public Text Title;
    public List<AppBlockController> AppBlocks;
    public SnapScrolling SnapScrolling;
    public Transform Content;

    /// <summary>
    /// Set block title
    /// </summary>
    /// <param name="title">Title on block header</param>
    public void Initialize(string title)
    {
        Title.text = title;
    }

    public void AddAppBlock(AppBlockController newAppBlock)
    {
        AppBlocks.Add(newAppBlock);
        StartCoroutine(UpdateScrollElementsOnNextFrame());
    }

    private IEnumerator UpdateScrollElementsOnNextFrame()
    {
        yield return new WaitForEndOfFrame();
        SnapScrolling.UpdateElementsInfo();
    }
}
