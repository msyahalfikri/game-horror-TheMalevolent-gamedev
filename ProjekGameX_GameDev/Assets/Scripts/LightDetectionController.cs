using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetectionController : MonoBehaviour
{
    public RenderTexture sourceTexture;
    float LightLevel;
    public static int Light;

    // Update is called once per frame
    void Update()
    {
        RenderTexture tmp = RenderTexture.GetTemporary(
                    sourceTexture.width,
                    sourceTexture.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Linear);

        Graphics.Blit(sourceTexture, tmp);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = tmp;

        Texture2D myTexture2D = new Texture2D(sourceTexture.width, sourceTexture.height);

        myTexture2D.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
        myTexture2D.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(tmp);

        Color32[] colors = myTexture2D.GetPixels32();
        LightLevel = 0;
        for(int i = 0; i < colors.Length; i++)
        {
            LightLevel += (0.2126f * colors[i].r) + (0.7152f * colors[i].g) + (0.0722f * colors[i].b);
        }
        LightLevel -= 259330;
        LightLevel = LightLevel / colors.Length;
        Light = Mathf.RoundToInt(LightLevel);
    }
}
