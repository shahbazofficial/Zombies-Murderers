using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class MouseTargetShoot : MonoBehaviour {
	private static MouseTargetShoot mInstance;
	public static MouseTargetShoot instance { get { return mInstance; } }
	public SpriteRenderer TargetSprite;
	public bool choix = true;

    // Use this for initialization
    void Start () {
		if (mInstance == null) {
			mInstance = this;
		}
	}

    public void TargetShoot(bool choosen){
		if (choosen) {
			TargetSprite.color = Color.white;
			choix = true; 
		} else {
			TargetSprite.color = Color.red;
			choix = false;
		}
	}
	void Update ()
    {  
    }
}

