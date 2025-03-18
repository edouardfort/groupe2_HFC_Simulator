using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Argent : MonoBehaviour
{
    public static Argent instance = null;
    private ComportementClient comportementClient;
    public TextMeshProUGUI argentText;
    public int argent = 0;
    void Awake(){
		if(instance == null){
			instance = this;
		}
	}
    void Start(){
        updateArgent();
    }
    public void gagnerArgent(int money)
    {
        comportementClient = ComportementClient.instance;
        argent = argent + money;
        comportementClient.AvancerFile();
        updateArgent();
    }

    void updateArgent(){
        argentText.text = string.Format("{0}$", argent);

    }
    void Update(){
      
    }
}
