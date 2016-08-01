using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public GameObject mapPanel;
    public GameObject menuPanel;

    public void StartGame(string map)
    {
        if(mapPanel.activeSelf)
        {
            //SendMessage("ChangeMusic", SendMessageOptions.RequireReceiver);
            SceneManager.LoadScene(map);
        }
    }

    public void EnterOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void EnterMapPanel()
    {
        menuPanel.SetActive(false);
        mapPanel.SetActive(true);
    }

    public void ExitMapPanel()
    {
        mapPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
