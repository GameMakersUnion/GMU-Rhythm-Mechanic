using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour {
	Color LNote=Color.black;
	Color RNote=Color.black;

	Color LPressed=Color.green;
	Color RPressed=Color.green;
	float LStart, RStart;

	public int LScore = 0;
	public int RScore = 0;

	private Queue<GameObject> LNoteObjects;
	private Queue<GameObject> RNoteObjects;

	void Start(){
		LNoteObjects = GameObject.Find("Spawner").GetComponent<NotesSpawner>().LNoteObjects;
		RNoteObjects = GameObject.Find("Spawner").GetComponent<NotesSpawner>().RNoteObjects;
	}

	void OnCollisionEnter2D(Collision2D collision){
		if ( collision.gameObject.transform.position.x<0 ){
			LNote = collision.gameObject.GetComponent<SpriteRenderer>().color;
			LNoteObjects.Dequeue();
		}
			else{
				RNote = collision.gameObject.GetComponent<SpriteRenderer>().color;
				RNoteObjects.Dequeue();
		}
	}

	void OnCollisionExit2D(Collision2D collision){

		SpriteRenderer NoteBlock = collision.gameObject.GetComponent<SpriteRenderer> ();

		if ( collision.gameObject.transform.position.x<0 ){

			if (LNote==Color.white ) {
				NoteBlock.color = Color.white;
				LScore += 100;
			}
			else {
				NoteBlock.color = Color.black;
				LScore-=10;
			}


		}
		else {
			if (RNote==Color.white) {
				NoteBlock.color = Color.white;
				RScore += 100;
			}
			else {
				NoteBlock.color = Color.black;
				RScore-=10;
			}
		}



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
		//Debug.Log("LPressed"+LPressed+"LNote"+LNote);
		if (LPressed == LNote){
			//LNoteObjects.Peek().GetComponent<SpriteRenderer>().color = Color.white;
			LNote = Color.white;
		}
		if (RPressed == RNote){
			//RNoteObjects.Peek().GetComponent<SpriteRenderer>().color = Color.white;
			RNote = Color.white;
		}

		if (Time.time - LStart > 0.1 && LPressed != Color.green)
			LNoteObjects.Peek().GetComponent<SpriteRenderer>().color = Color.black;
			LPressed = Color.green;
		if (Time.time - RStart > 0.1 && RPressed != Color.green )
			RNoteObjects.Peek().GetComponent<SpriteRenderer>().color = Color.black;
			RPressed = Color.green;
	} 

	void OnGUI(){
		int margin = 20;
		int width = 50;
		int height = 25;
		GUI.Box ( new Rect( margin, margin, width, height ), LScore.ToString() );
		GUI.Box ( new Rect( Screen.width - width - margin, margin, width, height ), RScore.ToString() );
	}

}
