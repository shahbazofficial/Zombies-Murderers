using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Autowalk : MonoBehaviour 
{
    public GameObject loadingImage1;
    public GameObject loadingImage2;

    public float yOffSet;

	//This is the variable for the player speed
	public float speed;
    private float Speed2;
    public float deltaSpeed;

    //points de vie Joueur restant.
    public Text PVRest;

    public GameObject CRDPTV;
    private int PointDeVie;
    private Vector3 moveDirection;

    //Tuto
    public GameObject Tutoriel;

	void Start () 
	{
        loadingImage1.SetActive(true);
        loadingImage2.SetActive(false);
        yOffSet = 1.75f;
        deltaSpeed = 1;
    }
	
	void Update () 
	{
        CharacterController controller = GetComponent<CharacterController>();
        float vertical = -1 * PlayerPrefs.GetFloat("AxeVerticalsign") * Input.GetAxis(PlayerPrefs.GetString("AxeVertical"));
        float horizontal = -1 * PlayerPrefs.GetFloat("AxeHorizontalsign") * Input.GetAxis(PlayerPrefs.GetString("AxeHorizontal"));
        transform.position = new Vector3(transform.position.x, yOffSet, transform.position.z);

        PointDeVie = CRDPTV.GetComponent<PointDeVie>().getHP();
        if (PointDeVie > 1)
        {
            int TutoVal = Tutoriel.GetComponent<Tutorial>().GetTuto();
            if (TutoVal == 1)
            Tutoriel.GetComponent<Tutorial>().SetTuto(2);

            moveDirection = new Vector3(horizontal, 0, -vertical);
            moveDirection = Camera.main.transform.TransformDirection(moveDirection).normalized;
            if (moveDirection.magnitude != 1) moveDirection.Normalize();

            
            if (vertical + horizontal != 0 && deltaSpeed <= 2f) deltaSpeed += 0.005f;
            if (vertical + horizontal == 0) { deltaSpeed = 1; controller.Move(Vector3.zero); }
            Speed2 = speed * deltaSpeed;

            moveDirection *= Speed2;
            controller.Move(moveDirection * Time.deltaTime);
            loadingImage1.SetActive(false);
            loadingImage2.SetActive(true);
        }
        if (PointDeVie < 1) yOffSet = 0.5f;
        int PV = CRDPTV.GetComponent<PointDeVie>().getHP();
        PVRest.text = "LIFE  " + PV + "/100";

    }
}
