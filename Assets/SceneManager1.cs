using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour {

    int sceneNum = 0;

	void Start ()
    {
        if (FindObjectOfType<SceneManager1>() != null)
        {
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
	}
	

	void Update ()
    {
		if(sceneNum == 0 )
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity);
                if (hit.transform != null)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
	}
}
