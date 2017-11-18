using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieLife : MonoBehaviour {

    public int PointOfLife;
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.
    public Vector2 pos;
    public Vector2 size;
    public GameObject ZombieCible;
    public Scrollbar ProgressBarre;

    public void Barre()
    {
        OnGUI();
    }

    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), emptyProgressBar);
        //GUI.DrawTexture(new Rect(pos.x, pos.y, 0.01f * PointOfLife, size.y), fullProgressBar);
    }
    void Update()
    {
        PointOfLife = ZombieCible.GetComponent<PointDeVie>().getHP();
        ProgressBarre.size = 0.01f * PointOfLife;
    }
}