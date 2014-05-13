using UnityEngine;
using System.Collections;

public enum btn{red, yellow, blue};

public class Notes {

	public float start, finish;
	public btn clr;
	public Notes (float start, float finish, btn clr){
		this.start = start;
		this.finish = finish;
		this.clr = clr;
	}

	public float duration{ 
		get{ 
			return this.finish - this.start;
		}
	}
}
