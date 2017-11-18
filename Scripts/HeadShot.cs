using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShot : MonoBehaviour {

    public bool HeadView = true;
    public bool ZombieCible = true;

    void Update ()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name == "HeadCollider")
            {
                HeadView = true;
            }
            else
            {
                HeadView = false;
            }
        
        }
        else 
        {
            HeadView = false;
        }
    }
}
