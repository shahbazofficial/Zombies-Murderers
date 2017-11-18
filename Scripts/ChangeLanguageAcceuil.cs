using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguageAcceuil : MonoBehaviour {

    public Text MiseEnRouteBefore;
    public Text MiseEnRouteAfter;
    public Text Level1Before;
    public Text Level1After;
    public Text Level2Before;
    public Text Level2After;
    public Text Level3Before;
    public Text Level3After;
    public Text Level4Before;
    public Text Level4After;
    public Text Level5Before;
    public Text Level5After;
    public Text Level6Before;
    public Text Level6After;
    public Text Quitter;
    private string miseenroute;
    private string niveau;
    private string avenir;
    private string quitter;
    public GameObject Language;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey("AxeVertical") && PlayerPrefs.HasKey("AxeHorizontal") && PlayerPrefs.HasKey("NextWeapon") && PlayerPrefs.HasKey("Fire") && PlayerPrefs.HasKey("Reload"))
        {
            MiseEnRouteAfter.enabled = true;
            MiseEnRouteBefore.enabled = false;
            Level1After.text = niveau + " 1";
            Level2After.text = niveau + " 2";
            Level3After.text = niveau + " 3";
            Level4After.text = niveau + " 4";
            Level5After.text = niveau + " 5";
            Level6After.text = niveau + " 6";
        }
        else
        {
            MiseEnRouteAfter.enabled = false;
            MiseEnRouteBefore.enabled = true;
            Level1After.text = "Setting Up game before to Play" + "\n" + "Configurer le jeu avant de commencer";
            Level2After.text = "Setting Up game before to Play" + "\n" + "Configurer le jeu avant de commencer";
            Level3After.text = "Setting Up game before to Play" + "\n" + "Configurer le jeu avant de commencer";
            Level4After.text = "Setting Up game before to Play" + "\n" + "Configurer le jeu avant de commencer";
            Level5After.text = "Setting Up game before to Play" + "\n" + "Configurer le jeu avant de commencer";
            Level6After.text = "Setting Up game before to Play" + "\n" + "Configurer le jeu avant de commencer";
        }
        miseenroute = Language.GetComponent<xmlReader>().miseenroute;
        niveau = Language.GetComponent<xmlReader>().niveau;
        avenir = Language.GetComponent<xmlReader>().avenir;
        quitter = Language.GetComponent<xmlReader>().quitter;
        MiseEnRouteAfter.text = miseenroute;
        Level1Before.text = niveau + " 1";
        Level2Before.text = niveau + " 2";
        Level3Before.text = niveau + " 3";
        Level4Before.text = niveau + " 4";
        Level5Before.text = niveau + " 5";
        Level6Before.text = niveau + " 6";
        Quitter.text = quitter;
    }
}
