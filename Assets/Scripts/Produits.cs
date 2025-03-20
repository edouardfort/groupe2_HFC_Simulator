using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Produits : MonoBehaviour
{

    public static Produits instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public List<string> produits = new List<string> { "Burger", "Frites", "Tacos", "Cuisse", "Doritos", "Nuggets", "Pespi" };
    public List<float> prix = new List<float> { 7.50f, 3.5f, 7f, 7f, 3f, 7f, 2f };
    public List<Sprite> sprites = new List<Sprite>();

}
