using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ShootOnSurvol : MonoBehaviour
{

    public GameObject ZombieCible;
    public GameObject ZombieDying;
    public GameObject CRDBRD;
    public GameObject ProgresseBar;
    public GameObject Tutoriel;
    public GameObject GunCible;
    public GameObject ShutGun;
    public GameObject CardMain;
    public GameObject SangSurLame;
    public GameObject SangPistol;
    public GameObject SangDead;
    public GameObject HeadOfZombie;
    public GameObject SangPlaie;
    public GameObject Couteau;
    public GameObject ZombieTarget;
    public GameObject HeadCollider;

    private AudioSource source;
    public AudioClip DeadFear;
    public AudioClip CoupDansLeVide;
    public AudioClip CoupDansLaChaire;

    public Vector3 hit;

    public bool isLookedAt = true;
    public bool reload;
    private bool mPreviousChoosen;
    private bool Mort;
    private bool killed = false;
    private bool ZombieTouchy;
    private bool TirEnCours;
    private bool TireGunEnCours;
    private bool TireShotgunEnCours;
    public bool RegardeZombie;
    public bool HeadZombView;
    public bool SaignementUnique;
    public bool SaignementUniqueDead;

    private float nextActionTime = 0.0f;
    private float period = 1.0f;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public float nextLoadGun = 0.0f;
    public float nextLoadShotgun = 0.0f;
    public float nextLoadCouteau = 0.0f;

    public int ptdv = 100;
    private int GUItext;
    private int nbzo;
    private int LifePlayer;
    private int AmmoRest;
    private int Autre;
    private int DansChargeur;
    private int MunitShutGun;

    public List<RaycastHit> rayhits;

    //NavMeshAgent playerAgent;

    void Start()
    {
        //playerAgent = GetComponent<NavMeshAgent>();
        AmmoRest = CardMain.GetComponent<AMMO>().getAMMO();
        DansChargeur = 0;
        source = GetComponent<AudioSource>();
        SangSurLame.SetActive(false);
        TireGunEnCours = false;
        TireShotgunEnCours = false;
        Couteau.SetActive(false);
        GunCible.SetActive(false);
        ShutGun.SetActive(false);
        RegardeZombie = false;
        SaignementUnique = false;
}

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        CardMain.GetComponent<AMMO>().getSaignementUnique(out SaignementUnique);

        Vector3 endPosition = GvrPointerInputModule.CurrentRaycastResult.worldPosition;

        TirEnCours = Input.GetKey((KeyCode)PlayerPrefs.GetInt("FireInt"));
        ptdv = ZombieCible.GetComponent<PointDeVie>().getHP();
        LifePlayer = CardMain.GetComponent<PointDeVie>().getHP();
        if (TirEnCours && LifePlayer > 0)
        {
            if (GvrPointerInputModule.CurrentRaycastResult.isValid) GetInteraction(endPosition, out hit, out RegardeZombie, out HeadZombView);
            reload = CardMain.GetComponent<AMMO>().ReLoad;
            DansChargeur = CardMain.GetComponent<AMMO>().getChargeur();
            bool OkForGun = (!reload && DansChargeur > 0 && GunCible.activeSelf && Time.time > nextLoadGun);
            if (OkForGun)
            {
                nextLoadGun = Time.time + 0.5f;
                if (RegardeZombie || HeadZombView)
                {
                    Debug.Log("Coup de Gun blessant" + isLookedAt.ToString());
                    if (!SaignementUnique)
                    {
                        GameObject Hemoragie = Instantiate(SangPistol, hit, Quaternion.Euler(0, 180, 0));
                        Hemoragie.transform.parent = HeadOfZombie.transform;
                        CardMain.GetComponent<AMMO>().setSaignementUnique(true);
                    }
                        if (LifePlayer > 1 && DansChargeur > 0)
                    {
                        if (HeadZombView) ptdv -= 110;
                        if (RegardeZombie) ptdv -= 10;
                    }
                }
            }
            MunitShutGun = CardMain.GetComponent<AMMO>().getBullet();
            bool OkForShotgun = (ShutGun.activeSelf == true && MunitShutGun > 0 && Time.time > nextLoadShotgun);
            if (OkForShotgun)
            {
                nextLoadShotgun = Time.time + 1.05f;
                Debug.Log("Coup de Fusil");
                if (RegardeZombie || HeadZombView)
                {
                    Debug.Log("Coup de Fusil blessant" + isLookedAt.ToString());
                    if (!SaignementUnique)
                    {
                        GameObject Hemoragie = Instantiate(SangPistol, hit, Quaternion.Euler(0, 180, 0));
                        Hemoragie.transform.parent = HeadOfZombie.transform;
                        CardMain.GetComponent<AMMO>().setSaignementUnique(true);
                    }
                    if (LifePlayer > 1 && MunitShutGun > 0)
                    {
                        if (HeadZombView) ptdv -= 110;
                        if (RegardeZombie) ptdv -= 40;
                    }
                }
            }
            ZombieTouchy = ZombieDying.GetComponent<MoveZombie>().ZombieTouch;
            bool OkForKnife = (Couteau.activeSelf == true && Time.time > nextLoadCouteau);
            if (OkForKnife)
            {
                nextLoadCouteau = Time.time + 0.0f;
                if (ZombieTouchy)
                {
                    if (!SaignementUnique)
                    {
                        GameObject CoupDeCout = Instantiate(SangPistol, hit, Quaternion.Euler(0, 0, 0));
                        CoupDeCout.transform.parent = HeadOfZombie.transform;
                        GameObject CoupDeCout2 = Instantiate(SangPlaie, hit, Quaternion.Euler(0, 0, 0));
                        CoupDeCout2.transform.parent = HeadOfZombie.transform;
                        CardMain.GetComponent<AMMO>().setSaignementUnique(true);
                    }
                    if (ZombieTouchy && LifePlayer > 1)
                    {
                        if (ZombieTouchy && HeadZombView) ptdv -= 110;
                        if (ZombieTouchy) ptdv -= 45;
                    }
                }
            }
        }
        if (ptdv < 20)
        {
            ZombieDying.GetComponent<Animator>().SetTrigger("Faible");
            if (ptdv < 1 && !killed)
            {
                ZombieDying.GetComponent<Animator>().SetTrigger("Dead");
                Tutoriel.GetComponent<Tutorial>().SetTuto(4);
                source.PlayOneShot(DeadFear, 1.0f);
                ZombieDying.GetComponent<MoveZombie>().setZdead(true);
                nbzo = CRDBRD.GetComponent<CountOfZombies>().getNZR();
                nbzo += 1;
                CRDBRD.GetComponent<CountOfZombies>().setNZR(nbzo);
                killed = true;
                ProgresseBar.gameObject.SetActive(false);
            }
        }
        if (ptdv <= 0 && !SaignementUnique)
        {
            GameObject VidangeSang = Instantiate(SangDead, hit, Quaternion.Euler(0, 180, 0));
            VidangeSang.transform.parent = HeadOfZombie.transform;
            CardMain.GetComponent<AMMO>().setSaignementUnique(true);
            SaignementUniqueDead = true;
            ZombieCible.GetComponent<PointDeVie>().setHP(ptdv);
        }
        if (!SaignementUniqueDead) ZombieCible.GetComponent<PointDeVie>().setHP(ptdv);
        RegardeZombie = false;
    }
    void GetInteraction(Vector3 endPosition, out Vector3 myhit, out bool myRegardeZombie, out bool myHeadZombView)
    {
        Camera cam = Camera.main;
        GameObject interactedObject;

        RaycastResult MyRayCast = GvrPointerInputModule.CurrentRaycastResult;
        myhit = MyRayCast.worldPosition;
        interactedObject = MyRayCast.gameObject;
        
        if (interactedObject != null)
        {
            Debug.Log(interactedObject.ToString());
            myRegardeZombie = (interactedObject == ZombieTarget || interactedObject == ZombieDying);
            myHeadZombView = (interactedObject == HeadCollider);
            Debug.Log("CurrentCible is " + interactedObject.name);
        }
        else
        {
            myRegardeZombie = false;
            myHeadZombView = false;
            interactedObject = null;
        }

        Debug.Log("Cible is " + myRegardeZombie);

        Debug.Log("HeadCible is " + myHeadZombView);
    }
}