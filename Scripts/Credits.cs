using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
	public bool choixcontact=true;
	public GameObject loadingImage;

	public void Affichage () {
		if (choixcontact == true) {
		    loadingImage.SetActive(choixcontact);
			choixcontact = false;
		} else {
			loadingImage.SetActive(choixcontact);
			choixcontact = true;
		}
	}
}

