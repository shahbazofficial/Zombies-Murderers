using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ApprocheZombie : MonoBehaviour {

    CharacterController charCtrl;

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }
    void Update ()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position + charCtrl.center;
        Physics.SphereCast(p1, charCtrl.height / 2,transform.forward, out hit, Mathf.Infinity);
        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<AudioSource>() != null)
            {
                hit.transform.GetComponent<AudioSource>().volume += Time.deltaTime * 8;
            }
        }
    }
}
