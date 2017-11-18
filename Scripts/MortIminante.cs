using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MortIminante : MonoBehaviour {

    public Image MonImage;
    public GameObject Joueur;
    private float PTV;
    private float PerCentOfLife;
    private bool Mort;
	void Start ()
    {
        MonImage = GetComponent<Image>();
        var tempColor = MonImage.color;
        tempColor.a = 1f;
        MonImage.color = tempColor;

    }
	
	void Update ()
    {
        PTV = 100f - (float) Joueur.GetComponent<PointDeVie>().getHP();
        PerCentOfLife = PTV / 100;
        if (Joueur.GetComponent<PointDeVie>().getHP() <= 0) PerCentOfLife = 0f;
        var tempColor = MonImage.color;
        tempColor.a = PerCentOfLife;
        MonImage.color = tempColor;
    }
}
