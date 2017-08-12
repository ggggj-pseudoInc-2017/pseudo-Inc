using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public List<NpcController> npcs;

	void Start ()
    {
        npcs = new List<NpcController>();
	}
	
	void Update ()
    {
		
	}

    public void EraseSelf(NpcController npc)
    {
        npcs.Remove(npc);
    }
}
