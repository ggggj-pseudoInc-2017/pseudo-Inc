using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class NpcController : MonoBehaviour {

    public Transform[] points;
    public GameObject pointGroup;

    int destPoint = 0;
    NavMeshAgent ai;

	void Start ()
    {
        points = pointGroup.GetComponentsInChildren<Transform>();
        foreach(Transform transform in points)
        {
            transform.position = new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y, transform.position.z + Random.Range(-3, 3));
        }
        ai = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
		if(!ai.pathPending && ai.remainingDistance < 1f)
        {
            GoNextPoint();
        }
	}

    void GoNextPoint()
    {
        if(points.Length == 0)
        {
            return;
        }

        ai.destination = points[destPoint].position;

        destPoint = (Random.Range(0, points.Length)) % points.Length;
    }
}
