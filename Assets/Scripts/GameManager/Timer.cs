using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTime;
    public string currentTime;
    public Rect timerRect;
    public bool finished = false;
    public int raceType = 0;
    private int lapCount = 4;

    void Start()
    {
        CarCheckpoints.currentLap = 0;
        CarCheckpoints.currentCheckpoint = 0;
        //Debug.Log("Start called");
    }

    // Update is called once per frame
    void Update()
    {
        if (CarCheckpoints.currentLap == lapCount && CarCheckpoints.currentCheckpoint == 1)
        {
            //vége
            //GUI.Label(new Rect(10,10,100,100), currentTime);
            finished = true;

            GameObject[] controls = GameObject.FindGameObjectsWithTag("Controls");
            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].SetActive(false);
            }
            GameObject.Find("Button_Menu").SetActive(false);
        }
        else if (CarCheckpoints.currentLap >= 1 && CarCheckpoints.currentLap < lapCount && finished == false)
        {
            startTime += Time.deltaTime;
        }
        currentTime = string.Format("{0:0.0}", startTime);
    }



    void OnGUI()
    {
        GUIStyle style = new GUIStyle("box");
        GUIStyle mainMenuButtonStyle = new GUIStyle("button");
        GUIStyle resultBoxStyle = new GUIStyle("box");
        style.fontSize = Screen.width / 20;
        resultBoxStyle.fontSize = Screen.width / 20;
        mainMenuButtonStyle.fontSize = Screen.width / 20;
        style.normal.textColor = Color.cyan;
        resultBoxStyle.normal.textColor = Color.cyan;
        mainMenuButtonStyle.normal.textColor = Color.cyan;
        GUI.Box(new Rect(0, 0, style.fontSize * 3, style.fontSize * 1.5f), currentTime, style);
        if (finished == true)
        {
            SaveFastestTime();
            CarCheckpoints.currentLap = 0;
            CarCheckpoints.currentCheckpoint = 0;
            GUI.Box(new Rect(Screen.width / 3 - (Screen.width / 20), Screen.height / 3 - (Screen.height / 8),
                Screen.height / 2, Screen.height / 2), "Finished \n Your time is: \n" + currentTime, resultBoxStyle);
            if (GUI.Button(new Rect(Screen.width / 2 - mainMenuButtonStyle.fontSize * 3.6f,
                Screen.width / 2 - mainMenuButtonStyle.fontSize * 2, style.fontSize * 6, style.fontSize * 2),
                "Main Menu", mainMenuButtonStyle)) //button_color FF910DFF
            {
                SceneManager.LoadScene("Menu");
            }
            if (raceType == 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - style.fontSize * 1.5f, 0, style.fontSize * 3,
                    style.fontSize * 1.5f), lapCount.ToString() + "/" + lapCount.ToString(), style);
            }
        }
        else
        {
            if (raceType == 0)
            {
                GUI.Box(new Rect(Screen.width / 2 - style.fontSize * 1.5f, 0, style.fontSize * 3, style.fontSize * 1.5f),
                    CarCheckpoints.currentLap.ToString() + "/" + lapCount.ToString(), style);
            }
        }
    }
    /* 
      Save high score (fastest time) at the end of the race
      Only do so when the current high score is beaten (presistency)
     */
    void SaveFastestTime()
    {
        float time = float.Parse(currentTime, System.Globalization.CultureInfo.InvariantCulture);
        /*
          The first part of the conditional statement is for defining an upper bound for
          displaying the number of characters in the Options menu -> Best Time pane
          The value is 8, since the length of the displaying textbox is 160 holding 18 sized
          fonts (160 / 18 =~ 8.889)
          When modifying textbox size or changing the precision of the measured time,
          this value should be recalculated
         */
        if ((currentTime.Length <= 8) && (time >= 0.0f))
        {
            // Not the most elegant way to implement this, but fuck it

            // We need to know, what map we're on, to save to the appropriate PlayerPref
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Build1"))
            {
                if (!PlayerPrefs.HasKey("Time1"))
                {
                    PlayerPrefs.SetString("Time1", currentTime);
                }
                // There already is a high score to beat
                else
                {
                    float timeToBeat = float.Parse(PlayerPrefs.GetString("Time1"),
                                                    System.Globalization.CultureInfo.InvariantCulture);
                    if (time < timeToBeat)
                    {
                        PlayerPrefs.SetString("Time1", currentTime);
                    }
                }
            }
            else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Build2"))
            {
                if (!PlayerPrefs.HasKey("Time2"))
                {
                    PlayerPrefs.SetString("Time2", currentTime);
                }
                // There already is a high score to beat
                else
                {
                    float timeToBeat = float.Parse(PlayerPrefs.GetString("Time2"),
                                                    System.Globalization.CultureInfo.InvariantCulture);
                    if (time < timeToBeat)
                    {
                        PlayerPrefs.SetString("Time2", currentTime);
                    }
                }
            }
        }
    }
}
