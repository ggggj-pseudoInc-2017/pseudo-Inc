using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    NavMeshAgent ai;

    public GameObject player;

    bool isMovingToNpc;

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
                if(hit.transform.tag == "npc" && (hit.transform.position - this.transform.position).magnitude > 2f)
                {
                    ai.destination = hit.point;
                    isMovingToNpc = true;
                }
                else if(hit.transform.tag == "npc" && (hit.transform.position - this.transform.position).magnitude <= 2f)
                {
                    Debug.Log("npc");
                    isMovingToNpc = false;
                }
                else
                {
                    ai.destination = hit.point;
                    isMovingToNpc = false;
                }
            }
        }
        if (isMovingToNpc && (ai.destination - transform.position).magnitude <= 2f)
        {
            ai.destination = transform.position;
        }
        if(ai.velocity.magnitude > 0 )
        {
            player.GetComponent<Animator>().SetBool("isMoving", true);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("isMoving", false);
        }
    }
}
