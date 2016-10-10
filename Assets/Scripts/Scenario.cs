using UnityEngine;
using System.Collections.Generic;
using UnityEngineInternal;


static class Scenario{
	static int sceneId = 0;
	public static int SceneId {
		get { return sceneId; }
		set { 
			sceneId = value; 
			setScenario ();
		}	
	}
	public const int SceneMaxId = 7;
	public static float allowRange {get ;private set;} 
	public static long targetFloor {get ;private set;} 
	public static string[] Script {get ;private set;}
	public static string targetText {get ;private set;}
	static Scenario(){setScenario ();}
	static void setScenario(){
		switch (SceneId) {
		case 0:  
			targetFloor = Random.Range (4, 10);
			allowRange = 1f;
			Script = new string[] { 
				"おっ、こんにちは〜\n(クリックで進む)",
				"このエレベーターに乗るのは初めてかいな？",
				"このエレベーターは少々普通と違ってな",
				"降りる階はダイナミックにエレベーターが上がってる時に決めるんや",
				"「ここや！」と思った時に、画面をクリックするとその階に止まれるんや",
				"とりあえず「" + targetFloor + "階」に行ってみてもらおうか",
			};
			targetText = targetFloor + "階";
			return;
		case 1: 
			targetFloor = Random.Range (10, 40) ;
			allowRange = 0.95f;
			Script = new string[] { 			
				"せやな、じゃあ次は高度" + targetFloor * 4 + "メートルくらいのところまで行ってくれ",
				"言い忘れとったけど、この建物は一フロア四メートルやで",
				"ほな、頼むで〜",
			};
			targetText = "" + targetFloor * 4+ "mくらい(1フロア4m)";
			return;
		case 2:	
			targetFloor = 83; //333m := 83:740px
			allowRange = 0.96f;
			Script = new string[] {
				"ここは東京やからすぐ近くに東京タワーがあるんやけれども",
				"せっかくやしその頂上くらいまで行ってみたいわ",
				"東京タワーの高さくらいは知ってるやろ？",
				"ほな、よろしくな〜",
			};
			targetText = "東京タワーのてっぺん";
			return;
		case 3:	
			targetFloor = 158; //634m := 158:770px
			allowRange = 0.965f;
			Script = new string[] { 
				"ここは東京やからすぐ近くに東京スカイツリーがあるんやけれども",
				"せっかくやしその頂上まで行ってみたいわ",
				"東京スカイツリーの高さは常識やろ？",
				"そういうことで、そこまでよろしくやで",
			};
			targetText = "スカイツリー最上階";
			return;
		case 4:	
			targetFloor = 944; //3776m := 944 :470px
			allowRange = 0.97f;
			Script = new string[] { 
				"ここは日本やからすぐ近くに富士山があるんやけれども",
				"せっかくやしその頂上まで行ってみたいわ",
				"富士山の高さは常識やろ？",
				"いっちょ富士山山頂までよろしくやで",
			};
			targetText = "富士山のてっぺん";
			return;
		case 5:	
			targetFloor = 100000;//(400,000m := 100,000F
			allowRange = 0.973f;
			Script = new string[] { 
				"ちょうど今の時期やと真上に国際宇宙ステーションが飛んでいるんやけれども",
				"せっかくやしその施設に行ってみたいわ",
				"国際宇宙ステーションの飛行高度は知ってるやろ？",
				"ほな、よろしくやで"
			};
			targetText = "国際宇宙ステーション";
			return;
		case 6:	
			targetFloor = 95000000;// 380,000,000m := 95,000,000
			allowRange = 0.976f;
			Script = new string[] { 
				"ちょうどこの時期この時間帯やと真上に月が見えるんやけれども",
				"せっかくやし月面着陸してみたいわ",
				"月がどのくらいの高さにあるかは知ってるやろ？",
				"ほな、いっちょ月まで連れてってくれな",
			};
			targetText = "月";
			return;
		case 7:	
			targetFloor = 37400000000;//"(149,600,000,000 := 37,400,000,000)"
			allowRange = 0.98f;
			Script = new string[] {  
				"ちょうどこの時期この時間帯やと真上に太陽が見えるんやけれども",
				"せっかくやし太陽着陸してみたいわ",
				"ちなみに今日のような時を日食というんや",
				"太陽がどのくらいの高さにあるかは知ってるやろ？",
				"これがラストや、いっちょ太陽までよろしくやで",
			};
			targetText = "太陽";
			return;
		}
	}
}
