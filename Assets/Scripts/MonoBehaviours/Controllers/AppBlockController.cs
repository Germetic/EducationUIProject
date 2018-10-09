using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppBlockController : MonoBehaviour
{
    public Image Icon;
    public Text Title;
    public GameObject IsRecommendArrow;
    public Button ShowDetails;
    public Product Product;

    public void Initialize(Product product)
    {
        Icon.sprite = ImageConverter.GetSpriteFromByte(product.Icon);
        Product = product;
        Title.text = product.Title;
        IsRecommendArrow.SetActive(product.IsRecommend);
        gameObject.name = "APP_" + product.Title;
    }
    private void Awake()
    {
        ShowDetails.onClick.AddListener(() => { ScreenController.Instance.DetailAppPanel.Initialize(Product); });        
    }
}
