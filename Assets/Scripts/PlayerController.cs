using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

    NavMeshAgent ai;

    public GameObject player;

    bool isMovingToNpc;
    GameObject targetNPC;

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

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if(hit.transform.tag == "npc" && (hit.transform.position - this.transform.position).magnitude > 2f)
                {
                    targetNPC = hit.transform.gameObject;
                    targetNPC.GetComponent<NpcController>().MoreClicked();
                    isMovingToNpc = true;
                }
                else if(hit.transform.tag == "npc" && (hit.transform.position - this.transform.position).magnitude <= 2f)
                {
                    isMovingToNpc = false;
                    targetNPC.GetComponent<NpcController>().MoreClicked();
                }
                else
                {
                    ai.destination = hit.point;
                    isMovingToNpc = false;
                }
            }
        }
        if(isMovingToNpc && (targetNPC.transform.position - transform.position).magnitude > 5f)
        {
            ai.destination = targetNPC.transform.position;
            targetNPC.GetComponent<NpcController>().talkingWithPlayer = false;
        }
        else if (isMovingToNpc && (targetNPC.transform.position - transform.position).magnitude <= 5f)
        {
            ai.destination = transform.position;
            isMovingToNpc = false;
            targetNPC.GetComponent<NpcController>().talkingWithPlayer = true;
            targetNPC.GetComponent<NpcController>().player = transform;
            targetNPC.transform.LookAt(this.transform);
            transform.LookAt(targetNPC.transform);
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
