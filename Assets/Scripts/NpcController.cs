using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using pseudoinc;

public class NpcController : MonoBehaviour {

    public Transform[] points;
    public GameObject pointGroup;
    public Transform player;

    NonFollower nonFollower = new NonFollower(Random.Range(Church.Get_favor()-10,Church.Get_favor()+11), Random.Range(1,11));

    public bool talkingWithPlayer = false;

    int destPoint = 0;
    NavMeshAgent ai;

    public SpeechBubble speechBubble;
    SpeechBubble newBubble;

	void Start ()
    {
        points = pointGroup.GetComponentsInChildren<Transform>();
        transform.position = points[Random.Range(0, points.Length)].position;
        transform.position = new Vector3(transform.position.x, 2f, transform.position.z);
        ai = GetComponent<NavMeshAgent>();
        ai.enabled = true;
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
            Destroy(gameObject);
        }
	}

    public void MoreClicked()
    {
        if (talkingWithPlayer)
        {
            if (newBubble == null)
            {
                newBubble = Instantiate(speechBubble);
                newBubble.transform.position = transform.position + new Vector3(0, 20, 0);
                newBubble.gameObject.SetActive(false);

                newBubble.gameObject.SetActive(true);
            }
            else
            {
                Destroy(newBubble.gameObject);
                newBubble = Instantiate(speechBubble);
                newBubble.transform.position = transform.position + new Vector3(0, 20, 0);
                newBubble.gameObject.SetActive(false);

                newBubble.gameObject.SetActive(true);
            }
            newBubble.Talk();
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

    private void OnDestroy()
    {
        Destroy(newBubble);
    }
}
