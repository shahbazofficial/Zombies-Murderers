using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    public GameObject Arme;
    public GameObject Gun;
    public GameObject Munit;
    public GameObject Attack;
    public GameObject Zombie;
    public GameObject NumberDead;
    public GameObject Life;
    public GameObject RetourMenu;
    private int Tuto = 1;
    
	void Start () {
        Arme.SetActive(false);
        Gun.SetActive(false);
        Munit.SetActive(false);
        Attack.SetActive(false);
        Zombie.SetActive(false);
        NumberDead.SetActive(false);
        Life.SetActive(false);
        RetourMenu.SetActive(false);        	
	}
	
	void Update () {
		switch (Tuto)
        {
            case 2:
                Arme.SetActive(true);
                Gun.SetActive(true);
                Munit.SetActive(true);
                Attack.SetActive(false);
                RetourMenu.SetActive(false);
                break;
            case 3:
                Arme.SetActive(false);
                Gun.SetActive(true);
                Munit.SetActive(true);
                Attack.SetActive(true);
                Zombie.SetActive(true);
                NumberDead.SetActive(true);
                Life.SetActive(true);
                RetourMenu.SetActive(false);
                break;
            case 4:
                Arme.SetActive(false);
                Gun.SetActive(false);
                Munit.SetActive(false);
                Attack.SetActive(false);
                Zombie.SetActive(true);
                NumberDead.SetActive(false);
                Life.SetActive(false);
                RetourMenu.SetActive(true);
                break;
            default:
                Arme.SetActive(false);
                Gun.SetActive(false);
                Munit.SetActive(false);
                Attack.SetActive(false);
                NumberDead.SetActive(false);
                Life.SetActive(false);
                RetourMenu.SetActive(false);
                break;
        }
	}

    public int GetTuto()
    {
        return Tuto;
    }

    public void SetTuto(int value)
    {
        Tuto = value;
    }
}
