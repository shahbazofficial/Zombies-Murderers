using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LoadOnSurvol : MonoBehaviour {

	public static float temps = 0.0f;
	public static int choixscene;

    public float progress = 0.0f;
    public Texture2D emptyProgressBar; // Set this in inspector.
    public Texture2D fullProgressBar; // Set this in inspector.
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public bool StartBar = false;
    public float TempsDepart = 0f;
    public int niveau;
    public Scrollbar ProgressBarre;
    public SpriteRenderer TargetSprite;

    void Update() 
	{
        if (StartBar == true)
        {
            progress = (Time.time - TempsDepart) * 0.5f;
        }
        if (progress > 1.00f)
        {
            SurVole(niveau);
        }
        ProgressBarre.size = progress;
    }

    public void BarreStart(int niv)
    {
        TempsDepart = Time.time;
        StartBar = true;
        niveau = niv;
    }
    public void BarreStop()
    {
        progress = 0f;
        StartBar = false;
    }

	public void SurVole(int lvl)
	{
        choixscene = lvl;
        PlayerPrefs.SetInt("PtDeVie", 100);
        PlayerPrefs.SetInt("Munit", 0);
        TargetSprite.color = Color.red;
        SceneManager.LoadScene(lvl);     
    }
}

