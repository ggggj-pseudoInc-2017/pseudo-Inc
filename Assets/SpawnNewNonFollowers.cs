using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewNonFollowers : MonoBehaviour {

    public GameObject[] persons;

    public Transform[][] points;
    public GameObject[] pointGroups;

    public float spwanTime = 10f;

	void Start ()
    {
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        Spawn();
        StartCoroutine(SpawnRoutine());
    }

	void Update () {
		
	}

    IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spwanTime);
            Spawn();
        }
    }

    void Spawn()
    {

    }
}
