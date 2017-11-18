using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveZombie : MonoBehaviour
{
    public GameObject PlayerHead;
    private Vector3 wantedPosition;
    private Vector3 newWantedPosition;
    private Vector3 wantedRotation;
    public float speed;
    public int PointOfLife;
    public GameObject ZombieCible;
    private bool ZombieDead = false;
    public bool ZombieTouch = false;
    public GameObject YoureDead;
    public GameObject Fusil;
    public GameObject Gun;
    public GameObject Couteau;
    public AudioClip Blessure;
    public AudioClip Marche;
    private AudioSource source;
    public GameObject ZombieEnCours;
    public GameObject Tutoriel;
    public int PV;
    public int ZZ;
    public int ZPV;

    //Pour empêcher de continuer d'avancer contre un objet.
    private bool ReturnPos;


    void Start()
    {
        YoureDead.SetActive(false);
        source = GetComponent<AudioSource>();
        StartCoroutine("ZombieWalk");
        source.loop = true;
        source.clip = Marche;
        source.Play();
    }

    void FixedUpdate()
    {
        source.volume -= Time.deltaTime * 2;

        wantedPosition = PlayerHead.transform.position;
        newWantedPosition = new Vector3(wantedPosition.x, 0f, wantedPosition.z);

        wantedRotation = newWantedPosition - transform.position;
        Vector3 direction = wantedRotation.normalized;

        ZPV = ZombieCible.GetComponent<PointDeVie>().getHP();
        if (ZPV > 0)
        {
            if (!ZombieDead)
            {
                transform.LookAt(newWantedPosition);
                if (ZPV > 20)
                {
                    if (!ReturnPos)
                    {
                        GetComponent<Rigidbody>().MovePosition(transform.position + direction * 1.5f * speed * Time.deltaTime);
                    }
                }
            }
            if (ZombieDead)
            {
                StartCoroutine("ZombieAfterDead");
            }

            if (ZombieTouch)
            {
                PlayerHead.GetComponent<AMMO>().setZombieTouchy(ZombieTouch);
                if (ZPV > 0)
                {
                    StopCoroutine("ZombieWalk");
                    source.PlayOneShot(Blessure, 1.0f);
                    ZombieEnCours.GetComponent<Animator>().ResetTrigger("attackOff");
                    ZombieEnCours.GetComponent<Animator>().SetTrigger("attackOn");
                    PV = PlayerHead.GetComponent<PointDeVie>().getHP();
                    int PVRandom = UnityEngine.Random.Range(1, 2);
                    PV -= PVRandom;
                    PlayerHead.GetComponent<PointDeVie>().setHP(PV);
                }
                PV = PlayerHead.GetComponent<PointDeVie>().getHP();
                if (PV < 1)
                {
                    YoureDead.SetActive(true);
                    StopCoroutine("ZombieAttack");
                    ZombieEnCours.GetComponent<Animator>().SetTrigger("HumanDead");
                    Fusil.SetActive(false);
                    Gun.SetActive(false);
                    Couteau.SetActive(false);
                    Tutoriel.GetComponent<Tutorial>().SetTuto(4);
                }
            }
            else
            {
                StopCoroutine("ZombieAttack");
                StopCoroutine("SoundBlessure");
                //StartCoroutine("ZombieWalk");
                ZombieEnCours.GetComponent<Animator>().ResetTrigger("Walk");
                ZombieEnCours.GetComponent<Animator>().SetTrigger("Walk");
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ForLife" || other.gameObject.name == "GunCible" || other.gameObject.name == "ArmKnyfe" || other.gameObject.name == "ShutGun")
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ForLife" || other.gameObject.name == "GunCible" || other.gameObject.name == "ArmKnyfe" || other.gameObject.name == "ShutGun")
        {
            ZombieTouch = true;
        }
        ReturnPos = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ForLife" || other.gameObject.name == "GunCible" || other.gameObject.name == "ArmKnyfe" || other.gameObject.name == "ShutGun")
        {
            ZombieTouch = false;
        }
        GetComponent<Rigidbody>().isKinematic = false;
        StopCoroutine("ZombieAttack");
        ZombieEnCours.GetComponent<Animator>().SetTrigger("attackOff");
        ZombieEnCours.GetComponent<Animator>().ResetTrigger("Walk");
        ZombieEnCours.GetComponent<Animator>().SetTrigger("Walk");
    }

    public void setZdead(bool DEAD)
    {
        ZombieDead = DEAD;
        source.clip = Marche;
        source.loop = false;
        source.Stop();
    }
    IEnumerator SoundBlessure()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.025f);
            source.PlayOneShot(Blessure, 1.0f);
        }
    }
    IEnumerator ZombieWalk()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            ZombieEnCours.GetComponent<Animator>().ResetTrigger("Walk");
            ZombieEnCours.GetComponent<Animator>().SetTrigger("Walk");
        }
    }
    IEnumerator ZombieAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ZombieEnCours.GetComponent<Animator>().ResetTrigger("attackOff");
            ZombieEnCours.GetComponent<Animator>().SetTrigger("attackOn");
        }
    }
    IEnumerator HumanDead()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.75f);
            ZombieEnCours.GetComponent<Animator>().SetTrigger("HumanDead");
        }
    }
    IEnumerator ZombieAfterDead()
    {
        yield return new WaitForSeconds(4.0f);
        int childs = transform.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}