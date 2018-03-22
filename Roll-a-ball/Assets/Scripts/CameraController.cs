using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;
	// Use this for initialization
	void Start () {
        // find the difference between camera position and ball's position
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {//lateupdate is called after everything else has been run
        transform.position = player.transform.position + offset;
	}
}
