using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMachine : MonoBehaviour
{
    public Material redMaterial;   // Matériau rouge
    public Material grayMaterial;  // Matériau gris
    public Material greenMaterial; // Matériau vert

    public TimerFriteuse timerFriteuse;  // Référence au script TimerFriteuse

    void Update()
    {
        if (timerFriteuse.nivmachine==3){
            GetComponent<Renderer>().material = grayMaterial;

        }
        else if (Argent.instance.argent >= 5 * (timerFriteuse.nivmachine + 1))
        {
            GetComponent<Renderer>().material = greenMaterial;

        }
        else if (Argent.instance.argent < 5 * (timerFriteuse.nivmachine + 1))
        {
            GetComponent<Renderer>().material = redMaterial;

        }
        
    }

    void OnMouseDown() // Détection du clic sur l'objet
    {
        if (Argent.instance.argent >= 5 && timerFriteuse.nivmachine == 0)  // On récup la variable argent et on vérifie si elle a la tune nécessaire
        {
            Argent.instance.gagnerArgent(-5); // Retire 5 d'argent
            timerFriteuse.AmeliorerMachine();  // Améliore la machine
        }
        else if (Argent.instance.argent >= 10 && timerFriteuse.nivmachine == 1)
        {
            Argent.instance.gagnerArgent(-10); // Retire 5 d'argent
            timerFriteuse.AmeliorerMachine();
        }
        else if (Argent.instance.argent >= 15 && timerFriteuse.nivmachine == 2)
        {
            Argent.instance.gagnerArgent(-15); // Retire 5 d'argent
            timerFriteuse.AmeliorerMachine();
        }
        else
        {
            Debug.Log("Pas assez d'argent ou niveau max atteint !");
        }
    }
}
