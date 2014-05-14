using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class NotesSpawner : MonoBehaviour {

	//timer variable here go here... 
	public GameObject NoteObjectTemplate;
	public GameObject Player1SpawnMarker;
	public GameObject Player2SpawnMarker;
	private List<Notes> allNotes;
	float SongTime=0;
	public Queue<GameObject> LNoteObjects;
	public Queue<GameObject> RNoteObjects;

	public GameObject audioHolder;
	bool isStarted = false;
	public float SongDelay;

	// Use this for initialization
	void Start () {

		allNotes = ReadFile();

		LNoteObjects = new Queue<GameObject> ();
		RNoteObjects = new Queue<GameObject> ();

		//allNotes = new List<Notes>();
		//allNotes.Add ( new Notes (0.2f, 0.3f, btn.yellow ));
		//allNotes.Add ( new Notes (0.38f, 0.48f, btn.yellow ));
		//allNotes.Add ( new Notes (0.65f, 0.77f, btn.yellow ));
		//allNotes.Add ( new Notes (0.95f, 1.06f, btn.blue ));
		//allNotes.Add ( new Notes (1.08f, 1.22f, btn.yellow ));
		//allNotes.Add ( new Notes (1.39f, 1.54f, btn.red ));
		//allNotes.Add ( new Notes (2.0f, 2.5f, btn.blue));



	}
	
	// Update is called once per frame
	void Update () {
		SongTime += Time.deltaTime;

		if (SongTime >= SongDelay && !isStarted) { 
			isStarted = true;
			audioHolder.GetComponent<AudioSource>().audio.Play();
		}


		if (allNotes.Count > 0 && allNotes[0].start < SongTime) {

			//Set Color
			if (allNotes[0].clr==btn.red) NoteObjectTemplate.GetComponent<SpriteRenderer>().color=Color.red;
			else if (allNotes[0].clr==btn.yellow) NoteObjectTemplate.GetComponent<SpriteRenderer>().color=Color.yellow;
			else NoteObjectTemplate.GetComponent<SpriteRenderer>().color=Color.blue;

			//Set Height
			//NoteObjectTemplate.transform.localScale.y=allNotes[0].duration*300;
			NoteObjectTemplate.transform.localScale = new Vector3 (NoteObjectTemplate.transform.localScale.x, allNotes[0].duration*300, NoteObjectTemplate.transform.localScale.z);
			//NoteObjectTemplate.transform.
			LNoteObjects.Enqueue ((GameObject) Instantiate (NoteObjectTemplate, Player1SpawnMarker.transform.position, Player1SpawnMarker.transform.rotation) );
			RNoteObjects.Enqueue ((GameObject) Instantiate (NoteObjectTemplate, Player2SpawnMarker.transform.position, Player2SpawnMarker.transform.rotation) );
			//Debug.Log ( "Time: " + SongTime + " NoteStart: " + allNotes[0].start );
			allNotes.RemoveAt(0);

		}


		if (Application.platform == RuntimePlatform.Android)	
		{
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
				return;
			}
		}
	}

	static List<Notes> ReadFile()
	{
		List<Notes> notes = new List<Notes>();
		List<int> pitches = new List<int>();
		//string[] lines = System.IO.File.ReadAllLines("mariosong_pitchduration.zack");


		
		TextAsset txt = (TextAsset)Resources.Load ("mariosong_pitchduration", typeof(TextAsset));
		string allLines = txt.text;
		string[] lines = allLines.Split("\n"[0]);
		


		//FileInfo theSourceFile = new FileInfo (Application.dataPath + "/" + "mariosong_pitchduration.zack");
		//StreamReader reader = theSourceFile.OpenText();
		//
		//
		//sr = new StreamReader(Application.dataPath + "/" + fileName);








		//function Start () {
		//	var sr = new StreamReader(Application.dataPath + "/" + fileName);
		//	var fileContents = sr.ReadToEnd();
		//	sr.Close();
		//	
		//	var lines = fileContents.Split("\n"[0]);
		//	for (line in lines) {
		//		print (line);
		//	}
		//}


		foreach(string line in lines)
		{
			string mins, seconds, frames, pitch;
			mins = line.Substring(0, 1);
			seconds = line.Substring(2, 2);
			frames = line.Substring(5, 2);
			pitch = line.Substring(8, 2);
			
			int minsI, secondsI, framesI, pitchI;
			int.TryParse(mins, out minsI);
			int.TryParse(seconds, out secondsI);
			int.TryParse(frames, out framesI);
			int.TryParse(pitch, out pitchI);
			
			float noteTime = 0f;
			noteTime += minsI * 60f;
			noteTime += secondsI;
			noteTime += framesI / 30f;
			
			pitches.Add(pitchI);
			
			Notes n = new Notes(noteTime, noteTime + 0.1f, btn.blue, pitchI);
			notes.Add(n);
		}
		pitches.Sort();
		//
		for(int i = 0; i < notes.Count; i++)
		{
			if (i == 0)
			{
				notes[i].clr = btn.yellow;
			}
			else
			{
				Notes current = notes[i], previous = notes[i - 1];
				if (current.pitch < previous.pitch)
				{
					current.clr = (btn)Mathf.Max((int)previous.clr - 1, 0);
				}
				else if (current.pitch > previous.pitch)
				{
					current.clr = (btn)Mathf.Min((int)previous.clr + 1, 2);
				}
				else
				{
					current.clr = previous.clr;
				}
			}
		}
		return notes;
	}
}
	