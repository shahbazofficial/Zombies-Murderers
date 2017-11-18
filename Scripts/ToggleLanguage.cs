using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleLanguage : MonoBehaviour {
    public Image choosefr;
    public Image choosegb;
    //liés à la langue
    public int currentLanguage;
    //liés à la progressbar
    public float progress = 0.0f;
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public bool StartBar = false;
    public float TempsDepart = 0f;
    public Scrollbar ProgressBarre;
    private bool PeutChanger;

    void Awake()
    {
        PeutChanger = true;
    }
	
    void Update () {
        currentLanguage = PlayerPrefs.GetInt("currentLanguage");
        if (currentLanguage == 0)
        {
            choosefr.enabled = true;
            choosegb.enabled = false;
        }
        if (currentLanguage == 1)
        {
            choosefr.enabled = false;
            choosegb.enabled = true;
        }
        //Liés à la progressbar
        if (StartBar == true)
        {
            progress = (Time.time - TempsDepart) * 0.5f;
        }
        if (progress > 1.00f && PeutChanger)
        {
            ChangeLanguage();
            PeutChanger = false;
        }
        ProgressBarre.size = progress;
    }
    //Liés à la prosgreesbar
    public void BarreStart()
    {
        TempsDepart = Time.time;
        StartBar = true;
    }
    public void BarreStop()
    {
        progress = 0f;
        StartBar = false;
        PeutChanger = true;
    }
    //Choix de la Langue
    public void ChangeLanguage()
    {
        currentLanguage = PlayerPrefs.GetInt("currentLanguage");
        currentLanguage += 1;
        if (currentLanguage == 2) currentLanguage = 0;
        PlayerPrefs.SetInt("currentLanguage", currentLanguage);
    }
}
