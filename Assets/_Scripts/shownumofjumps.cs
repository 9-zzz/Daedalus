using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shownumofjumps : MonoBehaviour
{

  Text text;

  // Use this for initialization
  void Awake()
  {
    text = GetComponent<Text>();
  }

  // Update is called once per frame
  void Update()
  {
    text.text = "JUMPS: " + GameObject.Find("Player").GetComponent<TP_Motor>().numOfJumps;
  }
}
