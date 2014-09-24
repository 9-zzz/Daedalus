using UnityEngine;
using XInputDotNetPure;
using System.Collections;

public class StopVibes : MonoBehaviour
{

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetKeyDown("q"))
    {
      GamePad.SetVibration(0, 0, 0);
    }

  }
}