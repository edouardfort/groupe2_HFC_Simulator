using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Argent : MonoBehaviour
{
    public static Argent instance = null;
    private ComportementClient comportementClient;
    public TextMeshProUGUI argentText;
    public TextMeshProUGUI argentgagneText;
    public float argent = 0f;

    bool etatargent = false;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        updateArgent();
    }
    public void gagnerArgent(float money)
    {
        comportementClient = ComportementClient.instance;
        argent = argent + money;
        AnimArgent(money);
        comportementClient.AvancerFile();
        updateArgent();
    }
    void AnimArgent(float money)
    {
        if (money > 0)
        {
            argentgagneText.color = new Color(0f, 1f, 0f);
            argentgagneText.text = string.Format("+{0}$", money);
        }
        else
        {
            argentgagneText.color = new Color(1f, 0f, 0f);
            argentgagneText.text = string.Format("{0}$", money);
        }
        etatargent = true;

    }

    void updateArgent()
    {
        argentText.text = string.Format("{0}$", argent);

    }
    float timer = 0f;
    void Update()
    {
        if (etatargent == true)
        {
            timer += Time.deltaTime;
            argentgagneText.gameObject.SetActive(true);
            // Disparition entre 0.4s et 0.5s
            if (timer >= 0.4f && timer <= 0.5f)
            {
                float alpha = Mathf.Lerp(1f, 0f, (timer - 0.4f) / 0.1f); // Transition fluide
                argentgagneText.color = new Color(argentgagneText.color.r, argentgagneText.color.g, argentgagneText.color.b, alpha);
            }
            if (timer > 0.5f)
            {
                etatargent = false;
                timer = 0f;
            }
        }
        else
        {
            argentgagneText.gameObject.SetActive(false);
        }
    }
}
