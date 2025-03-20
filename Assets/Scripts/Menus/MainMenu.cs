using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private GameObject panel_options;
	[SerializeField] private GameObject panel_credits;
	[SerializeField] private GameObject panel_droits;

	void Start()
	{
		UnshowOptions();
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("TEST");
	}

	public void ShowOptions()
	{
		panel_options.SetActive(true);
	}

	public void UnshowOptions()
	{
		panel_options.SetActive(false);
	}

	public void ShowDroits()
	{
		panel_droits.SetActive(true);
	}
	public void UnshowDroits()
	{
		panel_droits.SetActive(false);
	}

	public void ShowCredits()
	{
		panel_credits.SetActive(true);
	}

	public void UnshowCredits()
	{
		panel_credits.SetActive(false);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
