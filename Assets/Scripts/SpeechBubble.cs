using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

	[SerializeField]
	string[] refuse;
    [SerializeField]
    string[] neutral;
    [SerializeField]
    string[] accept;
	[SerializeField]
	Transform placeHolderTrans;
	[SerializeField]
	TextMesh textMesh;

    public float target;
    float zSize = 0f;
    public float smoothTime = 0.8F;
    private float yVelocity = 0.0F;

    float textTarget;
    float textSize = 0f;
    public float smoothTime2 = 0.1F;
    private float yVelocity2 = 0.0F;

    string textToShow;

	float baseLength = 4;
	float lengthPerCharacter = 5f;

	IEnumerator Show() {
		textMesh.text = "테스트 메세지";
		if (string.IsNullOrEmpty(textToShow))
			yield break;
		var timer = 0f;
		var textCnt = textToShow.Length;
		while (timer < 1f) {
			placeHolderTrans.localScale = new Vector3(
				baseLength + textCnt * timer * lengthPerCharacter
				, placeHolderTrans.localScale.y, placeHolderTrans.localScale.z);
			while (textMesh.text.Length < timer * textCnt) {
				textMesh.text += textToShow[textMesh.text.Length];
			}
			timer += Time.deltaTime;
			yield return null;
		}

		yield break;
	}
    private void Start()
    {
        textMesh.text = "테스트 메세지";
        textTarget = 1f;
        target = textMesh.text.Length * 6;
        textMesh.transform.localScale = new Vector3(0f, textMesh.transform.localScale.y, textMesh.transform.localScale.z);
        placeHolderTrans.localScale = new Vector3 (0f, placeHolderTrans.localScale.y, placeHolderTrans.localScale.z);
    }
    private void Update()
    {
        float newSize = Mathf.SmoothDamp(zSize, target, ref yVelocity, smoothTime);
        float newTextSize = Mathf.SmoothDamp(textSize, textTarget, ref yVelocity2, smoothTime2);
        zSize = newSize;
        textSize = newTextSize;
        placeHolderTrans.localScale = new Vector3(zSize, placeHolderTrans.localScale.y, placeHolderTrans.localScale.z);
        textMesh.transform.localScale = new Vector3(textSize, textMesh.transform.localScale.y, textMesh.transform.localScale.z);
    }

    public void Talk()
    {
        Debug.Log("talk");
    }

	/*void OnEnable() {
		StartCoroutine(Show());
	}*/

	void OnDisable() {
		StopAllCoroutines();
	}
}
