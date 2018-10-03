using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AddNewProductController : MonoBehaviour {

    public string JsonFileName;
    [Space]
    public Text HeaderText;
    public Texture2D Icon;
    [Space]
    public InputField NameFld;
    public InputField DescriptionFld;
    public InputField RatingFld;
    public InputField SizeFld;
    public InputField DownloadsFld;
    [Space]
    public Toggle IsRecommendTgl;
    public Dropdown CategoryDPD;
    public Dropdown BlockTypeDPD;
    public Button AddProductBtn;
    public Button CreateJsonBtn;
    public Button ReadBtn;

    public Products CreatedProducts;

    private string _path;

    private void Awake()
    {
        AddProductBtn.onClick.AddListener(AddNewProduct);
        CreateJsonBtn.onClick.AddListener(CreateJson);
        ReadBtn.onClick.AddListener(ReadJson);
        _path = Application.streamingAssetsPath;
    }
    public void CreateJson()
    {
        string path = Application.persistentDataPath + "//" + NameFld.text + ".json";
        string jsonData = JsonUtility.ToJson(CreatedProducts);
        File.WriteAllText(path, jsonData);
    }
    public void AddNewProduct()
    {
        if (Icon == null)
        {
            HeaderText.text = "SET IMAGE IN EDITOR";
            return;
        }
        HeaderText.text = "Success";
        byte[] icon = Icon.EncodeToPNG();
        Product product = new Product(
            icon,
            NameFld.text,
            DescriptionFld.text,
            IsRecommendTgl.isOn,
            float.Parse(RatingFld.text),
            Int32.Parse(SizeFld.text),
            Int32.Parse(DownloadsFld.text),
            (Product.Categories)CategoryDPD.value,
            (Product.BlockTypes)BlockTypeDPD.value
            );
        CreatedProducts.AllProducts.Add(product);
        NameFld.text = "";
        DescriptionFld.text = "";
        RatingFld.text = "";
        SizeFld.text = "";
        DownloadsFld.text = "";
    }

    public void ReadJson()
    {
        string path = _path + "//" + JsonFileName + ".json";
        string jsonString = File.ReadAllText(path);
        Debug.Log(jsonString);
        Products products = JsonUtility.FromJson<Products>(jsonString);
        Debug.Log(products.ToString());
    }
}
