using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockedLevel : MonoBehaviour {
    private int NiveauEnCours;
    public GameObject LockLevel1;
    public GameObject UnlockLevel1;
    public GameObject LockLevel2;
    public GameObject UnlockLevel2;
    public GameObject LockLevel3;
    public GameObject UnlockLevel3;
    public GameObject LockLevel4;
    public GameObject UnlockLevel4;
    public GameObject LockLevel5;
    public GameObject UnlockLevel5;
    public GameObject LockLevel6;
    public GameObject UnlockLevel6;
    public GameObject GameOver;
    public GameObject ObjetRelais;

    // Use this for initialization
    void Start () {
        NiveauEnCours = ObjetRelais.GetComponent<ScriptRelais>().getNU();
        if (NiveauEnCours != 1 && NiveauEnCours != 2 && NiveauEnCours != 3 && NiveauEnCours != 4 && NiveauEnCours != 5 && NiveauEnCours != 6 && NiveauEnCours != 7)
            ObjetRelais.GetComponent<ScriptRelais>().setNU(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (NiveauEnCours)
        {
            case 1:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(true);
                UnlockLevel2.SetActive(false);
                LockLevel3.SetActive(true);
                UnlockLevel3.SetActive(false);
                LockLevel4.SetActive(true);
                UnlockLevel4.SetActive(false);
                LockLevel5.SetActive(true);
                UnlockLevel5.SetActive(false);
                LockLevel6.SetActive(true);
                UnlockLevel6.SetActive(false);
                GameOver.SetActive(false);
                break;
            case 2:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(false);
                UnlockLevel2.SetActive(true);
                LockLevel3.SetActive(true);
                UnlockLevel3.SetActive(false);
                LockLevel4.SetActive(true);
                UnlockLevel4.SetActive(false);
                LockLevel5.SetActive(true);
                UnlockLevel5.SetActive(false);
                LockLevel6.SetActive(true);
                UnlockLevel6.SetActive(false);
                GameOver.SetActive(false);
                break;
            case 3:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(false);
                UnlockLevel2.SetActive(true);
                LockLevel3.SetActive(false);
                UnlockLevel3.SetActive(true);
                LockLevel4.SetActive(true);
                UnlockLevel4.SetActive(false);
                LockLevel5.SetActive(true);
                UnlockLevel5.SetActive(false);
                LockLevel6.SetActive(true);
                UnlockLevel6.SetActive(false);
                GameOver.SetActive(false);
                break;
            case 4:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(false);
                UnlockLevel2.SetActive(true);
                LockLevel3.SetActive(false);
                UnlockLevel3.SetActive(true);
                LockLevel4.SetActive(false);
                UnlockLevel4.SetActive(true);
                LockLevel5.SetActive(true);
                UnlockLevel5.SetActive(false);
                LockLevel6.SetActive(true);
                UnlockLevel6.SetActive(false);
                GameOver.SetActive(false);
                break;
            case 5:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(false);
                UnlockLevel2.SetActive(true);
                LockLevel3.SetActive(false);
                UnlockLevel3.SetActive(true);
                LockLevel4.SetActive(false);
                UnlockLevel4.SetActive(true);
                LockLevel5.SetActive(false);
                UnlockLevel5.SetActive(true);
                LockLevel6.SetActive(true);
                UnlockLevel6.SetActive(false);
                GameOver.SetActive(false);
                break;
            case 6:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(false);
                UnlockLevel2.SetActive(true);
                LockLevel3.SetActive(false);
                UnlockLevel3.SetActive(true);
                LockLevel4.SetActive(false);
                UnlockLevel4.SetActive(true);
                LockLevel5.SetActive(false);
                UnlockLevel5.SetActive(true);
                LockLevel6.SetActive(false);
                UnlockLevel6.SetActive(true);
                GameOver.SetActive(false);
                break;
            case 7:
                LockLevel1.SetActive(false);
                UnlockLevel1.SetActive(true);
                LockLevel2.SetActive(false);
                UnlockLevel2.SetActive(true);
                LockLevel3.SetActive(false);
                UnlockLevel3.SetActive(true);
                LockLevel4.SetActive(false);
                UnlockLevel4.SetActive(true);
                LockLevel5.SetActive(false);
                UnlockLevel5.SetActive(true);
                LockLevel6.SetActive(false);
                UnlockLevel6.SetActive(true);
                GameOver.SetActive(true);
                break;
            default:
                LockLevel1.SetActive(true);
                UnlockLevel1.SetActive(false);
                LockLevel2.SetActive(true);
                UnlockLevel2.SetActive(false);
                LockLevel3.SetActive(true);
                UnlockLevel3.SetActive(false);
                LockLevel4.SetActive(true);
                UnlockLevel4.SetActive(false);
                LockLevel5.SetActive(true);
                UnlockLevel5.SetActive(false);
                LockLevel6.SetActive(true);
                UnlockLevel6.SetActive(false);
                GameOver.SetActive(false);
                break;
        }
            
    }
}
