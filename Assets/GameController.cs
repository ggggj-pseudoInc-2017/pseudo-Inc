using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pseudoinc;

public class GameController : MonoBehaviour {

    public List<NpcController> npcs;
    public GameObject[] churches;

    public TimeFlow clock;

    int currentLevel = 0;

	void Start ()
    {
        if(FindObjectOfType<TimeFlow>() == null)
        {
            TimeFlow newClock = Instantiate(clock);
            DontDestroyOnLoad(newClock.gameObject);
        }
        npcs = new List<NpcController>();
        for(int i = 0; i < 5; i++)
        {
            if(i == Church.Get_level())
            {
                churches[i].SetActive(true);
            }
            else
            {
                churches[i].SetActive(false);
            }
        }
	}
	
	void Update ()
    {
        if(Input.GetKeyDown("up"))
        {
            Church.LevelUp();
        }
        if(currentLevel < Church.Get_level())
        {
            churches[currentLevel].SetActive(false);
            churches[Church.Get_level()].SetActive(true);
            currentLevel = Church.Get_level();
        }
	}

    public void EraseSelf(NpcController npc)
    {
        npcs.Remove(npc);
    }
}
