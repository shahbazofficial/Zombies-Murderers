using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOTGUN : MonoBehaviour {
    public GameObject CardbMain;
    public bool AmmoPlus;
    public bool BulletPlus;
    public GameObject GunSurTerrain;
    public GameObject Tutoriel;
    private bool ArmeActive  = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (BulletPlus)
        {
            int bullet = CardbMain.GetComponent<AMMO>().getBullet();
            if (!ArmeActive)
            {
                CardbMain.GetComponent<AMMO>().setFirstshotgun(true);
                ArmeActive = true;
            }
            bullet += 15;
            Tutoriel.GetComponent<Tutorial>().SetTuto(3);
            CardbMain.GetComponent<AMMO>().setBullet(bullet);
            GunSurTerrain.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ForLife" || other.gameObject.name == "GunCible" || other.gameObject.name == "ArmKnyfe" || other.gameObject.name == "ShutGun")
        {
            BulletPlus = true;
        }
    }
}
