using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class NpcController : MonoBehaviour {

    public Transform[] points;
    public GameObject pointGroup;
    public Transform player;

    public bool talkingWithPlayer = false;

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
        if(player != null && (player.position - transform.position).magnitude <= 5f)
        {
            talkingWithPlayer = true;
        }
        else
        {
            talkingWithPlayer = false;
        }
		if(!ai.pathPending && ai.remainingDistance < 1f && !talkingWithPlayer)
        {
            GoNextPoint();
        }
        else if(talkingWithPlayer)
        {
            ai.destination = transform.position;
        }

        if(player != null && !talkingWithPlayer)
        {
            Debug.Log("destroy");
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
