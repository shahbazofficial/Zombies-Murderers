using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Threading;
using UnityEngine.SceneManagement;

public class MouseTarget : MonoBehaviour {

    public SpriteRenderer TargetSprite;
	public bool choix = true;

	public void LoadScene(int level)
    {
		SceneManager.LoadScene (level);	
	}
	
	public void TargetChoosen(bool choosen){

		if (choosen) {
			TargetSprite.color = Color.white;
			choix = true; 
		} else {
			TargetSprite.color = Color.red;
			choix = false;
		}
	}
	void Update () {
		if(choix == false){
			LoadScene (LoadOnSurvol.choixscene);
		}
	}
}

