using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicFriteuse : MonoBehaviour
{
    
    public TimerFriteuse timerFriteuse;

    void OnMouseDown() // Détection du clic sur l'objet
    {
        timerFriteuse.ActiverFriteuse();
        Debug.Log("Test");
    }

    
}

