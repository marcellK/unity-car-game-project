using UnityEngine;
using System.Collections;

public class OnTrack : MonoBehaviour
{
    public bool out_of_track = false;

    private float delayCount = 0.0f;

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Pályán kívül");
        out_of_track = true;
        //Handheld.Vibrate();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Pályán belül");
        out_of_track = false;
    }
    
    /*
     When the player is not on the track, vibrate in given time intervals
    */
    void FixedUpdate()
    {
        if (out_of_track == true)
        {
            PlayerCarAttributes.friction = 7;
            delayCount -= Time.deltaTime;
            if (delayCount < 0.0f)
            {
                delayCount = 1.2f;
                Handheld.Vibrate();
                //Debug.Log(Time.deltaTime);
            }
        }
        else
        {
            PlayerCarAttributes.friction = 3;
        }
    }
}
