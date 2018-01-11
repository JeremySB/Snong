using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SnakeMovement : MonoBehaviour {

    public UnityEvents.GameObjectEvent firstLinkSpawned, linkSpawned;

    public GameObject linkPrefab;
    public int initialNumberOfLinks = 4;
    public float updateFrequency = 0.5f;
    public float linkDistance = 1f;

    int targetNumberOfLinks;
    float updateTimer = 0;
    List<GameObject> links = new List<GameObject>();
    Vector3? lastUsedDirection;

    Vector3 _direction = Vector3.up;
    public Vector3 Direction {
        get { return _direction; }
        set {
            if (!lastUsedDirection.HasValue || !Mathf.Approximately(Mathf.Abs(Vector3.Angle(lastUsedDirection.Value, value)), 180))
            {
                _direction = value;
            }
        }
    }

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
                Transform spawn = links.LastOrDefault()?.transform ?? transform;
                GameObject newLink = Instantiate(linkPrefab, spawn.position, spawn.rotation, transform);
                links.Add(newLink);

                if (links.Count == 1) firstLinkSpawned.Invoke(newLink);

                linkSpawned.Invoke(newLink);
            }

            for (int i = links.Count-1; i > 0; i--)
            {
                links[i].transform.SetPositionAndRotation(links[i-1].transform.position, links[i - 1].transform.rotation);
            }

            var first = links.First().transform;
            first.Translate(Direction * linkDistance);
            lastUsedDirection = Direction;
        }
	}
}
