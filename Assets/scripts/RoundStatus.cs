using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoundStatus : MonoBehaviour {
	public Text roundText;
	public Text statusText;
	private RoundState rstate;
	public RoundState curState{
		get{return rstate;}
		set{
			switch(value){
			case RoundState.BeforeRound:
				statusText.text = "Round Starting in "+zLeft;
				break;
			case RoundState.Spawning:
				if (zLeft ==1)statusText.text = zLeft+" Monster left";
				else
				statusText.text = zLeft+" Monsters left";
				break;
			case RoundState.Waiting:
				if (zLeft ==1)statusText.text = zLeft+" Monster left";
				else
				statusText.text = zLeft+" Monsters left";
				break;
			}
			rstate = value;
		}
		}

	private int zomleft;

	public int zLeft{get{return zomleft;}
	set{
			zomleft = value;
			curState = curState;
		}
		}

	private int curRoundNum;

	public int curRound{
		get{return curRoundNum;}
		set{
			roundText.text = "Round " + value;

			curRoundNum = value;
		}
	}


	public enum RoundState
	{
		BeforeRound,Spawning,Waiting
	}

	public void Start(){


		curState = RoundState.BeforeRound;
		curRound = 1;


	}
}
