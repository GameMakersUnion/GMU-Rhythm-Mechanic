using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NotesSpawner : MonoBehaviour {

	//timer variable here go here... 
	public GameObject NoteObjectTemplate;
	public GameObject Player1SpawnMarker;
	public GameObject Player2SpawnMarker;
	private List<Notes> allNotes;
	float SongTime=0;
	private List<GameObject> NoteObjects;

	// Use this for initialization
	void Start () {
		NoteObjects = new List<GameObject> ();
		allNotes = new List<Notes>();
		allNotes.Add ( new Notes (0.2f, 0.32f, btn.yellow ));
		allNotes.Add ( new Notes (0.35f, 0.48f, btn.yellow ));
		allNotes.Add ( new Notes (0.65f, 0.77f, btn.yellow ));
		allNotes.Add ( new Notes (0.95f, 1.06f, btn.blue ));
		allNotes.Add ( new Notes (1.08f, 1.22f, btn.yellow ));
		allNotes.Add ( new Notes (1.39f, 1.54f, btn.red ));
		allNotes.Add ( new Notes (2.0f, 2.5f, btn.blue));

	}
	
	// Update is called once per frame
	void Update () {
		SongTime += Time.deltaTime;

		if (allNotes.Count>0 && allNotes[0].start < SongTime) {

			//Set Color
			if (allNotes[0].clr==btn.red) NoteObjectTemplate.GetComponent<SpriteRenderer>().color=Color.red;
			else if (allNotes[0].clr==btn.yellow) NoteObjectTemplate.GetComponent<SpriteRenderer>().color=Color.yellow;
			else NoteObjectTemplate.GetComponent<SpriteRenderer>().color=Color.blue;

			//Set Height
			//NoteObjectTemplate.transform.localScale.y=allNotes[0].duration*300;
			NoteObjectTemplate.transform.localScale = new Vector3 (NoteObjectTemplate.transform.localScale.x, allNotes[0].duration*300, NoteObjectTemplate.transform.localScale.z);
			//NoteObjectTemplate.transform.
			Instantiate (NoteObjectTemplate, Player1SpawnMarker.transform.position, Player1SpawnMarker.transform.rotation);
			Instantiate (NoteObjectTemplate, Player2SpawnMarker.transform.position, Player2SpawnMarker.transform.rotation);
			//Debug.Log ( "Time: " + SongTime + " NoteStart: " + allNotes[0].start );
			allNotes.RemoveAt(0);

		}




	
	}
}
