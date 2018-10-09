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
    public Product.Categories CategoryName;
    public Button ChoseCategoryButton;

    public void Chose(bool isChosed)
    {
        IsChosed = isChosed;
        Title.color = new Color32(255,255,255,isChosed? (byte)255 : (byte)140);
        ChosedMark.SetActive(isChosed);
    }

}
