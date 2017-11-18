using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cible : MonoBehaviour
{

    public bool cible;

    public void Cibler(PointerEventData eventData)
    {
        cible = true;
    }
    public void StopCibler(PointerEventData eventData)
    {
        cible = false;
    }
}
