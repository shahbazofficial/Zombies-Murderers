using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptRelais : MonoBehaviour {

    private int NiveauUnlock;
    public int getNU()
    {
        NiveauUnlock = PlayerPrefs.GetInt("NiveauCours");
        return NiveauUnlock;
    }
    public void setNU(int value)
    {
        PlayerPrefs.SetInt("NiveauCours", value);
        PlayerPrefs.Save();
    }
}
