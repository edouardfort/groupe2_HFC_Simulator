using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Argent : MonoBehaviour
{
    public TextMeshProUGUI argentText;
    public int argent = 0;
    void Start(){
        updateArgent();
    }
    void gagnerArgent()
    {
        argent = argent + 50;
        updateArgent();
    }

    void updateArgent(){
        argentText.text = string.Format("{0}$", argent);
    }
    void Update(){
        gagnerArgent();
    }
}
