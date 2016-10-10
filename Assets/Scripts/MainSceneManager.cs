using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml.Linq;
using UnityEngine.SceneManagement;
using System;


public class MainSceneManager : MonoBehaviour {

	[SerializeField] ReadingText serifText;
	[SerializeField] Animator uiGuideAnim;
	[SerializeField] InfiniteScrollUI floors;
	[SerializeField] Fade fade;
	[SerializeField] GameObject doorOpen;
	int readCount = 0;
	string[] scripts;

	void  InitFloorButtons(RectTransform rt,int index) {
		//n : [1..50 | 51.. 95 |  96.. 140| 141 ..  185, 186  ..   230]
		//ret:[1..50 | 60..500 | 600..5000| 6000..50000, 60000..500000,... ]  
		//    1*(n-0)|10*(n-45)|100*(n-90)|1000*(n-135)|
		//     k = 0 | 1       |  2       | 3
		// return 10 ** k * (n-45*k)
		// k = n <= 50 ? 0 : (n-6)/ 45  var copy = rt.GetComponent<Button>();
		var copy = rt.GetComponent<Button> ();
		long k = index <= 50 ? 0 : (index - 6) / 45;
		long ret = (long)Math.Pow (10, k) * (index - 45 * k);
		copy.name = ret.ToString ();
		copy.GetComponentInChildren<Text> ().text = ret + "F";
		copy.onClick.AddListener (() => {
			Scenario.selectedFloor = ret;
			fade.StartFade (true,()=>{ SceneManager.LoadScene ("landScape");});
		});	
	}


	void Start () {
		fade.StartFade();
		//floors.itemInitAction = InitFloorButtons;
		//floors.SetItems();
		//floors.enabled = false;
		//foreach (var c in floors.GetComponentsInChildren<Button>())c.enabled = false;
		scripts = Scenario.get();
		serifText.text = scripts [readCount++];
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (readCount < scripts.Length)
				serifText.text = scripts [readCount++];
			else {
				if (!floors.enabled) {
					fade.StartFade (true, () => { 
						doorOpen.SetActive(false);
						uiGuideAnim.gameObject.SetActive(false);
						fade.StartFade (false);
					});
					uiGuideAnim.SetTrigger ("Exit");
					//floors.enabled = true;
					//foreach (var c in floors.GetComponentsInChildren<Button>())c.enabled = true;
				}
			}
		}
	}
}
