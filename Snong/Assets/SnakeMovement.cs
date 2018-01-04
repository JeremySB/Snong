using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnakeMovement : MonoBehaviour {

    public GameObject linkPrefab;
    public int initialNumberOfLinks = 4;
    public float updateFrequency = 0.5f;
    public float speed = 2f;

    int targetNumberOfLinks;
    Vector3 direction = Vector3.up;
    float updateTimer = 0;
    List<GameObject> links = new List<GameObject>();

	// Use this for initialization
	void Start () {
        targetNumberOfLinks = initialNumberOfLinks;
	}

    // Update is called once per frame
    void Update () {
        updateTimer += Time.deltaTime;
        if(updateTimer > updateFrequency)
        {
            updateTimer = 0;
            if(targetNumberOfLinks > links.Count)
            {
                var spawn = links.LastOrDefault()?.transform ?? transform;
                links.Add(Instantiate(linkPrefab, spawn.position, spawn.rotation, transform));
            }

            var first = links.First().transform;
            first.Translate(direction * speed);

            for (int i = links.Count-1; i > 0; i--)
            {
                links[i].transform.SetPositionAndRotation(links[i-1].transform.position, links[i - 1].transform.rotation);
            }
        }
	}
}
