using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour {

	Camera m_camera;
	float suc = 1f;
	[SerializeField] SpriteRenderer srPart;
	[SerializeField] int srPartNum = 6;
	[SerializeField] Text FloorText;
	[SerializeField] Fade fade;
	[SerializeField] Text ResultText;
	[SerializeField] Text TargetText;
	[SerializeField] Button TweetButton;
	[SerializeField] Button NextStageButton;


	void Start () {
		m_camera = GetComponent<Camera> ();
		suc = 1f;
		if (srPart != null) {
			for (int i = 1; i <= srPartNum; i++) {
				var copy = Instantiate (srPart as SpriteRenderer);
				copy.transform.position = srPart.transform.position + new Vector3(0,srPart.sprite.rect.height / srPart.sprite.pixelsPerUnit * i,0);
				copy.transform.SetParent (srPart.transform.parent);
				copy.name = "" + i;
			}		
		}
		fade.StartFade ();
		TargetText.text = "目標 : " + Scenario.targetText;
	}


	bool attrived = false;
	void Update () {
		if (attrived) {
			var rb = this.gameObject.GetComponent<Rigidbody2D> ();
			if (rb == null) return;
			if (transform.position.y < -50f) {
				rb.gravityScale = 0f;
				rb.velocity = new Vector2 (0f,0f);
			}
			return;
		}
		long floor = (transform.position.y < -2) ? 1 :
			(long)(transform.position.y + 2f) + 2;
		if (!Input.GetMouseButtonDown (0)) {
			suc *= 1.01f;
			transform.position = new Vector3 (0, suc - 4.29f, -10);
			m_camera.orthographicSize = 5 + transform.position.y / 2f;
		} else {
			attrived = true;
			ResultText.gameObject.SetActive (true);
			TweetButton.gameObject.SetActive (true);
			NextStageButton.gameObject.SetActive (true);
			NextStageButton.onClick.AddListener(()=>{
				SceneManager.LoadScene ("mainScene");
				fade.StartFade ();
			});
			fade.StartFade(false,null,5f);
			if (Scenario.targetFloor * Scenario.allowRange <= floor && floor <= Scenario.targetFloor / Scenario.allowRange ){
				ResultText.color = new Color (1,1,0.7f,1);
				ResultText.text = new string[]{ "神!!", "いいぞー", "よさ", "(^^)" }.ElementAt (UnityEngine.Random.Range (0, 4));
				if (Scenario.SceneId < Scenario.SceneMaxId) {
					Scenario.SceneId++;
					NextStageButton.GetComponentInChildren<Text> ().text = "次の\nステージへ";
					TweetButton.onClick.AddListener (()=>{
						Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(
							"エレベーターで" + Scenario.targetText + "に行けた！！ #gensundaielevator"
						));
					});
				}else {
					NextStageButton.GetComponentInChildren<Text> ().text = "最初から\nやり直す";
					TweetButton.onClick.AddListener (()=>{
						Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(
							"エレベーターで" + Scenario.targetText + "に行った！！ #gensundaielevator"
						));
					});
					Scenario.SceneId = 0;
				}
			} else {
				ResultText.color = new Color (1,0.7f,1f,1);
				ResultText.text = 
					floor < Scenario.targetFloor * 0.8 ? "もっと上や…" :
					floor > Scenario.targetFloor / 0.8 ? "もっと下や…" :
					floor < Scenario.targetFloor ? "もうちょい上や…" :
					floor > Scenario.targetFloor ? "もうちょい下や…" :
					"Miss...";
				NextStageButton.GetComponentInChildren<Text> ().text = "リトライ";
				TweetButton.onClick.AddListener (()=>{
					Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL(
						"エレベーターで" + Scenario.targetText + "に行くのに失敗した… #gensundaielevator"
					));
				});
				var rb = this.gameObject.AddComponent<Rigidbody2D> ();
				rb.gravityScale = suc * 0.3f;
				rb.velocity = (new Vector2(1f,1f) * suc / 2f);
			}
		}	
		FloorText.text = floor + "F";
	}
}
/*
twitter /落下/爆発窒息ビューなど
fuji = 470px / 3776m * 100 / 19.5 * 5.1282 / 4
Building : { 1u : 100 pixel, 1m : 19.5pixel, 1F : 4m, 1u = 5.1282m}
*/