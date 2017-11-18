using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManageKey : MonoBehaviour
{
    private KeyCode code;
    private string NameCode;
    private string axe;
    private float H;
    private float V;
    public Text Avancer;
    public Text Gauche;
    public Text NextWeapon;
    public Text Fire;
    public Text Reload;
    public int MyKey;
    public bool ModifTouche = false;
    public bool KeyChangedHere = true;
    private int ChangementTouche = 0;
    public GameObject Traduction;
    private string avancer;
    private string gauche;
    private string fire;
    private string nextweapon;
    private string reload;
    private string nonaxe;
    private string none;
    private string pressaxis2s;
    private string pressbutton2s;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        avancer = Traduction.GetComponent<xmlReader>().avancer;
        gauche = Traduction.GetComponent<xmlReader>().gauche;
        fire = Traduction.GetComponent<xmlReader>().fire;
        nextweapon = Traduction.GetComponent<xmlReader>().nextweapon;
        reload = Traduction.GetComponent<xmlReader>().reload;
        nonaxe = Traduction.GetComponent<xmlReader>().nonaxe;
        none = Traduction.GetComponent<xmlReader>().none;
        pressaxis2s = Traduction.GetComponent<xmlReader>().pressaxis2s;
        pressbutton2s = Traduction.GetComponent<xmlReader>().pressbutton2s;
        
        ModifTouche = (ChangementTouche != 0);
        if (!ModifTouche && PlayerPrefs.HasKey("AxeVertical"))
        {
            if (PlayerPrefs.GetFloat("AxeVerticalsign") > 0)
            {
                Avancer.text = avancer + "\n" + "+" + PlayerPrefs.GetString("AxeVertical");
            }
            else
            {
                Avancer.text = avancer + "\n" + "-" + PlayerPrefs.GetString("AxeVertical");
            }
        }
        else
        {
            if (!ModifTouche && !PlayerPrefs.HasKey("AxeVertical")) Avancer.text = avancer + "\n" + nonaxe;
        }
        if (!ModifTouche && PlayerPrefs.HasKey("AxeHorizontal"))
        {
            if (PlayerPrefs.GetFloat("AxeHorizontalsign") > 0)
            {
                Gauche.text = gauche + "\n" + "+" + PlayerPrefs.GetString("AxeHorizontal");
            }
            else
            {
                Gauche.text = gauche + "\n" + "-" + PlayerPrefs.GetString("AxeHorizontal");
            }
        }
        else
        {
            if (!ModifTouche && !PlayerPrefs.HasKey("AxeHorizontal")) Gauche.text = gauche + "\n" + nonaxe;
        }
        if (!ModifTouche && PlayerPrefs.HasKey("NextWeapon"))
        {
            NextWeapon.text = nextweapon + "\n" + PlayerPrefs.GetString("NextWeapon");
        }
        else
        {
            if (!ModifTouche && !PlayerPrefs.HasKey("NextWeapon")) NextWeapon.text = nextweapon + "\n" + none;
        }
        if (!ModifTouche && PlayerPrefs.HasKey("Fire"))
        {
            Fire.text = fire + "\n" + PlayerPrefs.GetString("Fire");
        }
        else
        {
            if (!ModifTouche && !PlayerPrefs.HasKey("Fire")) Fire.text = fire + "\n" + none;
        }
        if (!ModifTouche && PlayerPrefs.HasKey("Reload"))
        {
            Reload.text = reload + "\n" + PlayerPrefs.GetString("Reload");
        }
        else
        {
            if (!ModifTouche && !PlayerPrefs.HasKey("Reload")) Reload.text = reload + "\n" + none;
        }

        Debug.Log("Axe Vertical = " + PlayerPrefs.GetString("AxeVertical").ToString());
        Debug.Log("Signe Axe Vertical = " + PlayerPrefs.GetFloat("AxeVerticalsign").ToString());
        Debug.Log("Axe Horizontal = " + PlayerPrefs.GetString("AxeHorizontal").ToString());
        Debug.Log("Signe Axe Horizontal = " + PlayerPrefs.GetFloat("AxeHorizontalsign").ToString());
        Debug.Log("Touche Fire = " + PlayerPrefs.GetString("Fire"));
        Debug.Log("Touche Reload = " + PlayerPrefs.GetString("Reload"));
        Debug.Log("Touche NextWeapon = " + PlayerPrefs.GetString("NextWeapon"));
        if (ChangementTouche != 0) ModifTouche = true;
        if (ChangementTouche == 1)
        {
            PlayerPrefs.DeleteKey("AxeVertical");
            Avancer.text = avancer + "\n" + pressaxis2s;
            StartCoroutine(FindAxis("AxeVertical"));
        }
        if (ChangementTouche == 2)
        {
            PlayerPrefs.DeleteKey("AxeHorizontal");
            Gauche.text = gauche + "\n" + pressaxis2s;
            StartCoroutine(FindAxis("AxeHorizontal"));
        }
        if (ChangementTouche == 3)
        {
            PlayerPrefs.DeleteKey("NextWeapon");
            NextWeapon.text = nextweapon + "\n" + pressbutton2s;
            StartCoroutine(FindKeys("NextWeapon"));
        }
        if (ChangementTouche == 4)
        {
            PlayerPrefs.DeleteKey("Fire");
            Fire.text = fire + "\n" + pressbutton2s;
            StartCoroutine(FindKeys("Fire"));
        }
        if (ChangementTouche == 5)
        {
            PlayerPrefs.DeleteKey("Reload");
            Reload.text = reload + "\n" + pressbutton2s;
            StartCoroutine(FindKeys("Reload"));
        }
    }

    IEnumerator FindAxis(string NameOfAxis)
    {
        KeyChangedHere = true;
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

        if (H > 0)
        {
            PlayerPrefs.SetString(NameOfAxis, "Horizontal");
            PlayerPrefs.SetFloat(NameOfAxis + "sign", 1f);
        }
        if (H < 0)
        {
            PlayerPrefs.SetString(NameOfAxis, "Horizontal");
            PlayerPrefs.SetFloat(NameOfAxis + "sign", -1f);
        }
        if (V > 0)
        {
            PlayerPrefs.SetString(NameOfAxis, "Vertical");
            PlayerPrefs.SetFloat(NameOfAxis + "sign", 1f);
        }
        if (V < 0)
        {
            PlayerPrefs.SetString(NameOfAxis, "Vertical");
            PlayerPrefs.SetFloat(NameOfAxis + "sign", -1f);
        }

        if (PlayerPrefs.HasKey(NameOfAxis))
        {
            ModifTouche = false;
            ChangementTouche = 0;
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            ModifTouche = false;
            ChangementTouche = 0;
        }
    }

    IEnumerator FindKeys(string NameOfKeys)
    {
        System.Array values = System.Enum.GetValues(typeof(KeyCode));
        foreach (KeyCode code in values)
        {
            if (Input.GetKeyDown(code))
            {
                PlayerPrefs.SetInt(NameOfKeys + "Int", (int)code);

                PlayerPrefs.SetString(NameOfKeys, code.ToString());
            }
            if (PlayerPrefs.HasKey(NameOfKeys)) break;
        }

        if (PlayerPrefs.HasKey(NameOfKeys))
        {
            ModifTouche = false;
            ChangementTouche = 0;
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            ModifTouche = false;
            ChangementTouche = 0;
        }
    }

    public void setKeysValue(int ChoixTouche)
    {
        Debug.Log("setKeysValue Launch");
        ChangementTouche = ChoixTouche; 
    }    
}
