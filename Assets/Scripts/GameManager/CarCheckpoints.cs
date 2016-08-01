using UnityEngine;
using System.Collections;

public class CarCheckpoints : MonoBehaviour {

    public Checkpoints[] checkpointArray;
    public static int currentCheckpoint = 0;
    public static int currentLap = 0;
    public static Vector2 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
