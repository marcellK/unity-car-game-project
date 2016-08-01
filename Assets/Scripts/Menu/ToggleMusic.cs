using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Script ensures that the toggle in the Options panel is checked or unchecked
 * correctly.
 */
public class ToggleMusic : MonoBehaviour
{
    public Toggle toggle;

    void Update()
    {
        if(PlayerPrefs.GetInt("ToggleMusic") == 0)
        {
            toggle.isOn = false;
        }
        else
        {
            toggle.isOn = true;
        }
    }

	public void ToggleMusicOnOff ()
    {
        if(toggle.isOn == true)
        {
            MenuMusicPersist.MenuAudio = 1;
            FindObjectOfType<MenuMusicPersist>().GetComponent<AudioSource>().Play();
        }
        else
        {
            MenuMusicPersist.MenuAudio = 0;
            FindObjectOfType<MenuMusicPersist>().GetComponent<AudioSource>().Pause();
        }
        /*
         save settings to device
         on desktop (Windows) this will be stored in HKEY_CURRENT_USER under Software
         on Android this is stored under /data/data/appname/shared_prefs/appname.xml, where
         appname is the full package identifier
        */
        PlayerPrefs.SetInt("ToggleMusic", MenuMusicPersist.MenuAudio);
    }
}
