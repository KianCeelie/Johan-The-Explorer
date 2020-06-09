using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public GameObject OptionsPanel;
    public GameObject Neusaap;

    public void LoadScene(string Level_1)
    {
        SceneManager.LoadScene(Level_1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Startscherm");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(true);
    }

    public void CloseOptionsPanel()
    {
        OptionsPanel.gameObject.SetActive(false);
    }

    public void LoadNeusaap()
    {
        Neusaap.gameObject.SetActive(true);
    }

    public void CloseNeusaap()
    {
        Neusaap.gameObject.SetActive(false);
    }

}
