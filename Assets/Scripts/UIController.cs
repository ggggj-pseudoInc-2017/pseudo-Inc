using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    public GameObject[] Panels;

	// Use this for initialization
	void Start ()
    {	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!(Panels[0].activeSelf || Panels[1].activeSelf || Panels[2].activeSelf || Panels[3].activeSelf)){
            Move();
        }
    }

    void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit[] hits;

            RaycastHit hit;
            Physics.Raycast(r, out hit);

            if(Panels[0].activeSelf || Panels[1].activeSelf || Panels[2].activeSelf || Panels[3].activeSelf)
            { }
            if (hit.transform != null){
                if (hit.transform.tag == "crab"){
                    Panels[0].SetActive(true);
                }
                else if (hit.transform.tag == "cup"){
                    Panels[1].SetActive(true);
                }
                else if (hit.transform.tag == "pot"){
                    Panels[2].SetActive(true);
                }
                else if (hit.transform.tag == "bible"){
                    Panels[3].SetActive(true);
                }
            }
            /*
            Debug.DrawRay(r.origin, r.direction, Color.red, 10.0f);

            hits = Physics.RaycastAll(r, 1000);

            foreach (RaycastHit h in hits)
            {
                if (h.transform.tag == "roomobj")
                {
                    if ((h.transform.position - this.transform.position).magnitude > 2f)
                    {
                        Panels[0].SetActive(true);
                        Panels[1].SetActive(true);
                        Panels[2].SetActive(true);
                        Panels[3].SetActive(true);
                    }
                }
            }
            */
        }
    }
}
