using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RetourMenu : MonoBehaviour {

    public double AngleDeRotation;

    public void Update () {
        if (Camera.main.GetComponent<Camera>().transform.eulerAngles.z >= AngleDeRotation && Camera.main.GetComponent<Camera>().transform.eulerAngles.z <= (360- AngleDeRotation))
        {
            SceneManager.LoadScene(0);
        }
    }
}
