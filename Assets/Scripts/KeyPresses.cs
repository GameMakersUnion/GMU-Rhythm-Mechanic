using UnityEngine;
using System.Collections;

public class KeyPresses : MonoBehaviour {


	public Transform LeftRed;
	public Transform LeftYellow;
	public Transform LeftBlue;

	public Transform RightRed;
	public Transform RightYellow;
	public Transform RightBlue;


	// Update is called once per frame
	void Update () {
		if ( Input.GetKeyDown( KeyCode.A )){
			LeftRed.GetComponent<Swap>().Pressed();
		}
		else if ( Input.GetKeyDown ( KeyCode.S )) {
			LeftYellow.GetComponent<Swap>().Pressed();
		}
		else if ( Input.GetKeyDown ( KeyCode.D )) {
			LeftBlue.GetComponent<Swap>().Pressed();
		}

		if ( Input.GetKeyUp( KeyCode.A )){
			LeftRed.GetComponent<Swap>().Unpressed();
		}
		else if ( Input.GetKeyUp ( KeyCode.S )) {
			LeftYellow.GetComponent<Swap>().Unpressed();
		}
		else if ( Input.GetKeyUp ( KeyCode.D )) {
			LeftBlue.GetComponent<Swap>().Unpressed();
		}

		if ( Input.GetKeyDown( KeyCode.J )){
			RightRed.GetComponent<Swap>().Pressed();
		}
		else if ( Input.GetKeyDown ( KeyCode.K )) {
			RightYellow.GetComponent<Swap>().Pressed();
		}
		else if ( Input.GetKeyDown ( KeyCode.L )) {
			RightBlue.GetComponent<Swap>().Pressed();
		}
		
		if ( Input.GetKeyUp( KeyCode.J )){
			RightRed.GetComponent<Swap>().Unpressed();
		}
		else if ( Input.GetKeyUp ( KeyCode.K )) {
			RightYellow.GetComponent<Swap>().Unpressed();
		}
		else if ( Input.GetKeyUp ( KeyCode.L )) {
			RightBlue.GetComponent<Swap>().Unpressed();
		}

	}
}
