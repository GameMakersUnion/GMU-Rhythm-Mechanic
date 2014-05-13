using UnityEngine;
using System.Collections;

public class NoteGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, -5, 0);
	}
}
