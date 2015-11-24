using UnityEngine;
using System.Collections;

public class RollTester : MonoBehaviour {
    
	private bool rollFlag;
	private Quaternion toRot;
	private Quaternion fromRot;

	public float rollSpeed;
	// Update is called once per frame
	void Update () {
		if (rollFlag) {
			//回転（１）のボタンを押すと以下の処理が実行されます
			//このメソッドの引数は(from=変更前のQuaternionの値, to=変更後のQuaternionの値, t=定数t)と成っています。
			Quaternion toRot = Quaternion.Euler( 0, 0, 180);
			transform.rotation = Quaternion.Slerp(transform.rotation, toRot, Time.deltaTime * rollSpeed);
		    
		}
	
	}

	void OnGUI(){

		if( GUI.Button(new Rect(250, 5, 150, 25), "回転(1)")){
			rollFlag = true;  
	    }
		if( GUI.Button(new Rect(250, 30, 150, 25), "回転(2)")){
			fromRot = Quaternion.Euler(0, 0, 0);
			toRot = Quaternion.Euler(0, 0, 90);
			transform.rotation = Quaternion.Slerp(fromRot, toRot, rollSpeed);		                                                  
        }
		if (GUI.Button(new Rect (250, 60, 150, 25), "回転をリセット")) {
			rollFlag = false;
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}

		GUI.Label (new Rect (250, 90, 150, 20), "Rotation.Z = " + transform.rotation.eulerAngles.z);
    }
}