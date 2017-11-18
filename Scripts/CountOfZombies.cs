using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountOfZombies : MonoBehaviour {
    private List<GameObject> NumberZombies;
    public int NZ;
    private int NZR;
    public Text NbZomb;
    public GameObject YouWin;
    public GameObject Tutoriel;
    public int NiveauEnCours;
    private int DernierNiveau;
    public GameObject ObjetRelais;
    public GameObject PorteDeSortie;
    public bool DejaActif = false;
    public GameObject PorteFerme;
    public GameObject PorteOuverte;

    // Use this for initialization
    void Start ()
    {
        NZR = 0;
        NZ = 0;
        foreach(GameObject zombie in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (zombie.name == "TargetZombie")
            NZ += 1;
        }
        DernierNiveau = ObjetRelais.GetComponent<ScriptRelais>().getNU();
        YouWin.SetActive(false);
        PorteDeSortie.SetActive(false);
        PorteOuverte.SetActive(false);
        PorteFerme.SetActive(true);
    }

    // Update is called once per frame
    public int getNZR()
    {
        return NZR;
    }
    public void setNZR(int value)
    {
        NZR = value;
    }
    void Update ()
    {
        if (NZR < 2)
        {
            NbZomb.text = NZR + " ZOMBIE KILLED ON " + NZ;
        }
        else
        {
            NbZomb.text = NZR + " ZOMBIES KILLED ON " + NZ;
        } 
        if (NZR == NZ)
        {
            if (DernierNiveau == NiveauEnCours)
            {
                NiveauEnCours += 1;
                ObjetRelais.GetComponent<ScriptRelais>().setNU(NiveauEnCours);
            }
            if (!DejaActif)
            {
                StartCoroutine(SortieDeNiveau());
                DejaActif = true;
            }
        }
    }
    IEnumerator SortieDeNiveau(float tempsEnSecondes = 8f)
    {
        YouWin.SetActive(true);
        yield return new WaitForSeconds(tempsEnSecondes);
        YouWin.SetActive(false);
        PorteDeSortie.SetActive(true);
        PorteOuverte.SetActive(true);
        PorteFerme.SetActive(false);
    }
}
