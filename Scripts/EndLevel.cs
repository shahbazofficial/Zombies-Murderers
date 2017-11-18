using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

    public int NextLevel;
    public GameObject Joueur;
    private bool Arme2Active;
    private bool Arme3Active;
    private bool Arme2First;
    private bool Arme3First;
    private int HP;
    private int DansChargeur;
    private int AMMO;
    private int Bullets;
    private int Arme;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HP = Joueur.GetComponent<PointDeVie>().getHP();
            DansChargeur = Joueur.GetComponent<AMMO>().getChargeur();
            AMMO = Joueur.GetComponent<AMMO>().getAMMO();
            Bullets = Joueur.GetComponent<AMMO>().getBullet();
            Arme = Joueur.GetComponent<AMMO>().getArme();
            Arme2Active = Joueur.GetComponent<AMMO>().getArme2Active();
            Arme3Active = Joueur.GetComponent<AMMO>().getArme3Active();
            Arme2First = Joueur.GetComponent<AMMO>().getArme2First();
            Arme3First = Joueur.GetComponent<AMMO>().getArme3First();
            PlayerPrefs.SetInt("PtDeVie", HP);
            PlayerPrefs.SetInt("DansChargeur", DansChargeur);
            PlayerPrefs.SetInt("Munit", AMMO);
            PlayerPrefs.SetInt("Bullets", Bullets);
            PlayerPrefs.SetInt("Arme", Arme);
            if (Arme2Active)
            {
                PlayerPrefs.SetInt("Arme2IsActive", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Arme2IsActive", 0);

            }
            if (Arme3Active)
            {
                PlayerPrefs.SetInt("Arme3IsActive", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Arme3IsActive", 0);
            }
            if (Arme2First)
            {
                PlayerPrefs.SetInt("Arme2FirstTime", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Arme2FirstTime", 0);
            }
            if (Arme3First)
            {
                PlayerPrefs.SetInt("Arme3FirstTime", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Arme3FirstTime", 0);
            }
            SceneManager.LoadScene(NextLevel);
        }
    }
}
