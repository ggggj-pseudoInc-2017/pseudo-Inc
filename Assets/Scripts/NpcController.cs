using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour {

    public Transform[] points;

    int destPoint = 0;
    NavMeshAgent ai;

	void Start ()
    {
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

        destPoint = (destPoint + 1) % points.Length;
    }
}
