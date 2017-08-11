using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    NavMeshAgent ai;

    void Start ()
    {
        ai = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        Move();
	}

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                ai.destination = hit.point;
            }
        }
    }
}
