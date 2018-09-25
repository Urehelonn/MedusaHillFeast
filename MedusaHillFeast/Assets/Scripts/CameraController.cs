using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject followPlayer;
    private Vector3 targetPosition;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        targetPosition = new Vector3(followPlayer.transform.position.x, followPlayer.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed*Time.deltaTime);
    }
}
