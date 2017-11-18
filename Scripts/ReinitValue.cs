using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinitValue : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("PtDeVie", 100);
        PlayerPrefs.SetInt("DansChargeur", 0);
        PlayerPrefs.SetInt("Munit", 0);
        PlayerPrefs.SetInt("Bullets", 0);
        PlayerPrefs.SetInt("Arme", 0);
        PlayerPrefs.SetInt("Arme2IsActive", 0);
        PlayerPrefs.SetInt("Arme3IsActive", 0);
        PlayerPrefs.SetInt("Arme2FirstTime", 1);
        PlayerPrefs.SetInt("Arme3FirstTime", 1);
    }
}
