using UnityEngine;
using System.Collections;

/**
 * Player car attributes, easy to modify and to get their value
 */
public class PlayerCarAttributes : MonoBehaviour
{
    // Car attributes the players car possesses
    // Used by the two buttons
    public static float power = 15;
    public static float maxspeed = 10;
    public static float friction = 3;
    public static float turnpower = 4;
    public Vector2 curspeed;
    public static float currentDirectionTilt;
}
