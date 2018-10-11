using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProductsController : MonoBehaviour {

    /// <summary>
    /// Read Products from Json file
    /// </summary>
    /// <param name="jsonFileName">Name of json file on resources folder</param>
    /// <returns>Returns Products from Json file by name</returns>
    public Products GetProductsFromJson(string jsonFileName)
    {
        TextAsset loadedFile = Resources.Load<TextAsset>(jsonFileName);
        Products products = JsonUtility.FromJson<Products>(loadedFile.text);
        return products;
    }
}
