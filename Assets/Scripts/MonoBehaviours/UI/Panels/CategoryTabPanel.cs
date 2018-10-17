using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CategoryTabPanel : MonoBehaviour
{
    public Text Title;
    public GameObject ChosedMark;
    public bool IsChosed;
    public Color32 CategoryColor;
    public Categories CategoryName;
    public Button ChoseCategoryButton;
    [SerializeField]
    private Color32 TRANSPARENT;
    [SerializeField]
    private Color32 NONTRANSPARENT;

    public void Chose(bool isChosed)
    {
        IsChosed = isChosed;
        Title.color = isChosed ? NONTRANSPARENT : TRANSPARENT;
        ChosedMark.SetActive(isChosed);
    }

}
