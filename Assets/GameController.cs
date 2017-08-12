using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pseudoinc;

public class GameController : MonoBehaviour {

    public List<NpcController> npcs;

	void Start ()
    {
        npcs = new List<NpcController>();
	}
	
	void Update ()
    {
        Debug.Log(Church.Get_faith());
	}

    public void EraseSelf(NpcController npc)
    {
        npcs.Remove(npc);
    }
}
