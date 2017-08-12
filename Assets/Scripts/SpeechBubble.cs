using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

	[SerializeField]
	string textToShow;
	[SerializeField]
	Transform placeHolderTrans;
	[SerializeField]
	TextMesh textMesh;


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

	void OnEnable() {
		StartCoroutine(Show());
	}

	void OnDisable() {
		StopAllCoroutines();
	}
}
