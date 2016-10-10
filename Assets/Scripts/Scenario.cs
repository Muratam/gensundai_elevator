using UnityEngine;
using System.Collections.Generic;


static class Scenario{
	public static int SceneId = 0;
	public const int SceneMaxId = 7;
	public static long selectedFloor = 6;
	public static long[] targetFloorRange = new long[2]{2,4}; 
	public static string[] get(){
		switch (SceneId) {
		case 0:  
			targetFloorRange[0] = targetFloorRange[1] = Random.Range (4, 10);
			return new string[] { 
				"おっ、こんにちは〜(クリックで進む)",
				"このエレベーターに乗るのは初めてかいな？",
				"このエレベーターは少々普通と違ってな",
				"降りる階はダイナミックに後で決めるんや",
				"「ここや！」と思った時に画面をクリックするとその階に止まれるんや",
				"とりあえず「" + targetFloorRange[0] + "階」に行ってみてもらおか",
			};
		case 1: 
			targetFloorRange[0] = targetFloorRange[1] = Random.Range (10, 40) ;
			return new string[] { 				
				//"マウスをスクロールするともっと上の方の階にまで行けるやで",
				"次は、高度" + targetFloorRange[0] * 4 + "メートルまで行ってくれ",
				"言い忘れとったけど、この建物は一フロア四メートルやで",
				"ほな、頼むで〜",
			};
		case 2:	
			targetFloorRange = new long[2]{ 80,90 };
			return new string[] { //333m := 83 ~ 80F(90F):740px
				"ここは東京やからすぐ近くに東京タワーがあるんやけれども",
				"せっかくやしその頂上まで行ってみたいわ",
				"東京タワーの高さくらいは知ってるやろ？",
				"ほな、よろしくな〜",
			};
		case 3:	
			targetFloorRange = new long[2]{ 150, 160 };
			return new string[] { //634m := 158 ~ 150F(160F):770px
				"ここは東京やからすぐ近くに東京スカイツリーがあるんやけれども",
				"せっかくやしその頂上まで行ってみたいわ",
				"東京スカイツリーの高さは常識やろ？",
				"そういうことで、そこまでよろしくやで",
			};
		case 4:	
			targetFloorRange = new long[2]{ 900, 1000 };
			return new string[] { //3776m := 944 ~ 900F(1000F) :470px
				"ここは日本やからすぐ近くに富士山があるんやけれども",
				"せっかくやしその頂上まで行ってみたいわ",
				"富士山の高さは常識やろ？",
				"いっちょ富士山山頂までよろしくやで",
			};
		case 5:	
			targetFloorRange = new long[2]{90000,110000};
			return new string[] { //(400,000m := 100,000F(90000~110000))
				"ちょうど今の時期やと真上に国際宇宙ステーションが飛んでいるんやけれども",
				"せっかくやしその施設に行ってみたいわ",
				"国際宇宙ステーションの飛行高度は知ってるやろ？",
				"ほな、よろしくやで"
			};
		case 6:	
			targetFloorRange = new long[2]{90000000, 100000000};
			return new string[] { // 380,000,000m := 95,000,000 ~ 90,000,000(100,000,000)
				"ちょうどこの時期この時間帯やと真上に月が見えるんやけれども",
				"せっかくやし月に行ってみたいわ",
				"月がどのくらいの高さにあるかは知ってるやろ？",
				"ほな、いっちょ月まで連れてってくれな",
			};
		case 7:	
			targetFloorRange = new long[2]{37000000000,38000000000 };
			return new string[] {  //"(149,600,000,000 := 37,400,000,000)"
				"ちょうどこの時期この時間帯やと真上に太陽が見えるんやけれども",
				"せっかくやし太陽に行ってみたいわ",
				"ちなみに今日のような時を日食というんや",
				"太陽がどのくらいの高さにあるかは知ってるやろ？",
				"これがラストや、いっちょ太陽までよろしくやで",
			};
		}
		return new string[]{ "ウヒョー" };
	}
}
