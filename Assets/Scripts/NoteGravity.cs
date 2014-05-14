using UnityEngine;
using System.Collections;

public class NoteGravity : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0, -10, 0);
	}
}
