using UnityEngine;

/**
 * Audio manager in Menu and Options scenes. We want this gameobject
 * to persist between these two scenes and have only one instance, thus
 * we use the Singleton pattern.
 * We use a thread-safe approach and lock the instantiation process.
 */
public sealed class MenuMusicPersist : MonoBehaviour
{
    private static MenuMusicPersist instance = null;
    private static readonly object padlock = new object();

    // 0 means audio is off, 1 or any other value means it's on
    public static int MenuAudio = 0;

    /*
     Through MenuMusicPersistInstance we can create a new MenuMusicPersist if we wanted.
     However, because we already have one in the main menu, we don't have to.
     Furthermore, we check whether an instance already exists (remember, we don't destroy
     this game object on scene load).
    */
    public static MenuMusicPersist MenuMusicPersistInstance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<MenuMusicPersist>();
                    DontDestroyOnLoad(instance.gameObject);
                }
                return instance;
            }
        }
    }

    /*
     Called only once for script instance after all objects have been initialized
     just before gamestart
    */
    void Awake()
    {
        if (PlayerPrefs.GetInt("ToggleMusic") != 0)
        {
            GetComponents<AudioSource>()[0].Play();
        }
        else
        {
            GetComponents<AudioSource>()[0].Pause();
        }

        if (MenuMusicPersistInstance == null)
        {
            // this object is the first one in the scene => make it Singleton
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // if a Singleton already exists and you find
            // another reference in scene, destroy it!
            if (this != MenuMusicPersistInstance)
                Destroy(gameObject);
        }
    }

    // Unfinished: switch music during racing
    void OnLevelWasLoaded(int level)
    {
        // maps are loaded
        /*if ((level == 0) || (level == 1))
        {
            //Debug.Log("map");
            if(PlayerPrefs.GetInt("ToggleMusic") != 0)
            {
                GetComponents<AudioSource>()[0].playOnAwake = false;
                GetComponents<AudioSource>()[1].playOnAwake = true;
            }
        }
        // menu & options are loaded
        else if((level == 2) || (level == 3))
        {
            if (PlayerPrefs.GetInt("ToggleMusic") != 0)
            {
                //Debug.Log("menu");
                GetComponents<AudioSource>()[0].playOnAwake = true;
                GetComponents<AudioSource>()[1].playOnAwake = false;
            }
        }*/
    }
}
