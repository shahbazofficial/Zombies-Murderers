using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDeVie : MonoBehaviour {
    public int hp;
    public GameObject Tutoriel;
    public int getHP()
    {
    return hp;
    }
    public void setHP(int value)
    {
    hp = value;
        if (hp < 1)
        {
            Tutoriel.GetComponent<Tutorial>().SetTuto(4);
            hp = 0;
        }
    }
}
