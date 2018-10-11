using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageDrawer : MonoBehaviour
{
    public static ImageDrawer Instance;

    private void Awake()
    {   
        //Singletone
        if (Instance == null)
            Instance = this;
    }

    /// <summary>
    /// Load image from URL and insert into Image.sprite
    /// </summary>
    /// <param name="url">URL to image</param>
    /// <param name="imageToInsert">Image where file will inserted</param>
    public void DrawImage(string url, Image imageToInsert)
    {
        StartCoroutine(DrawTexture(url, imageToInsert));
    }

    private IEnumerator DrawTexture(string url, Image imageToInsert)
    {
        Texture2D texture;
        using (WWW www = new WWW(url))
        {
            yield return www;
            texture = www.texture;
        }
        Sprite loadedSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
        if(imageToInsert != null)
        imageToInsert.sprite = loadedSprite;
        
    }
}
