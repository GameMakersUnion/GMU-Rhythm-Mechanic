using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	Color LNote=Color.black;
	Color RNote=Color.black;

	Color LPressed=Color.green;
	Color RPressed=Color.green;
	float LStart, RStart;

	void OnCollisionEnter2D(Collision2D collision){
		LNote = collision.gameObject.GetComponent<SpriteRenderer>().color;
		RNote  = collision.gameObject.GetComponent<SpriteRenderer>().color;

	}
	void OnCollisionExit2D(Collision2D collision){
		if (LNote==Color.white && collision.gameObject.transform.position.x<0) 
			collision.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		else if (RNote==Color.white && collision.gameObject.transform.position.x>0) 
			collision.gameObject.GetComponent<SpriteRenderer> ().color = Color.white;

		//if (collision.gameObject.GetComponent<SpriteRenderer> ().color != Color.white) 
		else
			collision.gameObject.GetComponent<SpriteRenderer> ().color = Color.black;
	}

	public void PressButton (btn button, bool isLeft){
		if (isLeft) {
			LStart=Time.time;
			if (button == btn.red)
					LPressed = Color.red;
			else if (button == btn.yellow)
					LPressed = Color.yellow;
			else if (button == btn.blue)
					LPressed = Color.blue;
		}
		else {

			RStart=Time.time;
			if (button == btn.red)
					RPressed = Color.red;
			else if (button == btn.yellow)
					RPressed = Color.yellow;
			else if (button == btn.blue)
					RPressed = Color.blue;
		}
	}

	void Update(){
		Debug.Log("LPressed"+LPressed+"LNote"+LNote);
		if (LPressed == LNote){
			LNote = Color.white;
		}
		if (RPressed == RNote){
			RNote = Color.white;
		}

		if (Time.time - LStart > 0.1)
			LPressed = Color.green;
		if (Time.time - RStart > 0.1)
			RPressed = Color.green;
	} 

}
