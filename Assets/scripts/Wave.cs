using UnityEngine;
using System.Collections;

public class Wave{
	public static int maxWaves = 6;
	public static int[] numZombies = {5,10,20,40,40,40};
	public static byte[,] zombiesToSpawn = new byte[maxWaves,40];
	public static float[] spawnDelta = {4,3,2,1,.75f,.5f};
	public static float[] beforeRound = {10,10,10,10,5,5};
	public static float[] estimatedTime = {30,40,50,50,60,70};
}
