using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Contact : MonoBehaviour
{
	public bool choixcontact=true;
    public float progress = 0.0f;
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public bool StartBar = false;
    public float TempsDepart = 0f;
    public Scrollbar ProgressBarre;
    public GameObject loadingImage;
    public SpriteRenderer TargetSprite;
    public bool peutChanger = true;
    void awake()
    {
        peutChanger = true;
        choixcontact = true;
    }

    void Update()
    {
        if (StartBar == true)
        {
            progress = (Time.time - TempsDepart) * 0.5f;
        }
        if (progress > 1.00f && peutChanger)
        {
            TargetSprite.color = Color.red;
            loadingImage.SetActive(choixcontact);
            choixcontact = !choixcontact;
            peutChanger = false;
        }
        ProgressBarre.size = progress;
    }

    public void BarreStart()
    {
        TempsDepart = Time.time;
        StartBar = true;
    }

    public void BarreStop()
    {
        progress = 0f;
        StartBar = false;
        TargetSprite.color = Color.white;
        peutChanger = true;
    }
}

