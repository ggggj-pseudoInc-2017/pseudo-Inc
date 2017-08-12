using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour {

    public Transform player;
    public Transform offset;

    float xPos;
    float yPos;
    float zPos;

    void Start()
    {
        yPos = offset.position.y;
    }

	void Update ()
    {
        xPos = player.position.x;
        zPos = player.position.z;
        offset.position = new Vector3(Mathf.Clamp(xPos, -76.4f, 76.4f), yPos, Mathf.Clamp(zPos, -76.4f, 76.4f));
	}
}
