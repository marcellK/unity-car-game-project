using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Display text on demand on GUI
 * Has to be attached to a valid GUI Text gameobject that is not the same
 * as the ones given as parameters (map1Text & map2Text)
 */
public class DisplayBestTime : MonoBehaviour
{
    public Text map1Text;
    public Text map2Text;

    void OnEnable()
    {
        if (PlayerPrefs.HasKey("Time1"))
        {
            map1Text.text = "Map1:  " + PlayerPrefs.GetString("Time1");
        }
        else
        {
            map1Text.text = "No time available";
        }
        
        if (PlayerPrefs.HasKey("Time2"))
        {
            map2Text.text = "Map2:  " + PlayerPrefs.GetString("Time2");
        }
        else
        {
            map2Text.text = "No time available";
        }
        
    }
}
