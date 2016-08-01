using UnityEngine;
using System.Collections;

/**
 * Move backwards button, accepts messages from SensorMovePlayer
 * listener methods: OnTouchDown, OnTouchStay
 */
public class ButtonReverse : MonoBehaviour
{
    public GameObject playerCar;
    float angle = 0.0f;
    Vector3 axis = Vector3.zero;

    void Update()
    {
        playerCar.transform.rotation.ToAngleAxis(out angle, out axis);
        //Debug.Log(angle + " - " + axis);
    }

    void OnTouchDown()
    {
        /*
         because the toAngleAxis function returns only positive angles
         we have to find a way to differentiate the rotation of the left side
         from the right side rotation - thus we use the axis.z component, which
         is 1.0, when we turn left (the axis acts as a cross product perhaps? not sure)
         -1.0, when we turn right
        */
        if (axis.z >= 0)
        {
            // if we turn left, just add 90
            angle += 90;
        }
        else
        {
            // else we take the negative of the angle and add 90 to that
            angle = -angle + 90;
        }
        /*
         calculate the direction of the car by using basic trigonometry
         from the angle perviously calculated in SensorTurnPlayer and modified here
         we can get where the car's facing (it's a vector) 
         then apply a force in the direction of this vector to move the car
		 (details on currentDirectionTilt can be found in the SensorTurnPlayer script)
        */
        Vector3 carFront = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
        playerCar.GetComponent<Rigidbody2D>().AddForce(
            -(carFront.normalized) * (PlayerCarAttributes.power * PlayerCarAttributes.currentDirectionTilt / 2));
        playerCar.GetComponent<Rigidbody2D>().drag = PlayerCarAttributes.friction;
    }
    void OnTouchStay()
    {
        //Vector2 curspeed = playerCar.GetComponent<PlayerCarAttributes>().curspeed;
        Vector2 curspeed = new Vector2( playerCar.GetComponent<Rigidbody2D>().velocity.x,
                                        playerCar.GetComponent<Rigidbody2D>().velocity.y);

        if (curspeed.magnitude > PlayerCarAttributes.maxspeed)
        {
            playerCar.GetComponent<Rigidbody2D>().velocity =
                Vector3.ClampMagnitude(playerCar.GetComponent<Rigidbody2D>().velocity, PlayerCarAttributes.maxspeed);
            //curspeed = curspeed.normalized;
            //curspeed *= PlayerCarAttributes.maxspeed;
        }
        /*
         because the toAngleAxis function returns only positive angles
         we have to find a way to differentiate the rotation of the left side
         from the right side rotation - thus we use the axis.z component, which
         is 1.0, when we turn left (the axis acts as a cross product perhaps? not sure)
         -1.0, when we turn right
        */
        if (axis.z >= 0)
        {
            // if we turn left, just add 90
            angle += 90;
        }
        else
        {
            // else we take the negative of the angle and add 90 to that
            angle = -angle + 90;
        }
        /*
         calculate the direction of the car by using basic trigonometry
         from the angle perviously calculated in SensorTurnPlayer and modified here
         we can get where the car's facing (it's a vector) 
         then apply a force in the direction of this vector to move the car
		 (details on currentDirectionTilt can be found in the SensorTurnPlayer script)
        */
        Vector3 carFront = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle), 0);
        playerCar.GetComponent<Rigidbody2D>().AddForce(
            -(carFront.normalized) * (PlayerCarAttributes.power * PlayerCarAttributes.currentDirectionTilt / 2));
        playerCar.GetComponent<Rigidbody2D>().drag = PlayerCarAttributes.friction;
    }
}
