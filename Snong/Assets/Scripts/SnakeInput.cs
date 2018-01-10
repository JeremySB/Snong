using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeMovement))]
public class SnakeInput : MonoBehaviour {

    [SerializeField] float threshold = 0.01f;

    SnakeMovement movement;

	// Use this for initialization
	void Start () {
        movement = GetComponent<SnakeMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") > threshold)
        {
            movement.Direction = Vector3.right;
        }
        else if (Input.GetAxis("Horizontal") < -threshold)
        {
            movement.Direction = Vector3.left;
        }
        else if (Input.GetAxis("Vertical") > threshold)
        {
            movement.Direction = Vector3.up;
        }
        else if (Input.GetAxis("Vertical") < -threshold)
        {
            movement.Direction = Vector3.down;
        }
    }
}
