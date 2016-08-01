using UnityEngine;
using System.Collections;

/**
 * This script handles all device touch based message dispatches to any other script, that
 * implements any or all of these methods:
 *      OnTouchDown, OnTouchUp, OnTouchMove, OnTouchStay, OnTouchExit
 */
public class SensorMovePlayer : MonoBehaviour
{	
	void Update ()
    {
        // cycle through all available touch objects created when the device is touched with one or more fingers
        foreach (Touch touch in Input.touches)
        {
            // cast a ray from the touch position, this ray is broken by buttons with colliders on them
            // (as well as any other object that has some form of collider on it)
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), Vector2.zero);
            if (hit)
            {
                GameObject recipient = hit.transform.gameObject;
                // a simple tap
                if (touch.phase == TouchPhase.Began)
                {
                    recipient.SendMessage("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                // release
                if (touch.phase == TouchPhase.Ended)
                {
                    recipient.SendMessage("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                // touch and move finger
                if (touch.phase == TouchPhase.Moved)
                {
                    recipient.SendMessage("OnTouchMove", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                // touch and hold
                if (touch.phase == TouchPhase.Stationary)
                {
                    recipient.SendMessage("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver);
                }
                // happens when you put your face on the device
                if (touch.phase == TouchPhase.Canceled)
                {
                    recipient.SendMessage("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
    }
}
