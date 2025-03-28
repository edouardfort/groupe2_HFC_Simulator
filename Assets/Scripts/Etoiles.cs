using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StarSystem : MonoBehaviour
{
    public static StarSystem instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public GameObject[] starObjects;
    public Sprite activeStarSprite;
    public Sprite inactiveStarSprite;
    public int totalStars = 5;

    void Start()
    {
        UpdateStarDisplay();
    }

    public void LoseStar()
    {
        if (totalStars > 0)
        {
            totalStars--;
            UpdateStarDisplay();
        }
    }
    public void GainStar()
    {
        if (totalStars < 5)
        {
            totalStars++;
            UpdateStarDisplay();
        }
    }
    public void ResetStars()
    {
        totalStars = 5;
        UpdateStarDisplay();
    }

    private void UpdateStarDisplay()
    {
        for (int i = 0; i < starObjects.Length; i++)
        {
            Image starImage = starObjects[i].GetComponent<Image>();

            if (i < totalStars)
            {
                starImage.sprite = activeStarSprite;
            }
            else
            {
                starImage.sprite = inactiveStarSprite;
            }
            if (totalStars == 0)
            {
                SceneManager.LoadScene("GameOver");
                Cursor.lockState = CursorLockMode.None; 
                Cursor.visible = true; 
            }
        }
    }
}