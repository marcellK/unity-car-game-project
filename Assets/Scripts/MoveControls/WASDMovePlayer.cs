using UnityEngine;
using System.Collections;

/**
 * Simply for testing and debugging
 */
public class WASDMovePlayer : MonoBehaviour
{
    void FixedUpdate()
    {
        /*transform.rotation.ToAngleAxis(out angle, out axis);
        Debug.Log(angle + " - " + axis);*/

        GetComponent<PlayerCarAttributes>().curspeed = new Vector2(
            GetComponent<Rigidbody2D>().velocity.x,
            GetComponent<Rigidbody2D>().velocity.y);

        if (GetComponent<PlayerCarAttributes>().curspeed.magnitude > PlayerCarAttributes.maxspeed)
        {
            GetComponent<PlayerCarAttributes>().curspeed = GetComponent<PlayerCarAttributes>().curspeed.normalized;
            GetComponent<PlayerCarAttributes>().curspeed *= PlayerCarAttributes.maxspeed;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * PlayerCarAttributes.power);
            GetComponent<Rigidbody2D>().drag = PlayerCarAttributes.friction;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(-(transform.up) * (PlayerCarAttributes.power / 2));
            GetComponent<Rigidbody2D>().drag = PlayerCarAttributes.friction;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * PlayerCarAttributes.turnpower);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * - PlayerCarAttributes.turnpower);
        }

        noGas();

    }

    void noGas()
    {
        bool gas;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            gas = true;
        }
        else
        {
            gas = false;
        }

        if (!gas)
        {
            GetComponent<Rigidbody2D>().drag = PlayerCarAttributes.friction * 2;
        }
    }
}
