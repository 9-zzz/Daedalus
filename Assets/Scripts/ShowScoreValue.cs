using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowScoreValue : MonoBehaviour
{
  public Text ScoreLabel;
  public static float score = 0;
  public float score2 = 0;

  // Use this for initialization
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    score = score2;
    ScoreLabel.text = "YARIX: " + score;
  }
/*
  public void UpdateLabel(float value)
  {
    Text scoreLabel = GetComponent<Text>();
    if (scoreLabel != null)
      scoreLabel.text = "YARIX: " + Mathf.RoundToInt(score);
  }
  */

}
