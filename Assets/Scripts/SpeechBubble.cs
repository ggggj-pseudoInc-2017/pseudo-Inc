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

    string textToShow;

	float baseLength = 4;
	float lengthPerCharacter = 5f;

	IEnumerator Show() {
		textMesh.text = "";
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

    public void Talk()
    {
        Debug.Log("talk");
    }

	void OnEnable() {
		StartCoroutine(Show());
	}

	void OnDisable() {
		StopAllCoroutines();
	}
}
