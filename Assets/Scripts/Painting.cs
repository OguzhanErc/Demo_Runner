using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public MeshRenderer meshRenderer;//Object which will be painting
    public Texture2D brush;//Brush texture
    public Vector2Int textureArea;
    Texture2D texture;
    public Camera cam;
    void Start()
    {
        texture = new Texture2D(textureArea.x, textureArea.y, TextureFormat.ARGB32, false);
        meshRenderer.material.mainTexture = texture;
    }

    private void Update()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {

        }
    }

    private void Paint(Vector2 coordinate)
    {
        coordinate.x *= texture.width;
        coordinate.y *= texture.height;

        Vector2Int halfBrush = new Vector2Int(brush.width / 2, brush.height / 2);
        for (int x = 0; x < brush.width; x++)
        {
            for (int y = 0; y < brush.height; y++)
            {
                if (brush.GetPixel(x, y).a > 0f)
                {
                    texture.SetPixel((int)coordinate.x + (halfBrush.x - x),
                        (int)coordinate.y + (halfBrush.y - y),
                        brush.GetPixel(x, y));
                }
            }
        }
        texture.Apply();
    }
}
