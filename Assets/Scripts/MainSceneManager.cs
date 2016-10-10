using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Linq;
using UnityEngine.SceneManagement;
using System;


public class MainSceneManager : MonoBehaviour {

	[SerializeField] ReadingText serifText;
	[SerializeField] Animator uiGuideAnim;
	[SerializeField] Fade fade;
	[SerializeField] GameObject doorOpen;
	int readCount = 0;
	string[] scripts;
	bool once = false;
	void Start () {
		fade.StartFade();
		scripts = Scenario.Script;
		serifText.text = scripts [readCount++];
	}

	void Update () {
		if (once)
			return; 
		if (Input.GetMouseButtonDown (0)) {
			if (readCount < scripts.Length)
				serifText.text = scripts [readCount++];
			else {
				fade.StartFade (true, () => { 
					doorOpen.SetActive(false);
					uiGuideAnim.gameObject.SetActive(false);
					fade.StartFade (false);
					SceneManager.LoadScene("landScape");
				});
				uiGuideAnim.SetTrigger ("Exit");
				once = true;
			}
		}
	}
}
