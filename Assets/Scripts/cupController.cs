using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cupController : MonoBehaviour {


    public GameObject CupPanel;
    // Update is called once per frame
    void Update () {
        Move();
	}

    void Move()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits;

            RaycastHit hit;
            Physics.Raycast(r, out hit);

            if(hit.transform != null && hit.transform.tag == "cup")
            {
                CupPanel.SetActive(true);
            }

            Debug.DrawRay(r.origin, r.direction, Color.red, 10.0f);

            hits = Physics.RaycastAll(r, 1000);
            /*
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition), 10.0f);
                if(hit.transform.tag == "roomobj" && (hit.transform.position - this.transform.position).magnitude > 2f)
                {
                    crabPanel.SetActive(true);
                }
            } */
            foreach(RaycastHit h in hits)
            {
                if (h.transform.tag == "roomobj" && (h.transform.position - this.transform.position).magnitude > 2f)
                {
                    CupPanel.SetActive(true);
                }
            }
        }
    }
}
