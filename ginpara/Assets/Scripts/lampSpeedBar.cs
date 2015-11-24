using UnityEngine;
using System.Collections;

public class LampSpeedBar : MonoBehaviour {

	private float barSpeed = 1.0f;
    //ランプの点滅速度や回転速度を調整できるGUIスライダーです
	//0~1fの間で速さの変更ができます
	//速さの変更がしたい時にはスピードの値を変えて下さい ランプだけや回転する羽ものだけ調整したいので、現在改良中です。
	void OnGUI(){
		barSpeed = GUI.HorizontalSlider (new Rect (0, 50, 100, 16), barSpeed, 0.0f, 1.0f);

		Time.timeScale = barSpeed;

		GUI.Label (new Rect (0, 60, 200, 32), "lampSpeed: " + barSpeed);
	}
}
