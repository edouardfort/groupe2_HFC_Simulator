using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject panel_pause;
    public static bool pause = false;

    void Start()
    {
        panel_pause.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            panel_pause.SetActive(pause);

            if(pause)
            {
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None; 
                Cursor.visible = true; 
            }
            else
            {
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked; 
                Cursor.visible = false;
            }
        }
    }
}
