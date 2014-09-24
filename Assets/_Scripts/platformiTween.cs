using UnityEngine;
using System.Collections;

public class platformiTween : MonoBehaviour {

  public int time;
	// Use this for initialization
	void Start () {
	
    iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("plat1"), "islocal", true, "time", time, "loopType", "loop"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
