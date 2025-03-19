using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClicFriteuse : MonoBehaviour
{
    public TimerFriteuse timerFriteuse;  // Référence au script TimerFriteuse

    void OnMouseDown() // Détection du clic sur l'objet
    {
        // Vérifie si le GameObject nourriture est désactivé
        if (!timerFriteuse.nourriture.activeSelf)  // On accède à la variable nourriture du script TimerFriteuse
        {
            timerFriteuse.ActiverFriteuse();  // Si le burger est désactivé, on active le timer
        }
    }
}