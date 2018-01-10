using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LinkCollisions : MonoBehaviour {

    public UnityEvent collisionWithBoundary, collisionWithSelf;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Boundary"))
        {
            collisionWithBoundary.Invoke();
        }
    }
}
