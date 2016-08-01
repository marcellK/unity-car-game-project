using UnityEngine;
using System.Collections;

/**
 * Script makes camera follow the player without rotating
 */
public class MoveCameraWithPlayer : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        // get the first object which is tagged as 'Player' - there can be only one of those
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

	void Update ()
    {
        // snap camera to player, without rotating it
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
