using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Exit : MonoBehaviour {

	private float dT = 0.5f;
	private float temps = 0.0f;
	private float tempsmax = 200.0f;
	public bool MiseEnRoute = false;

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
            Quitter();
        }
        ProgressBarre.size = progress;

		if (MiseEnRoute == true) 
		{
			while (tempsmax > temps && MiseEnRoute == true) 
			{
				temps = temps + dT;
			}
			if (MiseEnRoute == true) 
			{
				Application.Quit();
			}
			temps = 0.0f;
			MiseEnRoute = false;
		}
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
    }

    public void SurVole(bool Testage)
	{
		MiseEnRoute = Testage;
		if (Testage == false) 
		{
			temps = 0.0f;
			
		}
	}

	public void Quitter()
    {
        TargetSprite.color = Color.red;
        Application.Quit();
	}
}
