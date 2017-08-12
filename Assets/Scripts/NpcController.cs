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

    NonFollower nonFollower;

    public bool talkingWithPlayer = false;

    int destPoint = 0;
    int numOfClicks = 0;
    NavMeshAgent ai;

    public SpeechBubble speechBubble;
    SpeechBubble newBubble;

	void Start ()
    {
        nonFollower = new NonFollower(Random.Range(Church.Get_favor() - 10, Church.Get_favor() + 11), Random.Range(1, 11));
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
            StartCoroutine(DestoryPerson());
        }
	}

    public void MoreClicked()
    {
        if (talkingWithPlayer && numOfClicks < 5)
        {
            if (newBubble == null)
            {
                nonFollower.Add_favor(4);
                newBubble = Instantiate(speechBubble);
                newBubble.transform.position = transform.position + new Vector3(0, 20, 0);
                newBubble.gameObject.SetActive(false);

                newBubble.gameObject.SetActive(true);
                newBubble.WriteText(nonFollower.Get_favor());
                numOfClicks++;
            }
            else
            {
                nonFollower.Add_favor(4);
                Destroy(newBubble.gameObject);
                newBubble = Instantiate(speechBubble);
                newBubble.transform.position = transform.position + new Vector3(0, 20, 0);
                newBubble.gameObject.SetActive(false);

                newBubble.gameObject.SetActive(true);
                newBubble.WriteText(nonFollower.Get_favor());
                numOfClicks++;
            }
            if(nonFollower.Get_favor() >= 70)
            {
                BecomeFollower(nonFollower);
                return;
            }
            if(numOfClicks == 5)
            {
                RemainNonFollower();
                return;
            }
        }
    }

    void BecomeFollower(NonFollower nonfollower)
    {
        Follower Follower = new Follower(nonfollower.Get_income(), Random.Range(40, 81));
        Debug.Log("offer : " + Follower.Get_offer() + "   faith : " + Follower.Get_faith());
        Church.Add_follower(Follower);
        Debug.Log("followers : " + Church.Get_num_followers());
        StartCoroutine(DestoryPerson());
    }

    void RemainNonFollower()
    {
        StartCoroutine(DestoryPerson());
    }

    IEnumerator DestoryPerson()
    {
        yield return new WaitForSeconds(2);
        Destroy(newBubble.gameObject);
        Destroy(this.gameObject);
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
