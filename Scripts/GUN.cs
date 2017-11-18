using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour {
    public GameObject CardbMain;
    public bool AmmoPlus;
    public bool BulletPlus;
    public GameObject GunSurTerrain;
    public GameObject Tutoriel;
    private bool ArmeActive = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (AmmoPlus)
        {
            int AmmoRest = CardbMain.GetComponent<AMMO>().getAMMO();
            int InChargeur = CardbMain.GetComponent<AMMO>().getChargeur();
            if (!ArmeActive)
            {
                CardbMain.GetComponent<AMMO>().setFirstgun(true);
                InChargeur = 15;
                ArmeActive = true;
            }
            AmmoRest += 100;
            Tutoriel.GetComponent<Tutorial>().SetTuto(3);
            CardbMain.GetComponent<AMMO>().setAMMO(AmmoRest);
            CardbMain.GetComponent<AMMO>().setChargeur(InChargeur);
            GunSurTerrain.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ForLife" || other.gameObject.name == "GunCible" || other.gameObject.name == "ArmKnyfe" || other.gameObject.name == "ShutGun")
        {
            AmmoPlus = true;
        }
    }
}
