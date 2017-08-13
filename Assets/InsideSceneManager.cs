using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pseudoinc;
using System.Linq;

public class InsideSceneManager : MonoBehaviour {

    public GameObject[] Persons;

    public GameObject level0Pos;
    public GameObject level1Pos;
    public GameObject level2Pos;
    public GameObject level3Pos;
    public GameObject level4Pos;

    public GameObject level0;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;

    Transform[] Posintions;

    void Start ()
    {
		switch(Church.Get_level())
        {
            case 0:
                level0.SetActive(true);
                Posintions = level0Pos.GetComponentsInChildren<Transform>();
                SetPeople();
                return;
            case 1:
                level1.SetActive(true);
                Posintions = level1Pos.GetComponentsInChildren<Transform>();
                SetPeople();
                return;
            case 2:
                level2.SetActive(true);
                Posintions = level2Pos.GetComponentsInChildren<Transform>();
                SetPeople();
                return;
            case 3:
                level3.SetActive(true);
                Posintions = level3Pos.GetComponentsInChildren<Transform>();
                SetPeople();
                return;
            case 4:
                level4.SetActive(true);
                Posintions = level4Pos.GetComponentsInChildren<Transform>();
                SetPeople();
                return;
        }
	}
	
	void Update () {
		
	}

    void SetPeople()
    {
        List<Transform> positions = Posintions.ToList<Transform>();
        int n = positions.Count;
        System.Random rnd = new System.Random();
        while (n > 1)
        {
            int k = (rnd.Next(0, n) % n);
            n--;
            Transform value = positions[k];
            positions[k] = positions[n];
            positions[n] = value;
        }
        for(int i = 0; i < Church.Get_num_followers();i++)
        {
            GameObject newPerson = Instantiate(Persons[Random.Range(0, Persons.Length)]);
            newPerson.transform.position = positions[i].position;
        }
    }
}
