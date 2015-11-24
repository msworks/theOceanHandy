using UnityEngine;
using System.Collections;

public class RollTester2 : MonoBehaviour {

	public Vector3 angle;
	public float rollTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (angle * rollTime * Time.deltaTime );
	
	}
}
