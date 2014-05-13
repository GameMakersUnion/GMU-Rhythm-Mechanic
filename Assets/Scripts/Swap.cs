using UnityEngine;
using System.Collections;

public class Swap : MonoBehaviour {

	public Sprite Button1;
	public Sprite Button2;
	public btn clr;
	public bool isLeft;

	public GameObject TriggerBar;
	// Update is called once per frame
	void Update () {


	
	}
	void OnMouseDown (){
		TriggerBar.GetComponent<ScoreBoard> ().PressButton (clr, isLeft);
		GetComponent <SpriteRenderer> ().sprite = Button2;

	}

	void OnMouseUp () {
		GetComponent <SpriteRenderer> ().sprite = Button1;
	}
}
