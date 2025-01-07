using UnityEngine;

public class ImpactDrawer : MonoBehaviour
{
    public RenderTexture renderTexture; 
    public Texture2D decalTexture;      
    public Material material;           

    void Start()
    {
        material.mainTexture = renderTexture;
        ClearRenderTexture();
    }

    void ClearRenderTexture()
    {
        RenderTexture.active = renderTexture;
        GL.Clear(true, true, Color.clear);
        RenderTexture.active = null;
    }

    public void DrawImpact(Vector3 worldPosition)
    {
        var uv = WorldToUV(worldPosition);
        if (uv == Vector2.zero) return;

        RenderTexture.active = renderTexture;

        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        // Малюємо текстуру сліду
        var rect = new Rect(uv.x * renderTexture.width - 50, uv.y * renderTexture.height - 50, 100, 100);
        Graphics.DrawTexture(rect, decalTexture);

        GL.PopMatrix();
        RenderTexture.active = null;
    }

    Vector2 WorldToUV(Vector3 worldPos)
    {
        var ray = new Ray(Camera.main.transform.position, worldPos - Camera.main.transform.position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.textureCoord; 
        }
        return Vector2.zero;
    }
}