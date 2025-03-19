using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionClient : MonoBehaviour
{
    public Sprite[] clientSprites;
    public Transform parentObject;
    public MonoBehaviour script;

    public float temps;
    void Start()
    {

    }
    void Update()
    {
        temps=temps+Time.deltaTime;
        if (temps >= 2)
        {
            SpawnClient();
            temps=0f;
        }

    }
    void SpawnClient()
    {
        GameObject Client = new GameObject("Client");
        Client.tag = "Client";
        Client.transform.SetParent(parentObject);
        SpriteRenderer spriterenderer = Client.AddComponent<SpriteRenderer>();
        spriterenderer.sprite = clientSprites[Random.Range(0, clientSprites.Length)];

        //Association des scripts au client
        string ScriptName = "ComportementClient";
        System.Type MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
        Client.AddComponent(MyScriptType);
        ScriptName = "LookAt";
        MyScriptType = System.Type.GetType(ScriptName + ",Assembly-CSharp");
        Client.AddComponent(MyScriptType);

    }
}
