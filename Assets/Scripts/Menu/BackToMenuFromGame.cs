using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * Exit current game map back to the menu. Needs to be attached to the Canvas object.
 */
public class BackToMenuFromGame : MonoBehaviour
{
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
