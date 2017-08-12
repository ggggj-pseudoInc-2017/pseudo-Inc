using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewNonFollowers : MonoBehaviour {

    public GameObject[] persons;
    
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
        StartCoroutine(SpawnRoutine());
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
        GameObject newPerson = Instantiate(persons[Random.Range(0, persons.Length)]);
        newPerson.GetComponent<NpcController>().pointGroup = pointGroups[Random.Range(0, pointGroups.Length)];
    }
}
