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

    public void Initialize(string title , string description)
    {
        Title.text = title;
    }

    public void AddAppBlock(AppBlockController newAppBlock)
    {   
        AppBlocks.Add(newAppBlock);
        StartCoroutine(UpdateAfterSec());

    }
    public IEnumerator UpdateAfterSec()
    {
        yield return new WaitForEndOfFrame();
        SnapScrolling.UpdateElementsInfo();
    }
}
