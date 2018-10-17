using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailAppPanel : MonoBehaviour
{
    public Image Icon;
    public Text Category;
    public Text SubCategory;
    public Text Title;
    public Text[] Rate;
    public Text[] Downloads;
    public Image[] RateFillItems;
    public Text Size;
    public Text Description;
    public Button ReturnBtn;
    public bool IsShowingNow;

    public Product CurrentProduct;

    private void OnEnable()
    {
        ReturnBtn.onClick.AddListener(()=>{ Hide();});
    }
    private void OnDisable()
    {
        ReturnBtn.onClick.RemoveAllListeners();
    }

    /// <summary>
    /// Assign information to display and show panel
    /// </summary>
    /// <param name="product">Product to show</param>
    public void Initialize(Product product)
    {
        CurrentProduct = product;
        Show();
        ImageDrawer.Instance.DrawImage(product.Icon, Icon);
        Category.text = product.Category.ToString();
        SubCategory.text = product.SubCategory;
        Title.text = product.Title;
        Description.text = product.Description;
        Size.text = product.Size.ToString();

        for (int i = 0; i < Rate.Length; i++)
        {
            Rate[i].text = product.Rating.ToString();
        }
        //Fill Download count fields
        for (int i = 0; i < Downloads.Length; i++)
        {
            Downloads[i].text = product.Downloads.ToString();
        }
        //Fill Rating fields
        float fillValue = product.Rating / 5;
        for (int i = 0; i < RateFillItems.Length; i++)
        {
            RateFillItems[i].fillAmount = fillValue;
        }
    }
    public void Hide()
    {
        gameObject.SetActive(false);
        IsShowingNow = false;
        CurrentProduct = null;
    }
    private void Show()
    {
        gameObject.SetActive(true);
        IsShowingNow = true;
    }
    
}
