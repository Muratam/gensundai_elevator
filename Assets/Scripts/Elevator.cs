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
	}

	bool attrived = false;
	void Update () {
		if(attrived) return;
		long floor = (transform.position.y < -2) ? 1 :
			(long)(transform.position.y + 2f) + 2;
		if (floor < Scenario.selectedFloor) {
			suc *= 1.01f;
			transform.position = new Vector3 (0, suc - 4.29f, -10);
			m_camera.orthographicSize = 5 + transform.position.y / 2f;
		} else {
			attrived = true;
			if (floor > 50) // 上位二桁のみにする
				floor = long.Parse(floor.ToString().Substring(0, 2)) * (long)(Math.Pow(10,(floor.ToString().Length-2))); 
			ResultText.gameObject.SetActive (true);
			if (Scenario.targetFloors.Contains(Scenario.selectedFloor)) {
				ResultText.color = new Color (1,1,0.7f,1);
				ResultText.text = "CLEAR!!";
				if (Scenario.SceneId < Scenario.SceneMaxId)
					Scenario.SceneId++;
				else {
					
				}
			} else {
				ResultText.color = new Color (1,0.7f,1f,1);
				ResultText.text = "MISS..";
			}
			fade.StartFade (false,()=>{ SceneManager.LoadScene ("mainScene");},3f);

		}	
		FloorText.text = floor + "F";
	}
}
/*
ISSふわふわ / 理由のUI / もっと上 | 上 | もっと下 とかのほうがいいかも / twitter /落下/爆発窒息ビューなど
fuji = 470px / 3776m * 100 / 19.5 * 5.1282 / 4
Building : { 1u : 100 pixel, 1m : 19.5pixel, 1F : 4m, 1u = 5.1282m}
*/