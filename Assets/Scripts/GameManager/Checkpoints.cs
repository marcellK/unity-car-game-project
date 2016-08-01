using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {
    static Transform playerTransform;
	// Use this for initialization
	void Start () {
        playerTransform = GameObject.Find("Player").transform;
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (transform == playerTransform.GetComponent<CarCheckpoints>().checkpointArray[CarCheckpoints.currentCheckpoint].transform)
        {
            if(CarCheckpoints.currentCheckpoint +1 < playerTransform.GetComponent<CarCheckpoints>().checkpointArray.Length)
            {
                if(CarCheckpoints.currentCheckpoint == 0)
                {
                    CarCheckpoints.currentLap++;
                }
                CarCheckpoints.currentCheckpoint++;
            }
            else
            {
                CarCheckpoints.currentCheckpoint = 0;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        //Debug.Log(CarCheckpoints.currentLap);

	}
}
