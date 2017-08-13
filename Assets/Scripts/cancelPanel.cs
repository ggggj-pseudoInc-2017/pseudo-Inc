using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pseudoinc;

public class cancelPanel : MonoBehaviour {

    public GameObject Panel;
    public Text text;
    
    // Use this for initialization
	void Start () {
        text.text = "성소 확장 비용 : " + Church.MoneyToBuild;
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void clickCancel()
    {
        Panel.SetActive(false);
    }
}
