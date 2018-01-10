using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;
    public float interpAmount = 0.2f;

	// Use this for initialization
	void Start () {
        if (target == null) target = transform;
	}
	
	// Update is called once per frame
	void Update () {
        var x = Mathf.Lerp(transform.position.x, target.position.x, interpAmount);
        var y = Mathf.Lerp(transform.position.y, target.position.y, interpAmount);

        transform.position = new Vector3(x, y, transform.position.z);
    }

    public void SetTarget(GameObject target)
    {
        this.target = target.transform;
    }
}
