using UnityEngine;
using System.Collections;

public enum btn
{
	red,
	yellow,
	blue,
}
public class Notes
{
	public float start, finish;
	public btn clr;
	public bool started;
	public int pitch;
	public float duration{ get { return 0.1f; } }
	public Notes(float start, float finish, btn clr, int pitch = 0)
	{
		this.start = start;
		this.finish = finish;
		this.clr = clr;
		this.started = false;
		this.pitch = pitch;
	}
	public bool isStarted(float time)
	{
		return time >= start;
	}
	public bool isEnded(float time)
	{
		return time >= finish;
	}
}

/*
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
*/