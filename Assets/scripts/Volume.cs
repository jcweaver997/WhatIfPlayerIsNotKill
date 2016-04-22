using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {
	public static float Music = 1;
	public static float Effect = 1;

	public float musicVolume{get{return Music;}set{Music = value;}}
	public float effectVolume{get{return Effect;}set{Effect = value;}}
}
