﻿using UnityEngine;
using System.Collections;

public class ringrot : MonoBehaviour {

  public GameObject ringFront;
  public GameObject ringBack;

  void Update () {

    ringFront.transform.Rotate(Vector3.up * 0.25f);
    ringBack.transform.Rotate(Vector3.up * -1);

  }

}
