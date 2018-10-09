using System;
using UnityEngine;

public class ImageConverter
{
    public static Sprite GetSpriteFromByte(byte[] avatar)
    {
        try
        {
            if (avatar.Length == 0)
                return null;

            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(avatar);
            return Sprite.Create(texture,
            new Rect(0, 0, texture.width, texture.height),
            new Vector2(0f, 1f), 128);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }

    public static byte[] ConvertToByte(Sprite avatar)
    {
        try
        {
            if (avatar == null)
                return null;

            return avatar.texture.EncodeToPNG();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return null;
        }
    }
}
