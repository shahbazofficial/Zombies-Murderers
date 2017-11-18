using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public float progress = 0.0f;
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    
    public void Barre()
    {
        OnGUI();
    }
       
    void OnGUI()
    {
            
            GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), emptyProgressBar);
            GUI.DrawTexture(new Rect(pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y), fullProgressBar);
    }
    void Update()
    {
        progress = Time.time * 1.00f;

    }
}
