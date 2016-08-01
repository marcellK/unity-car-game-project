using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * Selection actions in Options scene. Needs to be attached to the Canvas object.
 */
public class OptionsSelect : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject timePanel;
    public GameObject creditsPanel;

    public void ExitOptions()
    {
        if (optionsPanel.activeSelf)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void EnterTime()
    {
        if (optionsPanel.activeSelf)
        {
            timePanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void ExitTime()
    {
        timePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void EnterCredits()
    {
        if (optionsPanel.activeSelf)
        {
            creditsPanel.SetActive(true);
            optionsPanel.SetActive(false);
        }
    }

    public void ExitCredits()
    {
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
}
