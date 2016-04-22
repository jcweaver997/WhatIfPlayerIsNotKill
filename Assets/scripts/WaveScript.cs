using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaveScript
{
	public static GameObject[] zombies;
	private zSpawner spawner;
	private int curWave = 0;
	private State curState;
	private int aliveZombies;
	private RoundStatus rs;
	private float roundStartTime;
	private float counter;
	private int spawnedZombies;
	private enum State
		{
		BeforeRound,Spawning,Waiting
		}

		public WaveScript (zSpawner s)
		{
				spawner = s;
		}
		public void setZombies(GameObject[] go){
		zombies = go;
	}
	public void setRoundStatus(RoundStatus r){
		rs = r;
	}
		public void update(){

		switch(curState){
		case State.Spawning:
			if(spawnedZombies >= Wave.numZombies[curWave]){
				setState(State.Waiting);
				break;
			}
			counter += Time.deltaTime;
			if(counter >= Wave.spawnDelta[curWave]){
				Spawn (zombies[Wave.zombiesToSpawn[curWave,spawnedZombies]]);
				spawnedZombies++;
				counter = 0;
			}

			break;
		case State.BeforeRound:
			//Debug.Log("Round starts in "+(counter-Wave.beforeRound[curWave]));
			rs.zLeft = (int)(Wave.beforeRound[curWave]-counter);
			counter+=Time.deltaTime;
			if(counter>=Wave.beforeRound[curWave]){
				NewWave();
			}
			break;
		case State.Waiting:
			//Debug.Log("Waiting till zombies are killed");
			if (aliveZombies == 0){
				if (curWave == Wave.maxWaves-1){
					SceneManager.LoadScene(5);
					return;
				}
				float timeDif = Time.time-roundStartTime;
			if(timeDif<Wave.estimatedTime[curWave]){
					GameScript.score+=(int)((Wave.estimatedTime[curWave]-timeDif)*GameScript.pointsForSecond);
					Debug.Log("Added "+((Wave.estimatedTime[curWave]-timeDif)*GameScript.pointsForSecond)+" for time dif of " + timeDif);
				}
			curWave++;
				rs.curRound = curWave+1;
			setState(State.BeforeRound);
			spawnedZombies = 0;
			counter = 0;
			}
			break;

		default:
			break;
		}
		}

	private void setState(State s){
		switch(s){
		case State.BeforeRound:
			rs.curState = RoundStatus.RoundState.BeforeRound;
			break;
		case State.Spawning:
			rs.curState = RoundStatus.RoundState.Spawning;
			break;
		case State.Waiting:
			rs.curState = RoundStatus.RoundState.Waiting;
			break;
		}

		curState = s;
	}

	private void setAliveZombies(int c){
		rs.zLeft = c;
		aliveZombies = c;
	}

		public void NewWave(){
		setAliveZombies(Wave.numZombies[curWave]);
		setState(State.Spawning);
		spawnedZombies = 0;
		roundStartTime = Time.time;
		}
		public void killedZombie(){
		setAliveZombies(aliveZombies-1);
		}
	public void Spawn(GameObject go){
		spawner.setSpawn(go);
		spawner.Spawn();
	}
}


