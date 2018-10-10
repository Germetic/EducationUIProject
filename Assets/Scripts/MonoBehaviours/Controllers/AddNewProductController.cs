using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AddNewProductController : MonoBehaviour {

    public Text HeaderText;
    public InputField IconUrl;
    [Space]
    public InputField NameFld;
    public InputField DescriptionFld;
    public InputField RatingFld;
    public InputField SizeFld;
    public InputField DownloadsFld;
    [Space]
    public Toggle IsRecommendTgl;
    public Dropdown CategoryDPD;
    public InputField BlockTypeFld;
    public Button AddProductBtn;
    public Button CreateJsonBtn;
    public Button ReadBtn;

    public Products CreatedProducts;

    private void Awake()
    {          
        AddProductBtn.onClick.AddListener(AddNewProduct);
        CreateJsonBtn.onClick.AddListener(CreateJson);
    }

    public void CreateJson()
    {   
        //Path to save file
        string path = Application.persistentDataPath + "//" + NameFld.text + ".json";
        string jsonData = JsonUtility.ToJson(CreatedProducts);
        File.WriteAllText(path, jsonData);
        Debug.Log("<color=orange><b> Json file created, </b></color>" + path);
    }

    public void AddNewProduct()
    {
        if (IconUrl.text == "")
        {
            HeaderText.text = "SET IMAGE IN EDITOR";
            return;
        }

        HeaderText.text = "Success";       
        
        Product product = new Product(
            IconUrl.text,
            NameFld.text,
            DescriptionFld.text,
            IsRecommendTgl.isOn,
            float.Parse(RatingFld.text),
            Int32.Parse(SizeFld.text),
            Int32.Parse(DownloadsFld.text),
            (Product.Categories)CategoryDPD.value,
            BlockTypeFld.text
            );
        CreatedProducts.AllProducts.Add(product);
        NameFld.text = "";
        DescriptionFld.text = "";

        Debug.Log("<color=Green><b> Added , Products.Count : </b></color>" + CreatedProducts.AllProducts.Count);
    }
    
    public Products ReadJson(string jsonFileName)
    {
        TextAsset loadedFile = Resources.Load<TextAsset>(jsonFileName);
        Products products = JsonUtility.FromJson<Products>(loadedFile.text);
        return products;
    }
}
