using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AMMO : MonoBehaviour {

    public int bullet;
    public int Munit;
    public int DansChargeur;
    public int Weapon;
    public int ChoixArme;
    public int booltoint;
    private int EntreDeux;

    public GameObject Gun;
    public GameObject Couteau;
    public GameObject Tutoriel;
    public GameObject Chargeur;
    public GameObject Rechargement;
    public GameObject UpLoad;
    public GameObject Shotgun;
    public GameObject FeuGun;
    public GameObject FeuShotgun;
    public GameObject SangLame;

    public float vol1 = 1.0f;
    public float vol2 = 1.0f;
    public float nextLoadTime = 0.0f;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private float nextActionTime = 0.0f;
    private float period = 0.25f;
    public float nextLoadGun = 0.0f;
    public float nextLoadShotgun = 0.0f;
    public float nextLoadCouteau = 0.0f;
    public float nextReloader = 0.0f;

    public bool ReLoad;
    public bool GunReloaded;
    public bool ShotgunReloaded;
    public bool TireEffectifGun;
    public bool TireEffectifShotGun;
    public bool CoupDeCouteauEnCours;
    public bool TireGunEnCours;
    public bool TireShotgunEnCours;
    private bool ZombieTouchy;
    public bool Arme2IsActive;
    public bool Arme2FirstTime;
    public bool Arme3IsActive;
    public bool Arme3FirstTime;
    public bool Coup1;
    public bool Coup2;
    public bool SaignementUnique;

    public Text Ammo;

    public AudioSource source;
    public AudioClip Rech;
    public AudioClip Gunny;
    public AudioClip CoupDansLeVide;
    public AudioClip CoupDansLaChaire;
    public AudioClip CoupDeFeu;
    public AudioClip CoupDeFusil;
    public AudioClip RechargeGun;

    public int getBullet()
    {
        return bullet;
    }
    public int getAMMO()
    {
        return Munit;
    }
    public int getChargeur()
    {
        return DansChargeur;
    }
    public void setBullet(int BulletShotgun)
    {
        bullet = BulletShotgun;
        if (bullet <= 0)
        {
            bullet = 0;
            Tutoriel.GetComponent<Tutorial>().SetTuto(2);
        }
    }
    public void setFirstgun(bool FirstReloaded)
    {
        Arme2IsActive = FirstReloaded;
    }
    public void setFirstshotgun(bool FirstShotgun)
    {
        Arme3IsActive= FirstShotgun;
    }
    public void setChargeur(int Charge)
    {
        DansChargeur = Charge;
    }
    public void setAMMO(int value)
    {
        Munit = value;
        if (Munit <= 0)
        {
            Munit = 0;
            Tutoriel.GetComponent<Tutorial>().SetTuto(2);
        }
    }
    public void setZombieTouchy(bool Touche)
    {
        ZombieTouchy = Touche;
    }
    public bool getArme2Active ()
    {
        return Arme2IsActive;
    }
    public bool getArme3Active()
    {
        return Arme3IsActive;
    }
    public bool getArme2First()
    {
        return Arme2FirstTime;
    }
    public bool getArme3First()
    {
        return Arme3FirstTime;
    }
    public void setActiveArme (bool Arme2Active, bool Arme3Active, bool Arme2Fisrt, bool Arme3First)
    {
        Arme2IsActive = Arme2Active;
        Arme3IsActive = Arme3Active;
        Arme2FirstTime = Arme2Fisrt;
        Arme3FirstTime = Arme3First;
    }
    public int getArme()
    {
        return Weapon;
    }
    public void setArme(int Arme)
    {
        Weapon = Arme;
    }
    void Start()
    {
        Rechargement.gameObject.SetActive(false);
        ReLoad = false;
        Weapon = 0;
        Couteau.SetActive(false);
        SangLame.SetActive(false);
        FeuShotgun.SetActive(false);
        ZombieTouchy = false;
        Coup1 = false;
        Coup2 = false;
        SaignementUnique = false;
    }
    void Update()
    {
        bool TirEnCours = Input.GetKey((KeyCode)PlayerPrefs.GetInt("FireInt"));
        bool ChangementArme = Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt("NextWeaponInt"));
        bool Recharge = Input.GetKeyDown((KeyCode)PlayerPrefs.GetInt("ReloadInt"));

        if (TirEnCours && Weapon == 1 && Time.time > nextLoadCouteau)
        {
            nextLoadCouteau = Time.time + 0.5f; 
            StartCoroutine("CoupDeCouteau");
        }
        if (TirEnCours && Weapon == 2 && DansChargeur >0 && Time.time > nextLoadGun)
        {
            nextLoadGun = Time.time + 0.5f;
            StartCoroutine("FlammeGun");
            StartCoroutine("ReculFire");
        }
        if (TirEnCours && Weapon == 3 && bullet >0 && Time.time > nextLoadShotgun)
        {
            nextLoadShotgun = Time.time + 1.05f;
            StartCoroutine("FlammeShotGun");
            StartCoroutine("ShotGun");
        }
        bool TirGun = (Gun.activeSelf && Recharge && Munit > 0 && DansChargeur < 15 && (Time.time > nextReloader) && Weapon == 2);
        if (TirGun)
        {
            ReLoad = true;
            nextReloader = Time.time + 5.0f;
            StartCoroutine("RetraitChargeur");
            StartCoroutine("NouveauChargeur");
            if (DansChargeur + Munit < 15)
            {
                DansChargeur += Munit;
                Munit = 0;
            }
            else
            {
                if (DansChargeur > 0)
                {
                    EntreDeux = 15 - DansChargeur;
                    DansChargeur = 15;
                }
                else
                {
                    EntreDeux = 15;
                    DansChargeur = 15;
                }
                Munit -= EntreDeux;
            }
            if (DansChargeur <= 0) DansChargeur = 0;
            ReLoad = false;
        }
        bool MunitGun1 = (Munit + DansChargeur > 0);
        bool MunitShotgun = bullet > 0;

        if (ChangementArme)
        {
            Weapon += 1;
            if (Weapon == 2 && !Arme2IsActive) Weapon = 3;
            if (Weapon == 3 && !Arme3IsActive) Weapon = 0;
            if (Weapon == 3 && !MunitShotgun && Arme3IsActive) Weapon = 0;
            if (Weapon == 4) Weapon = 0;
        }
        if (Arme2IsActive && Arme2FirstTime)
        {
            Weapon = 2;
            Arme2FirstTime = false;
        }

        if (Arme3IsActive && Arme3FirstTime)
        {
            Weapon = 3;
            Arme3FirstTime = false;
        }

        if (Weapon == 3 && !MunitShotgun)
        {
            if (MunitGun1 && Arme2IsActive)
            {
                Weapon = 2;
            }
            else
            {
                Weapon = 1;
            }
        }

        if (Weapon == 2 && !MunitGun1)
        {
            if (MunitShotgun && Arme3IsActive)
            {
                Weapon = 3;
            }
            else
            {
                Weapon = 1;
            }
        }

        switch (Weapon)
        {
            case 0:
                Couteau.SetActive(false);
                SangLame.SetActive(false);
                Gun.SetActive(false);
                Shotgun.SetActive(false);
                Ammo.text = "";
                break;
            case 1:
                Couteau.SetActive(true);
                SangLame.SetActive(false);
                Gun.SetActive(false);
                Shotgun.SetActive(false);
                Ammo.text = "";
                break;
            case 2:
                Couteau.SetActive(false);
                SangLame.SetActive(false);
                Gun.SetActive(true);
                Shotgun.SetActive(false);
                Ammo.text = "AMMO " + DansChargeur + "/" + Munit;
                break;
            case 3:

                Couteau.SetActive(false);
                SangLame.SetActive(false);
                Gun.SetActive(false);
                Shotgun.SetActive(true);
                Ammo.text = "AMMO " + bullet;
                break;
        }

    }
    IEnumerator RetraitChargeur()
    {
        Rechargement.gameObject.SetActive(true);
        source.PlayOneShot(Rech, 0.3f);
        Chargeur.GetComponent<Animator>().SetTrigger("recharge");
        UpLoad.GetComponent<Animator>().SetTrigger("ReLoading");
        source.PlayOneShot(Rech, 1.0f);
        yield return new WaitForSeconds(0.7f);
    }
    IEnumerator NouveauChargeur()
    {
        Rechargement.GetComponent<Animator>().SetTrigger("recharge 2");
        yield return new WaitForSeconds(0.7f);
        source.PlayOneShot(Gunny, 1.0f);
        yield return new WaitForSeconds(1.3f);
        Rechargement.gameObject.SetActive(false);
        Chargeur.GetComponent<Animator>().SetTrigger("FinRecharge");
    }
    IEnumerator ReculFire()
    {
        if (!Coup1)
        {
            DansChargeur -= 1;
            Coup1 = true;
        }
        vol1 = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(CoupDeFeu, vol1);
        Gun.GetComponent<Animator>().SetTrigger("FireRecul");
        yield return new WaitForSeconds(0.5f);
        Coup1 = false;
        SaignementUnique = false;
    }
    IEnumerator ShotGun()
    {
        if (!Coup2)
        {
            bullet -= 1;
            Coup2 = true;
        }
        vol2 = Random.Range(volLowRange, volHighRange);
        Shotgun.GetComponent<Animator>().SetTrigger("FireShotGun");
        source.PlayOneShot(CoupDeFusil, vol2);
        yield return new WaitForSeconds(0.48f);
        source.PlayOneShot(RechargeGun, 1.0f);
        yield return new WaitForSeconds(0.57f);
        Coup2 = false;
        SaignementUnique = false;
    }

    IEnumerator CoupDeCouteau()
    {
        CoupDeCouteauEnCours = true;
        Couteau.GetComponent<Animator>().SetTrigger("FireCout");
        if (ZombieTouchy)
        {
            source.PlayOneShot(CoupDansLaChaire, 1.0f);
            SangLame.SetActive(true);
        }
        else
        {
            source.PlayOneShot(CoupDansLeVide, 1.0f);
        }
        yield return new WaitForSeconds(1.1f);
        SangLame.SetActive(false);
        CoupDeCouteauEnCours = false;
        SaignementUnique = false;
    }
    IEnumerator FlammeGun()
    {
        FeuGun.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        FeuGun.SetActive(false);
    }
    IEnumerator FlammeShotGun()
    {
        FeuShotgun.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        FeuShotgun.SetActive(false);
    }
    public void setSaignementUnique(bool SUnique)
    {
        SaignementUnique = SUnique;
    }
    public void getSaignementUnique(out bool SUnique)
    {
        SUnique = SaignementUnique;
    }
}
