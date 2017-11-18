using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPTV : MonoBehaviour
{
    public GameObject Shutgun;
    public GameObject Gun;
    public GameObject Couteau;
    private int Arme;
    // Use this for initialization
    void Start()
    {
        GetComponent<PointDeVie>().setHP(PlayerPrefs.GetInt("PtDeVie"));
        GetComponent<AMMO>().setChargeur(PlayerPrefs.GetInt("DansChargeur"));
        GetComponent<AMMO>().setAMMO(PlayerPrefs.GetInt("Munit"));
        GetComponent<AMMO>().setBullet(PlayerPrefs.GetInt("Bullets"));
        GetComponent<AMMO>().setActiveArme(PlayerPrefs.GetInt("Arme2IsActive") == 1, PlayerPrefs.GetInt("Arme3IsActive") == 1, PlayerPrefs.GetInt("Arme2FirstTime") == 1, PlayerPrefs.GetInt("Arme3FirstTime") == 1);
        GetComponent<AMMO>().setArme(PlayerPrefs.GetInt("Arme"));
    }
}