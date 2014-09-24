using UnityEngine;
using System.Collections;

public class quadHead : MonoBehaviour
{
  //Quaternion start;
  //Quaternion dest;
  float time;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    time += Time.deltaTime;

    //start = transform.rotation;

    //dest = GameObject.Find("Player").transform.rotation;

    transform.LookAt(GameObject.Find("Player").transform.position);
    //transform.rotation = Quaternion.Lerp(start, dest, time*0.025f);

  }
}