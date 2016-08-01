using UnityEngine;
using System.Collections;

/**
 * Acquires acceleration sensor data from the mobile device and uses it to
 * rotate the car and speed up or slow down according to tilt magnitude.
 */
public class SensorTurnPlayer : MonoBehaviour
{
    private GameObject player;

    void Start ()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void Update ()
    {
        // get acceleration data from tilting the device on the x and y axes
        Vector3 direction = Vector3.zero;
        direction.x = Input.acceleration.x;
        direction.y = Input.acceleration.y;
        //Debug.Log(direction);
        //Debug.Log(player.GetComponent<Rigidbody2D>().velocity);

        // define a threshold, so that sensor interference is minimal
        if ((Mathf.Abs(direction.x) > 0.2) || (Mathf.Abs(direction.y) > 0.2))
        {
            /*
             calculate the angle between the x axis and a 2D vector starting at zero
             and terminating at (direction.y, direction.x)
             this is basically the rotation compared to the x axis converted to degrees

             because the players car starts off pointing along the y axis, we have to subtract
             90 degrees from it
            */
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // clamp acceleration vector to the unit sphere
            if (direction.sqrMagnitude > 1)
            {
                direction.Normalize();
            }

            /*
             with these few lines of code we use the tilt of the mobile device to
             go faster or slower
             
             currentDirectionTilt stores the magnitude of the current direction vector
             which is normalized, thus between 0.0 and 1.0 -> meaning that when we tilt
             the device significantly, the length of the vector is larger, thus we move
             faster, if it is smaller, we go slower
             
             currentDirectionTilt is used in ButtonGas when we add the constant power
             player attribute to the force applied to the player car
            */
            Vector2 currentDirection = new Vector2(direction.x, direction.y);
            //Debug.Log(currentDirection.magnitude);
            float dirTilt = currentDirection.magnitude + 0.2f;
            if (dirTilt <= 1.0f)
            {
                PlayerCarAttributes.currentDirectionTilt = dirTilt;
            }
            else
            {
                PlayerCarAttributes.currentDirectionTilt = 1.0f;
            }

            // version 1
            //transform.rotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);

            // version 2
            if ((Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.x) >= 0.1f) ||
                (Mathf.Abs(player.GetComponent<Rigidbody2D>().velocity.y) >= 0.1f))
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation,
                (Quaternion.AngleAxis((angle - 90), Vector3.forward)),
                PlayerCarAttributes.turnpower);
            }

            // version 3
            // another version, kinda derpy imo
            /*transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    Quaternion.AngleAxis((angle - 90), Vector3.forward),
                    Time.deltaTime * GetComponent<PlayerCarAttributes>().turnpower
            );*/
        }
    }
}
