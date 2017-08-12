using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpChurchMotion : MonoBehaviour {

    public GameObject[] church;

    public GameObject currentChurch;
    
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            currentChurch.transform.DOShakeRotation(0.8f, 90f, 15, 90f, false);
            StartCoroutine(Change());
            
        }
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(0.8f);
        church[0].SetActive(false);
        church[1].SetActive(true);
        currentChurch.transform.DOShakeRotation(0.8f, 90f, 15, 90f, false);
    }
}
