using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

    public bool moveY = false;
    public bool moveZ = false;
    public float smooth = .1f;
    public float maxDist = 0f;

    private GameObject player;

    private Vector3 lastTarget;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
        lastTarget = player.transform.position;
	}

	void LateUpdate () {
        Vector3 currPos = player.transform.position;
        float distToLast = Vector3.Distance(lastTarget, currPos);
        if (maxDist > 0 && distToLast < maxDist)
        {
            return;
        }
        currPos = Vector3.Lerp(lastTarget, currPos, distToLast - maxDist);
        lastTarget = Vector3.Lerp(lastTarget, currPos, smooth);
        float newY = (moveY ? lastTarget : transform.position).y;
        float newZ = (moveZ ? lastTarget : transform.position).z;
        transform.position = new Vector3(transform.position.x, newY, newZ);
        transform.LookAt(lastTarget);
    }
}
