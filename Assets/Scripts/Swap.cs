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
		int i = 0;
		while ( i < Input.touchCount){

			if(Input.GetTouch(i).phase == TouchPhase.Began){

				Vector3 pos = Camera.main.ScreenToWorldPoint (Input.GetTouch(i).position);
				RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
				if (hit != null && hit.collider != null) {
					if ( hit.collider.name == transform.name ){
						Pressed ();
						Debug.Log ("I'm hitting "+hit.collider.name);
					}
				}
			}
			else if ( Input.GetTouch(i).phase == TouchPhase.Ended ){
				Unpressed();
			}

			++i;
		}
		
	}



	public void Pressed (){
		TriggerBar.GetComponent<ScoreBoard> ().PressButton (clr, isLeft);
		GetComponent <SpriteRenderer> ().sprite = Button2;

	}

	public void Unpressed () {
		GetComponent <SpriteRenderer> ().sprite = Button1;
	}



}
